using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Point2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point2D(double dX, double dY)
        {
            this.X = dX;
            this.Y = dY;
        }


        public static implicit operator Point(Point2D p)
        {
            return new Point((int)p.X, (int)p.Y);
        }
        public static implicit operator PointF(Point2D p)
        {
            return new PointF((float)p.X, (float)p.Y);
        }
        public static explicit operator Point2D(Point p)
        {
            return new Point2D(p.X, p.Y);
        }
        public static explicit operator Point2D(PointF p)
        {
            return new Point2D(p.X, p.Y);
        }
    }
}
