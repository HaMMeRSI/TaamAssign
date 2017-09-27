using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryLogic
{
    public class MatingPool
    {
        public RandomByRange<IDNA> MyMatingPool { get; set; }

        public MatingPool(List<IDNA> Population)
        {
            this.MyMatingPool = new RandomByRange<IDNA>();
            for (int i = Population.Count - 1; i >= 0; i--)
            {
                int n = (int)(Population[i].GetFitnesss() * 100);
                if (n == 0)
                {
                    n = Shared.Next(100);
                }
                this.MyMatingPool.AddToRange(n, Population[i], (int item) => item * item);
            }
        }

        public IDNA GetChild()
        {
            IDNA[] arrParents = this.PickParents();

            return arrParents[0].Crossover(arrParents[1]);
        }

        private IDNA[] PickParents()
        {
            IDNA[] arrParents = new IDNA[2];

            //arrParents[0] = this.MyMatingPool[Shared.rnd.Next(this.MyMatingPool.Count)];
            //arrParents[1] = this.MyMatingPool[Shared.rnd.Next(this.MyMatingPool.Count)];

            arrParents[0] = this.MyMatingPool.PickFromRange();
            arrParents[1] = this.MyMatingPool.PickFromRange();

            return arrParents;
        }
    }
}
