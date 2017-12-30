using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;
using System.Reflection;

namespace TaamAssign
{
    public partial class InteractivePanel : UserControl
    {
        public int ScaleFactor { get; set; }
        private float TScale { get; set; }
        private bool IsLeftMouseDown { get; set; }
        private bool IsRightMouseDown { get; set; }
        private Point2D MouseDownLocation { get; set; }
        public Point2D TransformOrigin { get; set; }
        private float Angle { get; set; }
        public bool CenterDraw { get; set; }
        public Action<Graphics> DrawFunction { get; set; }
        public Action UpdateFunction { get; set; }

        public InteractivePanel()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, this.pnlView, new object[] { true });

            this.DoubleBuffered = true;
            this.ScaleFactor = 25;
            this.TScale = 1;
            this.Angle = 0;
            this.TransformOrigin = new Point2D();
        }

        private void tbScale_Scroll(object sender, EventArgs e)
        {
            this.TScale = ((float)this.tbScale.Value) / this.ScaleFactor;
            this.Refresh();
        }

        private void pnlView_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Silver);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (CenterDraw)
            {
                e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
            }

            e.Graphics.ScaleTransform(this.TScale, this.TScale);
            e.Graphics.RotateTransform(this.Angle);
            e.Graphics.TranslateTransform((float)this.TransformOrigin.X, (float)this.TransformOrigin.Y);

            this.DrawFunction?.Invoke(e.Graphics);

            e.Graphics.FillEllipse(new SolidBrush(Color.Red), new Rectangle(Shared.MouseLocation, new Size(3, 3)));
            e.Graphics.RotateTransform(0);
            e.Graphics.ResetTransform();
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
                this.UpdateFunction?.Invoke();

                this.Refresh();
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

        private void pnlView_MouseMove(object sender, MouseEventArgs e)
        {
            Shared.MouseLocation.X = e.Location.X / this.TScale - (this.TransformOrigin.X + this.Width / this.TScale / 2);
            Shared.MouseLocation.Y = e.Location.Y / this.TScale - (this.TransformOrigin.Y + this.Height / this.TScale / 2);

            if (this.IsLeftMouseDown)
            {
                this.TransformOrigin.X += (e.X - this.MouseDownLocation.X) / this.TScale;
                this.TransformOrigin.Y += (e.Y - this.MouseDownLocation.Y) / this.TScale;
                this.MouseDownLocation = (Point2D)e.Location;
                this.Refresh();
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
                this.Refresh();
            }
        }
    }
}
