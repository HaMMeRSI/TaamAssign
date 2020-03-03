using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnealingLogic
{
    public class PopulationSelector
    {
        MergeSort helper;
        public PopulationSelector()
        {
            helper = new MergeSort();
        }
        public void NaturalSelection(List<IDNA> Population)
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

        public List<IDNA> AverageSelection(List<IDNA> Population, float Average)
        {
            List<IDNA> NewPop = new List<IDNA>();
            foreach (IDNA dna in Population)
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
