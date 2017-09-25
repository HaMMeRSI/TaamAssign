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
        public God PopGen { get; set; }
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
            this.Strategy = new TargetingStrategy(3, 7);
            this.TransformOrigin = new Point2D(-this.Strategy.Terrain.GetWidth() / 2, -this.Strategy.Terrain.GetHeight() / 2);
        }

        private void pnlView_Paint(object sender, PaintEventArgs e)
        {
            if (this.PopGen?.BestFitness != null)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.TranslateTransform(pnlView.Width / 2, pnlView.Height / 2);
                e.Graphics.ScaleTransform(this.TScale, this.TScale);
                e.Graphics.RotateTransform(this.Angle);
                e.Graphics.TranslateTransform((float)this.TransformOrigin.X, (float)this.TransformOrigin.Y);

                this.Strategy.Draw(e.Graphics);
                ((CWorld)this.PopGen.BestFitness).Draw(e.Graphics);

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
        }

        private void pnlView_MouseMove(object sender, MouseEventArgs e)
        {
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

        private void btnGeneratePopulation_Click(object sender, EventArgs e)
        {
            int cycles = Convert.ToInt32(this.numCycles.Value);

            for (int i = 0; i < cycles; i++)
            {
                this.PopGen.GeneratePopulation();
            }

            this.lblGenerationCount.Text = "Curr gen count: " + this.PopGen.GenerationCount;
            this.lblAverageFitness.Text = "Average fitness: " + this.PopGen.AvreageFitness;
            this.lblBestFitness.Text = "Best Fitness: " + this.PopGen.BestFitness.GetFitnesss();
            this.pnlView.Refresh();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.PopGen = new God(20, () => new CWorld(Strategy));
            this.btnGeneratePopulation.Enabled = true;
            this.btnStart.Text = "Restart!";

            this.lblGenerationCount.Text = "Curr gen count: " + this.PopGen.GenerationCount;
            this.lblAverageFitness.Text = "Average fitness: " + this.PopGen.AvreageFitness;
            this.lblBestFitness.Text = "Best Fitness: " + this.PopGen.BestFitness.GetFitnesss();
            this.pnlView.Refresh();
        }
    }
}
