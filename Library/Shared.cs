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
    }
}
