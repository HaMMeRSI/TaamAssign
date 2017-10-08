using EvolutionaryLogic;
using Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TargetLogics;

namespace GeneticTargeting
{
    public partial class Form1 : Form
    {
        public static God PopGen { get; set; }
        public TargetingStrategy Strategy { get; set; }
        public bool IsStarted { get; set; }

        public Form1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.Strategy = new TargetingStrategy(GlobalConfiguration.GameSettings.FriendlyCount, GlobalConfiguration.GameSettings.EnemyCount);

            this.ipStrategy.TransformOrigin = new Point2D(-this.Strategy.Terrain.GetWidth() / 2, -this.Strategy.Terrain.GetHeight() / 2);
            this.ipStrategy.DrawFunction = (g) =>
            {
                if (PopGen?.BestFitness != null)
                {
                    this.Strategy.Draw(g);
                    //((CWorld)PopGen.BestFitness).Draw(g);
                }
            };

            this.ipStrategy.UpdateFunction = () => this.Strategy.Update();

            this.ipStatus.DrawFunction = (g) =>
            {
                PopGen?.StatusGraph.Draw(g);
            };

            this.initConfigDelegation();
        }

        public void initConfigDelegation()
        {
            #region Genetic Configuration

            this.tbPopulationSize.Tag = GlobalConfiguration.GetDelegate("PopulationCount");
            this.tbPopulationSize.Value = GlobalConfiguration.PopulationCount;

            this.tbMutationChance.Tag = GlobalConfiguration.GetDelegate("MutationChance");
            this.tbMutationChance.Value = (decimal)GlobalConfiguration.MutationChance;

            this.tbParentChance.Tag = GlobalConfiguration.GetDelegate("ParentChance");
            this.tbParentChance.Value = (decimal)GlobalConfiguration.ParentChance;

            this.cbApplyElitist.Tag = GlobalConfiguration.GetDelegate("ApplyElitist");
            this.cbApplyElitist.CheckState = GlobalConfiguration.ApplyElitist ? CheckState.Checked : CheckState.Unchecked;

            this.cbApplyNaturalSelection.Tag = GlobalConfiguration.GetDelegate("ApplyNaturalSelection");
            this.cbApplyNaturalSelection.CheckState = GlobalConfiguration.ApplyNaturalSelection ? CheckState.Checked : CheckState.Unchecked;

            this.cbPartialGenomCrossover.Tag = GlobalConfiguration.GetDelegate("PartialGenomCrossover");
            this.cbPartialGenomCrossover.CheckState = GlobalConfiguration.PartialGenomCrossover ? CheckState.Checked : CheckState.Unchecked;
            
            #endregion

            #region Game Settings

            #region General

            this.tbFriendlyCount.Tag = GlobalConfiguration.GetDelegate("FriendlyCount");
            this.tbFriendlyCount.Value = GlobalConfiguration.GameSettings.FriendlyCount;

            this.tbEnemyCount.Tag = GlobalConfiguration.GetDelegate("EnemyCount");
            this.tbEnemyCount.Value = GlobalConfiguration.GameSettings.EnemyCount;

            this.nmGridSize.Tag = GlobalConfiguration.GetDelegate("GridSize");
            this.nmGridSize.Value = GlobalConfiguration.GameSettings.GridSize;

            #endregion

            #region DeadCount

            this.nmMaxDamage.Tag = GlobalConfiguration.GetDelegate("MaxDamage");
            this.nmMaxDamage.Value = (decimal)GlobalConfiguration.GameSettings.MaxDamage;

            this.nmMinDamage.Tag = GlobalConfiguration.GetDelegate("MinDamage");
            this.nmMinDamage.Value = (decimal)GlobalConfiguration.GameSettings.MinDamage;

            this.nmMaxRadius.Tag = GlobalConfiguration.GetDelegate("MaxRadius");
            this.nmMaxRadius.Value = GlobalConfiguration.GameSettings.MaxRadius;

            this.nmMinRadius.Tag = GlobalConfiguration.GetDelegate("MinRadius");
            this.nmMinRadius.Value = GlobalConfiguration.GameSettings.MinRadius;

            this.nmMaxAmmunition.Tag = GlobalConfiguration.GetDelegate("MaxAmmunition");
            this.nmMaxAmmunition.Value = GlobalConfiguration.GameSettings.MaxAmmunition;

            this.nmMinAmmunition.Tag = GlobalConfiguration.GetDelegate("MinAmmunition");
            this.nmMinAmmunition.Value = GlobalConfiguration.GameSettings.MinAmmunition;

            this.nmMinAccuracyForShot.Tag = GlobalConfiguration.GetDelegate("MinAccuracyForShot");
            this.nmMinAccuracyForShot.Value = (decimal)GlobalConfiguration.GameSettings.MinAccuracyForShot;

            this.nmMaxAccuracyForShot.Tag = GlobalConfiguration.GetDelegate("MaxAccuracyForShot");
            this.nmMaxAccuracyForShot.Value = (decimal)GlobalConfiguration.GameSettings.MaxAccuracyForShot;

            #endregion

            #region Price

            this.nmMaxPricePerShot.Tag = GlobalConfiguration.GetDelegate("MaxPricePerShot");
            this.nmMaxPricePerShot.Value = GlobalConfiguration.GameSettings.MaxPricePerShot;

            this.nmMinPricePerShot.Tag = GlobalConfiguration.GetDelegate("MinPricePerShot");
            this.nmMinPricePerShot.Value = GlobalConfiguration.GameSettings.MinPricePerShot;

            this.nmMaxImportance.Tag = GlobalConfiguration.GetDelegate("MaxImportance");
            this.nmMaxImportance.Value = GlobalConfiguration.GameSettings.MaxImportance;

            this.nmMinImportance.Tag = GlobalConfiguration.GetDelegate("MinImportance");
            this.nmMinImportance.Value = GlobalConfiguration.GameSettings.MinImportance;

            
            #endregion

            #region Weights

            this.nmDeadCountWeight.Tag = GlobalConfiguration.GetDelegate("DeadCountWeight");
            this.nmDeadCountWeight.Value = (decimal)GlobalConfiguration.GameSettings.DeadCountWeight;

            this.nmPriceWeight.Tag = GlobalConfiguration.GetDelegate("PriceWeight");
            this.nmPriceWeight.Value = (decimal)GlobalConfiguration.GameSettings.PriceWeight;

            this.nmImportanceWeight.Tag = GlobalConfiguration.GetDelegate("ImportanceWeight");
            this.nmImportanceWeight.Value = (decimal)GlobalConfiguration.GameSettings.ImportanceWeight;

            #endregion

            #endregion
        }

        private async void btnGeneratePopulation_Click(object sender, EventArgs e)
        {
            int cycles = Convert.ToInt32(this.numCycles.Value);

            Progress<IDNA> progress = new Progress<IDNA>(world => {
                Strategy.BestFitness = (CWorld)world;
                this.UpdateBestFitnessLabels();
                this.ipStatus.TransformOrigin.X = -PopGen.StatusGraph.GetWidth();
                this.ipStatus.TransformOrigin.Y = -PopGen.StatusGraph.GetHeight();
            });

            this.btnGeneratePopulation.Enabled = false;
            this.btnRestrategize.Enabled = false;
            this.btnStart.Enabled = false;

            //int n = 3;
            //Task[] tasks = new Task[n];
            //for (int i = 0; i < n; i++)
            //{
            //    tasks[i] = Task.Factory.StartNew(() => PopGen.GeneratePopulation(cycles, progress), TaskCreationOptions.LongRunning);
            //}

            //await Task.WhenAll(tasks);
            await Task.Factory.StartNew(() => PopGen.GeneratePopulation(cycles, progress), TaskCreationOptions.LongRunning);

            this.btnGeneratePopulation.Enabled = true;
            this.btnRestrategize.Enabled = true;
            this.btnStart.Enabled = true;

            this.UpdateBestFitnessLabels();
            this.ipStrategy.Refresh();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.IsStarted = true;
            PopGen = new God(() => new CWorld(Strategy));
            Strategy.BestFitness = (CWorld)PopGen.BestFitness;
            this.btnGeneratePopulation.Enabled = true;
            this.btnRestrategize.Enabled = true;
            this.btnStart.Text = "Restart!";

            this.UpdateBestFitnessLabels();
            this.ipStrategy.Refresh();
        }

        private void btnRestrategize_Click(object sender, EventArgs e)
        {
            this.Restrategize();
        }


        private void Restrategize()
        {
            this.Strategy = new TargetingStrategy(GlobalConfiguration.GameSettings.FriendlyCount, GlobalConfiguration.GameSettings.EnemyCount);
            PopGen = new God(() => new CWorld(Strategy));
            Strategy.BestFitness = (CWorld)PopGen.BestFitness;
            this.btnGeneratePopulation.Enabled = true;
            this.btnStart.Text = "Restart!";

            this.UpdateBestFitnessLabels();
            this.ipStrategy.Refresh();
        }

        private void UpdateBestFitnessLabels()
        {
            this.lblGenerationCount.Text = "Curr gen count: " + PopGen.GenerationCount;
            this.lblAverageFitness.Text = "Average fitness: " + PopGen.AvreageFitness;
            this.lblBestFitness.Text = "Best Fitness: " + PopGen.BestFitness.GetFitnesss();
            this.lblBestDeadCount.Text = "Best dead count: " + ((CWorld)PopGen.BestFitness).DeadCount;
            this.lblBestTotalPrice.Text = "Best total price: " + ((CWorld)PopGen.BestFitness).TotalAttackPrice;
            this.lblTotalImportance.Text = "Best total importance: " + ((CWorld)PopGen.BestFitness).TotalAttackImportance;
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
