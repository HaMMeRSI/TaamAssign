using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Shared
    {
        public static Random rnd = new Random();
        public static Point2D MouseLocation = new Point2D(0, 0);

        public static bool Coin()
        {
            return rnd.Next() % 2 == 0;
        }

        public static int Next(int nMax)
        {
            return rnd.Next(0, nMax);
        }

        public static bool HitChance(double fPrecent)
        {
            return rnd.NextDouble() <= fPrecent;
        }

        public static float map(float value, float istart, float istop, float ostart, float ostop)
        {
            return ostart + (ostop - ostart) * ((value - istart) / (istop - istart));
        }

        public static double GetMinMax(double Value, double Min, double Max)
        {
            double tMinMax = Math.Min(Value, Max);
            return Math.Max(tMinMax, Min);
        }
        public static int GetMinMax(int Value, int Min, int Max)
        {
            int tMinMax = Math.Min(Value, Max);
            return Math.Max(tMinMax, Min);

        }
    }
}
