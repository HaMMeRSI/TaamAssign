using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationLogics
{
    public class PopulationSelector<T>
    {
        MergeSort<T> helper;
        public PopulationSelector()
        {
            helper = new MergeSort<T>();
        }
        public void NaturalSelection(List<IDNA<T>> Population)
        {
            helper.Sort(Population);

            //for (int i = 0; i < Population.Count; i++)
            //{
            //    if (Shared.HitChance(.001))
            //    {
            //        Population.RemoveAt(Shared.Next(Population.Count));
            //    }
            //}

            Population.RemoveRange(0, Population.Count / 2);
        }

        public List<IDNA<T>> AverageSelection(List<IDNA<T>> Population, float Average)
        {
            List<IDNA<T>> NewPop = new List<IDNA<T>>();
            foreach (IDNA<T> dna in Population)
            {
                if(dna.GetFitnesss() > Average)
                {
                    NewPop.Add(dna.Revive());
                }
            }

            return NewPop;
        }
    }
}
