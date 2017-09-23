using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logics
{
    public class PopulationSelector
    {
        public void NaturalSelection(List<DNA> Population)
        {
            MergeSort.Sort(Population);

            for (int i = 0; i < Population.Count; i++)
            {
                if (Shared.HitChance(.04))
                {
                    Population.RemoveAt(Shared.Next(Population.Count));
                }
            }

            Population.RemoveRange(0, Population.Count / 2 - 1);
        }
    }
}
