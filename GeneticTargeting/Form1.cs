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

        public float TScale { get; set; }
        public bool IsLeftMouseDown { get; set; }
        public bool IsRightMouseDown { get; set; }
        public Point2D MouseDownLocation { get; set; }
        public Point2D TransformOrigin { get; set; }
        public float Angle { get; set; }

        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, this.pnlView, new object[] { true });

            this.DoubleBuffered = true;
            this.TScale = ((float)this.tbScale.Value) / 25;
            this.Angle = 0;
            this.Strategy = new TargetingStrategy(GlobalConfiguration.GameSettings.FriendlyCount, GlobalConfiguration.GameSettings.EnemyCount);
            this.lblAmmo.Text += this.Strategy.FriendliesTotalAmmunition;
            this.TransformOrigin = new Point2D(-this.Strategy.Terrain.GetWidth() / 2, -this.Strategy.Terrain.GetHeight() / 2);

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

            #endregion

            #region Game Settings

            #region General

            this.tbFriendlyCount.Tag = GlobalConfiguration.GetDelegate("FriendlyCount");
            this.tbFriendlyCount.Value = GlobalConfiguration.GameSettings.FriendlyCount;

            this.tbEnemyCount.Tag = GlobalConfiguration.GetDelegate("EnemyCount");
            this.tbEnemyCount.Value = GlobalConfiguration.GameSettings.EnemyCount;

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

            this.nmDeadCountWeight.Tag = GlobalConfiguration.GetDelegate("DeadCountWeight");
            this.nmDeadCountWeight.Value = (decimal)GlobalConfiguration.GameSettings.DeadCountWeight;

            #endregion

            #region Price

            this.nmMaxPricePerShot.Tag = GlobalConfiguration.GetDelegate("MaxPricePerShot");
            this.nmMaxPricePerShot.Value = GlobalConfiguration.GameSettings.MaxPricePerShot;

            this.nmMinPricePerShot.Tag = GlobalConfiguration.GetDelegate("MinPricePerShot");
            this.nmMinPricePerShot.Value = GlobalConfiguration.GameSettings.MinPricePerShot;

            this.nmPriceWeight.Tag = GlobalConfiguration.GetDelegate("PriceWeight");
            this.nmPriceWeight.Value = (decimal)GlobalConfiguration.GameSettings.PriceWeight;

            #endregion
            #endregion
        }

        private void pnlView_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Silver);
            if (PopGen?.BestFitness != null)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.TranslateTransform(pnlView.Width / 2, pnlView.Height / 2);
                e.Graphics.ScaleTransform(this.TScale, this.TScale);
                e.Graphics.RotateTransform(this.Angle);
                e.Graphics.TranslateTransform((float)this.TransformOrigin.X, (float)this.TransformOrigin.Y);

                this.Strategy.Draw(e.Graphics);
                ((CWorld)PopGen.BestFitness).Draw(e.Graphics);
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), new Rectangle(Shared.MouseLocation, new Size(3, 3)));
                e.Graphics.RotateTransform(0);
            }

            e.Graphics.ResetTransform();
        }

        #region Annoying events

        private void tbScale_Scroll(object sender, EventArgs e)
        {
            this.TScale = ((float)this.tbScale.Value) / 25;
            this.pnlView.Refresh();
        }

        private void pnlView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.IsLeftMouseDown = true;
                this.MouseDownLocation = (Point2D)e.Location;
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.IsRightMouseDown = true;
                this.MouseDownLocation = (Point2D)e.Location;
            }
            else if (e.Button == MouseButtons.Middle)
            {
                ((CWorld)PopGen.BestFitness).Update();
                this.pnlView.Refresh();
            }
        }

        private void pnlView_MouseMove(object sender, MouseEventArgs e)
        {
            Shared.MouseLocation.X = e.Location.X / this.TScale - (this.TransformOrigin.X + this.pnlView.Width / this.TScale / 2);
            Shared.MouseLocation.Y = e.Location.Y / this.TScale - (this.TransformOrigin.Y + this.pnlView.Height / this.TScale / 2);

            if (this.IsLeftMouseDown)
            {
                this.TransformOrigin.X += (e.X - this.MouseDownLocation.X) / this.TScale;
                this.TransformOrigin.Y += (e.Y - this.MouseDownLocation.Y) / this.TScale;
                this.MouseDownLocation = (Point2D)e.Location;
                this.pnlView.Refresh();
            }
            else if (this.IsRightMouseDown)
            {
                if (e.Location.Y > this.MouseDownLocation.Y)
                {
                    this.Angle += 10;
                }
                else
                {
                    this.Angle -= 10;
                }
                this.pnlView.Refresh();
            }
        }

        private void pnlView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.IsLeftMouseDown = false;
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.IsRightMouseDown = false;
            }
        }

        #endregion

        private async void btnGeneratePopulation_Click(object sender, EventArgs e)
        {
            int cycles = Convert.ToInt32(this.numCycles.Value);

            Progress<string> progress = new Progress<string>(s => {
                this.UpdateBestFitnessLabels();
            });

            this.btnGeneratePopulation.Enabled = false;
            this.btnRestrategize.Enabled = false;
            this.btnStart.Enabled = false;

            await Task.Factory.StartNew(() => PopGen.GeneratePopulation(cycles, progress),TaskCreationOptions.LongRunning);

            this.btnGeneratePopulation.Enabled = true;
            this.btnRestrategize.Enabled = true;
            this.btnStart.Enabled = true;

            this.UpdateBestFitnessLabels();
            this.pnlView.Refresh();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            PopGen = new God(() => new CWorld(Strategy));
            this.btnGeneratePopulation.Enabled = true;
            this.btnRestrategize.Enabled = true;
            this.btnStart.Text = "Restart!";

            this.UpdateBestFitnessLabels();
            this.pnlView.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.pnlView.Refresh();
        }

        private void btnRestrategize_Click(object sender, EventArgs e)
        {
            this.Strategy = new TargetingStrategy(GlobalConfiguration.GameSettings.FriendlyCount, GlobalConfiguration.GameSettings.EnemyCount);
            PopGen = new God(() => new CWorld(Strategy));
            this.btnGeneratePopulation.Enabled = true;
            this.btnStart.Text = "Restart!";

            this.UpdateBestFitnessLabels();
            this.pnlView.Refresh();
        }

        private void UpdateBestFitnessLabels()
        {
            this.lblGenerationCount.Text = "Curr gen count: " + PopGen.GenerationCount;
            this.lblAverageFitness.Text = "Average fitness: " + PopGen.AvreageFitness;
            this.lblBestFitness.Text = "Best Fitness: " + PopGen.BestFitness.GetFitnesss();
            this.lblBestDeadCount.Text = "Best dead count: " + ((CWorld)PopGen.BestFitness).DeadCount;
            this.lblBestTotalPrice.Text = "Best total price: " + ((CWorld)PopGen.BestFitness).TotalAttackPrice;
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
    }
}
