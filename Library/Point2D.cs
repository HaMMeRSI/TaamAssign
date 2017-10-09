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
        public double X;
        public double Y;

        public Point2D(double dX, double dY)
        {
            this.X = dX;
            this.Y = dY;
        }

        public Point2D()
        {
            this.X = 0;
            this.Y = 0;
        }

        public Point2D Clone()
        {
            return new Point2D(this.X, this.Y);
        }


        public float Distance(Point2D point)
        {
            return (float)Math.Sqrt(Math.Pow(this.X - point.X, 2) + Math.Pow(this.Y - point.Y, 2));
        }

        public double Dot(Point2D point)
        {
            return (this.X - point.X) * (this.X - point.X) + (this.Y - point.Y) * (this.Y - point.Y);
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

        public override bool Equals(object obj)
        {
            Point2D that = (Point2D)obj;
            return that.X == this.X && that.Y == this.Y;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.X, this.Y);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
