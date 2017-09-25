using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryLogic
{
    public class PopulationSelector
    {
        public void NaturalSelection(List<IDNA> Population)
        {
            MergeSort.Sort(Population);

            for (int i = 0; i < Population.Count; i++)
            {
                if (BaseLogic.HitChance(.04))
                {
                    Population.RemoveAt(BaseLogic.Next(Population.Count));
                }
            }

            Population.RemoveRange(0, Population.Count / 2 - 1);
        }
    }
}
