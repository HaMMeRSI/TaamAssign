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
            this.Terrain = new CMap(GlobalConfiguration.GameSettings.GridSize, 100);

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
                        for (int j = 0; j < TaamCalendar.ChunksCount; j++)
                        {
                            CSingleAssignment SectorAssignment = Genes[i * TaamCalendar.ChunksCount + j];
                            ActiveSector.AssignedBattalions[j] = CStrategyPool.ActiveStrategy.BattalionsData[SectorAssignment.BattalionUID];
                        }

                        ActiveSector.Location.Y = CounterY;
                        ActiveSector.Draw(g);
                        CounterY += 120;
                    }
                }
            };

            this.ipStrategy.UpdateFunction = () => CStrategyPool.ActiveStrategy.Update();

            this.ipStatus.DrawFunction = (g) =>
            {
                PopGen?.StatusGraph.Draw(g);
            };

            SolidBrush b = new SolidBrush(Color.Black);
            Font f = new Font(FontFamily.GenericMonospace, 15);

            this.ipBattalionToSectorSum.DrawFunction = g =>
            {
                if (PopGen?.BestFitness != null)
                {
                    CTaamAssignment BestFitness = (CTaamAssignment)PopGen.BestFitness;
                    int yCounter = 0;
                    var Assignments = BestFitness.GetGenes();

                    //int[][] BattalionToSectorRotation = Shared.SafeArray(CStrategyPool.ActiveStrategy.GetBattalionsCount(), () => Shared.SafeArray<int>(TaamCalendar.ChunksCount));
                    // new int[CStrategyPool.ActiveStrategy.GetBattalionsCount()][];
                    // Brigade - Rotation, Count
                    SortedDictionary<int, int>[] BattalionInSectorCount = Shared.SafeArray(CStrategyPool.ActiveStrategy.GetBattalionsCount(), () => new SortedDictionary<int, int>());
                    for (int i = 0; i < Assignments.Length; i++)
                    {
                        var Assignment = Assignments[i];
                        if (BattalionInSectorCount[Assignment.BattalionUID] == null)
                        {
                            BattalionInSectorCount[Assignment.BattalionUID] = new SortedDictionary<int, int>();
                            BattalionInSectorCount[Assignment.BattalionUID][i % TaamCalendar.ChunksCount] = 1;
                        }
                        else
                        {
                            if (!BattalionInSectorCount[Assignment.BattalionUID].ContainsKey(i % TaamCalendar.ChunksCount))
                            {
                                BattalionInSectorCount[Assignment.BattalionUID][i % TaamCalendar.ChunksCount] = 1;
                            }
                            else
                            {
                                BattalionInSectorCount[Assignment.BattalionUID][i % TaamCalendar.ChunksCount]++;
                            }
                        }
                    }

                    for (int i = 0; i < BattalionInSectorCount.Length; i++)
                    {
                        string strRow = string.Format("b" + (i < 10 ? "0" + i : i + ""));
                        string strRotations = "";

                        for (int j = 1; j < BattalionInSectorCount.Length; j++)
                        {

                        }
                        foreach (var RotationPair in BattalionInSectorCount[i])
                        {
                            strRotations += "r" + RotationPair.Key + ": " + RotationPair.Value + ", ";
                        }

                        strRow += ";   " + strRotations;
                        g.DrawString(strRow, f, b, 0, yCounter);
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

            this.cbSingleTargetGenome.CheckState = GlobalConfiguration.SingleTargetGenome ? CheckState.Checked : CheckState.Unchecked;
            this.cbSingleTargetGenome.Tag = GlobalConfiguration.GetDelegate("SingleTargetGenome");
            
            #endregion

            #region Game Settings

            #region General

            this.tbFriendlyCount.Value = GlobalConfiguration.GameSettings.FriendlyCount;
            this.tbFriendlyCount.Tag = GlobalConfiguration.GetDelegate("FriendlyCount");

            this.tbEnemyCount.Value = GlobalConfiguration.GameSettings.EnemyCount;
            this.tbEnemyCount.Tag = GlobalConfiguration.GetDelegate("EnemyCount");

            this.nmGridSize.Value = GlobalConfiguration.GameSettings.GridSize;
            this.nmGridSize.Tag = GlobalConfiguration.GetDelegate("GridSize");

            #endregion

            #region DeadCount

            this.nmMaxDamage.Value = (decimal)GlobalConfiguration.GameSettings.MaxDamage;
            this.nmMaxDamage.Tag = GlobalConfiguration.GetDelegate("MaxDamage");

            this.nmMinDamage.Value = (decimal)GlobalConfiguration.GameSettings.MinDamage;
            this.nmMinDamage.Tag = GlobalConfiguration.GetDelegate("MinDamage");

            this.nmMaxRadius.Value = GlobalConfiguration.GameSettings.MaxRadius;
            this.nmMaxRadius.Tag = GlobalConfiguration.GetDelegate("MaxRadius");

            this.nmMinRadius.Value = GlobalConfiguration.GameSettings.MinRadius;
            this.nmMinRadius.Tag = GlobalConfiguration.GetDelegate("MinRadius");

            this.nmMaxAmmunition.Value = GlobalConfiguration.GameSettings.MaxAmmunition;
            this.nmMaxAmmunition.Tag = GlobalConfiguration.GetDelegate("MaxAmmunition");

            this.nmMinAmmunition.Value = GlobalConfiguration.GameSettings.MinAmmunition;
            this.nmMinAmmunition.Tag = GlobalConfiguration.GetDelegate("MinAmmunition");

            this.nmMinAccuracyForShot.Value = (decimal)GlobalConfiguration.GameSettings.MinAccuracyForShot;
            this.nmMinAccuracyForShot.Tag = GlobalConfiguration.GetDelegate("MinAccuracyForShot");

            this.nmMaxAccuracyForShot.Value = (decimal)GlobalConfiguration.GameSettings.MaxAccuracyForShot;
            this.nmMaxAccuracyForShot.Tag = GlobalConfiguration.GetDelegate("MaxAccuracyForShot");

            #endregion

            #region Price

            this.nmMaxPricePerShot.Value = GlobalConfiguration.GameSettings.MaxPricePerShot;
            this.nmMaxPricePerShot.Tag = GlobalConfiguration.GetDelegate("MaxPricePerShot");

            this.nmMinPricePerShot.Value = GlobalConfiguration.GameSettings.MinPricePerShot;
            this.nmMinPricePerShot.Tag = GlobalConfiguration.GetDelegate("MinPricePerShot");

            this.nmMaxImportance.Value = GlobalConfiguration.GameSettings.MaxImportance;
            this.nmMaxImportance.Tag = GlobalConfiguration.GetDelegate("MaxImportance");

            this.nmMinImportance.Value = GlobalConfiguration.GameSettings.MinImportance;
            this.nmMinImportance.Tag = GlobalConfiguration.GetDelegate("MinImportance");

            
            #endregion

            #region Weights

            this.nmDeadCountWeight.Value = (decimal)GlobalConfiguration.GameSettings.DeadCountWeight;
            this.nmDeadCountWeight.Tag = GlobalConfiguration.GetDelegate("DeadCountWeight");

            this.nmPriceWeight.Value = (decimal)GlobalConfiguration.GameSettings.PriceWeight;
            this.nmPriceWeight.Tag = GlobalConfiguration.GetDelegate("PriceWeight");

            this.nmImportanceWeight.Value = (decimal)GlobalConfiguration.GameSettings.ImportanceWeight;
            this.nmImportanceWeight.Tag = GlobalConfiguration.GetDelegate("ImportanceWeight");

            #endregion

            #endregion

            #region Performances

            this.nmThreadBulkSize.Value = GlobalConfiguration.Performances.ThreadBulkSize;
            this.nmThreadBulkSize.Tag = GlobalConfiguration.GetDelegate("ThreadBulkSize");

            this.cbFixedStrategy.CheckState = GlobalConfiguration.Performances.FixedStrategy ? CheckState.Checked : CheckState.Unchecked;
            this.cbFixedStrategy.Tag = GlobalConfiguration.GetDelegate("FixedStrategy");
            
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

        private void nmGridSize_ValueChanged(object sender, EventArgs e)
        {
            GlobalConfiguration.GameSettings.GridSize = (int)((NumericUpDown)sender).Value;
            if (IsStarted)
            {
                this.Terrain = new CMap(GlobalConfiguration.GameSettings.GridSize, 100);
                this.Restrategize();
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
