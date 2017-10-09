using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryLogic
{
    public class RandomByRange<T> where T: class
    {
        private List<Tuple<double, T>> MyRange { get; set; }

        public RandomByRange()
        {
            this.MyRange = new List<Tuple<double, T>>();
        }

        public void AddToRange(double fValue, T Entity, Func<double, double> funcOptimaizer)
        {
            double dLastItem = 0;
            if (this.MyRange.Count > 0)
            {
                dLastItem = this.MyRange[this.MyRange.Count - 1].Item1;
            }

            Tuple<double, T> item = new Tuple<double, T>(dLastItem + funcOptimaizer(fValue), Entity);
            this.MyRange.Add(item);
        }

        public T PickFromRange()
        {
            int nSelectend = Shared.Next((int)this.MyRange[this.MyRange.Count - 1].Item1);
            int i = 0;

            while (nSelectend >= this.MyRange[i].Item1)
            {
                i++;
            }

            return this.MyRange[i].Item2;
        }
    }
}
