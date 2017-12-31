using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationLogics
{
    struct RangeItem<T>
    {
        public T Entity;
        public long Range;

        public override string ToString()
        {
            return Range.ToString();
        }
    }

    public class RandomByRange<T> where T: class
    {
        private List<RangeItem<T>> MyRange { get; set; }

        public RandomByRange()
        {
            this.MyRange = new List<RangeItem<T>>();
        }

        public void AddToRange(double fValue, T Entity, Func<double, long> funcOptimaizer)
        {
            long dLastItem = 0;
            if (this.MyRange.Count > 0)
            {
                dLastItem = this.MyRange[this.MyRange.Count - 1].Range;
            }

            RangeItem<T> item = new RangeItem<T>();
            item.Entity = Entity;
            item.Range = dLastItem + funcOptimaizer(fValue);
            this.MyRange.Add(item);
        }

        public T Pick()
        {
            long nSelectend = Shared.NextLong2(this.MyRange[this.MyRange.Count - 1].Range);
            int i = 0;

            while (nSelectend >= this.MyRange[i].Range)
            {
                i++;
            }

            return this.MyRange[i].Entity;
        }

        public void Clear()
        {
            this.MyRange.Clear();
        }
    }
}
