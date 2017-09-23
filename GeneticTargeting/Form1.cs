using Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TargetLogics;

namespace GeneticTargeting
{
    public partial class Form1 : Form
    {
        public CWorld World { get; set; }
        public float TScale { get; set; }
        public bool IsLeftMouseDown { get; set; }
        public bool IsRightMouseDown { get; set; }
        public Point2D MouseDownLocation { get; set; }
        public Point2D OldRotationLocation { get; set; }
        public float TranslateRatio { get; set; }
        public float Angle { get; set; }

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.TScale = ((float)this.tbScale.Value) / 25;
            this.Angle = 0;
            this.World = new CWorld();

            if (this.World.MyWorld.GetWidth() > this.World.MyWorld.GetHeight())
            {
                this.TranslateRatio = (float)this.World.MyWorld.GetWidth() / (float)pnlView.Width;
            }
            else
            {
                this.TranslateRatio = (float)this.World.MyWorld.GetHeight() / (float)pnlView.Height;
            }
        }

        private void pnlView_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(pnlView.Width / 2, pnlView.Height / 2);
            e.Graphics.ScaleTransform(this.TScale, this.TScale);
            e.Graphics.RotateTransform(this.Angle);
            e.Graphics.TranslateTransform((float)this.World.Location.X , (float)this.World.Location.Y);

            World.Draw(e.Graphics);
            e.Graphics.RotateTransform(0);
            e.Graphics.ResetTransform();
        }

        private void tbScale_Scroll(object sender, EventArgs e)
        {
            this.TScale = ((float)this.tbScale.Value) / 25;
            this.pnlView.Refresh();
        }

        private void pnlView_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.IsLeftMouseDown = true;
                this.MouseDownLocation = (Point2D)e.Location;
            } 
            else if(e.Button == MouseButtons.Right)
            {
                this.IsRightMouseDown = true;
                this.MouseDownLocation = (Point2D)e.Location;
            }
        }

        private void pnlView_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.IsLeftMouseDown)
            {
                this.World.Location.X += (e.X - this.MouseDownLocation.X) / this.TScale;
                this.World.Location.Y += (e.Y - this.MouseDownLocation.Y) / this.TScale;
                this.MouseDownLocation = (Point2D)e.Location;
                this.pnlView.Refresh();
            }
            else if(this.IsRightMouseDown)
            {
                if(e.Location.Y > this.MouseDownLocation.Y)
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
            else if (e.Button == MouseButtons.Right) {
                this.IsRightMouseDown = false;
            }
        }
    }
}
