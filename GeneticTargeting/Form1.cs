using EvolutionaryLogic;
using Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaamLogics;

namespace GeneticTargeting
{
    public partial class Form1 : Form
    {
        private CMap Terrain { get; set; }
        public static God PopGen { get; set; }
        public bool IsStarted { get; set; }

        public Form1()
        {
            InitializeComponent();
            this.Terrain = new CMap(10, 100);
            Font f = new Font(FontFamily.GenericMonospace, 15);
            SolidBrush b = new SolidBrush(Color.Black);
            Pen p = new Pen(new SolidBrush(Color.Black), 3);

            this.ipStrategy.DrawFunction = (g) =>
            {
                if (PopGen?.BestFitness != null)
                {
                    CTaamAssignment BestFitness = (CTaamAssignment)PopGen?.BestFitness;
                    // this.Terrain.Draw(g);

                    int CounterY = 0;
                    var Genes = BestFitness.GetGenes();
                    for (int i = 0; i < CStrategyPool.ActiveStrategy.GetSectorsCount(); i++)
                    {
                        var ActiveSector = CStrategyPool.ActiveStrategy.SectorsData[i];
                        CSimpleBattalion[] AssignedBattalions = new CSimpleBattalion[TaamCalendar.ChunksCount];
                        Point2D Location = new Point2D();

                        for (int j = 0; j < TaamCalendar.ChunksCount; j++)
                        {
                            CSingleAssignment SectorAssignment = Genes[i * TaamCalendar.ChunksCount + j];
                            AssignedBattalions[j] = CStrategyPool.ActiveStrategy.BattalionsData[SectorAssignment.BattalionUID];
                        }

                        Location.Y = CounterY;
                        g.DrawString(ActiveSector.UID.ToString() + ":", f, b, (int)Location.X - 130, (int)Location.Y + 40);
                        g.DrawString(ActiveSector.MySectorialBrigade.ToString() + ":", f, b, (int)Location.X - 130, (int)Location.Y + 60);
                        g.DrawRectangle(p, (int)Location.X, (int)Location.Y, 800, 100);

                        for (int j = 0; j < TaamCalendar.ChunksCount; j++)
                        {
                            g.DrawLine(p, (int)Location.X + 200 * j, (int)Location.Y, (int)Location.X + 200 * j, (int)Location.Y + 100);
                            if (AssignedBattalions[j] != null)
                            {
                                SolidBrush bbb = new SolidBrush(CStrategyPool.ActiveStrategy.BattalionsData[AssignedBattalions[j].UID].ScoreAssignment(Genes[i * TaamCalendar.ChunksCount + j]) > 0 ? Color.Red : Color.Black);
                                int OffsetX = 90 + (200 * j);
                                g.DrawString(AssignedBattalions[j].UID.ToString(), f, bbb, (int)Location.X + OffsetX, (int)Location.Y + 40);
                            }
                        }


                        CounterY += 120;
                    }
                }
            };

            this.ipStrategy.UpdateFunction = () => CStrategyPool.ActiveStrategy.Update();

            this.ipStatus.DrawFunction = (g) =>
            {
                PopGen?.StatusGraph.Draw(g);
            };


            this.ipBattalionToSectorSum.DrawFunction = g =>
            {
                if (PopGen?.BestFitness != null)
                {
                    CTaamAssignment BestFitness = (CTaamAssignment)PopGen.BestFitness;
                    int yCounter = 0;
                    var Assignments = BestFitness.GetGenes();

                    // [] Battalion, [] 4 Rotations
                    int[][] BattalionToSectorRotation = Shared.SafeArray(CStrategyPool.ActiveStrategy.GetBattalionsCount(), () => Shared.SafeArray<int>(TaamCalendar.ChunksCount));
                    for (int i = 0; i < Assignments.Length; i++)
                    {
                        BattalionToSectorRotation[Assignments[i].BattalionUID][i % TaamCalendar.ChunksCount]++;
                    }

                    for (int i = 0; i < BattalionToSectorRotation.Length; i++)
                    {
                        SolidBrush bb = new SolidBrush(Color.Black);
                        string strRow = string.Format("b" + (i < 10 ? "0" + i : i + ""));
                        string strRotations = "";

                        int nMoreThenOne = 0;
                        for (int j = 0; j < BattalionToSectorRotation[i].Length; j++)
                        {
                            if(BattalionToSectorRotation[i][j] != 0)
                            {
                                strRotations += "r" + j + ": " + BattalionToSectorRotation[i][j] + ", ";
                                nMoreThenOne++;
                            }
                            if(BattalionToSectorRotation[i][j] > 1 || nMoreThenOne > 2)
                            {
                                bb.Color = Color.Red;
                            }
                        }

                        strRow += ";   " + strRotations;
                        g.DrawString(strRow, f, bb, 0, yCounter);
                        yCounter += 20;
                    }
                }
            };

            this.initConfigDelegation();
        }

        public void initConfigDelegation()
        {
            #region Genetic Configuration

            this.tbPopulationSize.Value = GlobalConfiguration.PopulationCount;
            this.tbPopulationSize.Tag = GlobalConfiguration.GetDelegate("PopulationCount");

            this.tbMutationChance.Value = (decimal)GlobalConfiguration.MutationChance;
            this.tbMutationChance.Tag = GlobalConfiguration.GetDelegate("MutationChance");

            this.tbParentChance.Value = (decimal)GlobalConfiguration.ParentChance;
            this.tbParentChance.Tag = GlobalConfiguration.GetDelegate("ParentChance");

            this.cbApplyElitist.CheckState = GlobalConfiguration.ApplyElitist ? CheckState.Checked : CheckState.Unchecked;
            this.cbApplyElitist.Tag = GlobalConfiguration.GetDelegate("ApplyElitist");

            this.cbApplyNaturalSelection.CheckState = GlobalConfiguration.ApplyNaturalSelection ? CheckState.Checked : CheckState.Unchecked;
            this.cbApplyNaturalSelection.Tag = GlobalConfiguration.GetDelegate("ApplyNaturalSelection");

            this.cbPartialGenomCrossover.CheckState = GlobalConfiguration.PartialGenomCrossover ? CheckState.Checked : CheckState.Unchecked;
            this.cbPartialGenomCrossover.Tag = GlobalConfiguration.GetDelegate("PartialGenomCrossover");

            #endregion

            #region Performances

            this.nmThreadBulkSize.Value = GlobalConfiguration.Performances.ThreadBulkSize;
            this.nmThreadBulkSize.Tag = GlobalConfiguration.GetDelegate("ThreadBulkSize");

            this.cbFixedStrategy.CheckState = GlobalConfiguration.Performances.FixedStrategy ? CheckState.Checked : CheckState.Unchecked;
            this.cbFixedStrategy.Tag = GlobalConfiguration.GetDelegate("FixedStrategy");

            #endregion


            #region Assignment

            this.nmBattalionCount.Value = GlobalConfiguration.Assignemnt.BattalionCount;
            this.nmBattalionCount.Tag = GlobalConfiguration.GetDelegate("BattalionCount");

            this.nmSectorCount.Value = GlobalConfiguration.Assignemnt.SectorCount;
            this.nmSectorCount.Tag = GlobalConfiguration.GetDelegate("SectorCount");

            #endregion
        }

        private async void btnGeneratePopulation_Click(object sender, EventArgs e)
        {
            int cycles = Convert.ToInt32(this.numCycles.Value);

            Progress<IDNA> progress = new Progress<IDNA>(world => {
                this.UpdateBestFitnessLabels();
                this.ipStatus.TransformOrigin.X = -PopGen.StatusGraph.GetWidth();
                this.ipStatus.TransformOrigin.Y = -PopGen.StatusGraph.GetHeight();
            });

            this.btnGeneratePopulation.Enabled = false;
            this.btnRestrategize.Enabled = false;
            this.btnStart.Enabled = false;

            Stopwatch w = Stopwatch.StartNew();
            await Task.Factory.StartNew(() => PopGen.GeneratePopulation(cycles, progress), TaskCreationOptions.LongRunning);
            w.Stop();
            Debug.WriteLine(w.ElapsedMilliseconds);

            this.btnGeneratePopulation.Enabled = true;
            this.btnRestrategize.Enabled = true;
            this.btnStart.Enabled = true;

            this.UpdateBestFitnessLabels();
            this.ipStrategy.Refresh();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.btnStart.Text = "Restart!";
            if (this.IsStarted)
            {
                this.InitPopulation();
            } 
            else
            {
                this.Restrategize();
            }
            this.btnGeneratePopulation.Enabled = true;
            this.btnRestrategize.Enabled = true;
            this.IsStarted = true;
        }

        private void btnRestrategize_Click(object sender, EventArgs e)
        {
            this.Restrategize();
            //var a = new TaamCalendar();
            //var b = a.GetTaamChunks(new DateTime(2018,1,1));
        }

        private void Restrategize()
        {
            CStrategyPool.CreateRandomStrategy(this.Terrain);
            // this.ipStrategy.TransformOrigin = new Point2D(-this.Terrain.GetWidth() / 2, -this.Terrain.GetHeight() / 2);
            this.InitPopulation();
        }

        private void InitPopulation()
        {
            PopGen = new God(this.GetPopulationGenerator());

            this.UpdateBestFitnessLabels();
            this.ipStrategy.Refresh();
        }

        public Func<IDNA> GetPopulationGenerator()
        {
            return () => new CTaamAssignment();
        }

        private void UpdateBestFitnessLabels()
        {
            this.lblGenerationCount.Text = "Curr gen count: " + PopGen.GenerationCount;
            this.lblAverageFitness.Text = "Average fitness: " + PopGen.AvreageFitness;
            this.lblBestFitness.Text = "Best Fitness: " + PopGen.BestFitness.GetFitnesss();
        }

        private void tbConfig_TextChanged(object sender, EventArgs e)
        {
            NumericUpDown tb = (NumericUpDown)sender;
            if (tb.Tag != null)
            {
                ((Action<object>)(tb).Tag)(tb.Value);
            }
        }

        private void cbConfig_TextChanged(object sender, EventArgs e)
        {
            CheckBox tb = (CheckBox)sender;
            if (tb.Tag != null)
            {
                ((Action<object>)(tb).Tag)(tb.CheckState == CheckState.Checked);
            }
        }

        private void pnlStatusGraph_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Silver);
            if (PopGen?.BestFitness != null)
            {
                PopGen.StatusGraph.Draw(e.Graphics);
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.ipStatus.Refresh();
        }
    }
}
