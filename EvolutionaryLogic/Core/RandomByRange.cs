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
        private List<Tuple<int, T>> MyRange { get; set; }

        public RandomByRange()
        {
            this.MyRange = new List<Tuple<int, T>>();
        }

        public void AddToRange(int fValue, T Entity)
        {
            int nLastCount = 0;
            if (this.MyRange.Count > 0)
            {
                nLastCount = this.MyRange[this.MyRange.Count - 1].Item1;
            }

            Tuple<int, T> item = new Tuple<int, T>(nLastCount + fValue, Entity);
            this.MyRange.Add(item);
        }

        public void AddToRange(int fValue, T Entity, Func<int, int> funcOptimaizer)
        {
            int nLastCount = 0;
            if (this.MyRange.Count > 0)
            {
                nLastCount = this.MyRange[this.MyRange.Count - 1].Item1;
            }

            Tuple<int, T> item = new Tuple<int, T>(nLastCount + funcOptimaizer(fValue), Entity);
            this.MyRange.Add(item);
        }

        public T PickFromRange()
        {
            int nSelectend = Shared.Next(this.MyRange[this.MyRange.Count - 1].Item1);
            for (int i = 0; i < this.MyRange.Count; i++)
            {
                if(nSelectend <= this.MyRange[i].Item1)
                {
                    return this.MyRange[i].Item2;
                }
            }

            return null;
        }
    }
}
