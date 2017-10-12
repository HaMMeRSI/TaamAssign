using Library;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryLogic
{
    public class MatingPool
    {
        public RandomByRange<IDNA> MyRoulette { get; set; }

        public MatingPool(List<IDNA> Population)
        {
            this.MyRoulette = new RandomByRange<IDNA>();

            for (int i = Population.Count - 1; i >= 0; i--)
            {
                double n = Population[i].GetFitnesss();
                if (n == 0)
                {
                    n = Shared.Next(1);
                }
                Func<double, long> optimizationFunc = (item) => (long)(Math.Pow(item * 100, 3));
                if (GlobalConfiguration.ApplyNaturalSelection)
                {
                    optimizationFunc = (item) => (long)(item * i * i);
                }

                this.MyRoulette.AddToRange(n, Population[i], optimizationFunc);
            }
        }

        public IDNA GetChild()
        {
            IDNA child = null;
            IDNA[] arrParents = this.PickParents();

            if (Shared.HitChance(GlobalConfiguration.ParentChance / 100))
            {
                child = Shared.Coin() ? arrParents[0].Revive() : arrParents[1].Revive();
            }
            else
            {
                child = arrParents[0].Crossover(arrParents[1]);

            }

            return child;
        }

        private IDNA[] PickParents()
        {
            IDNA[] arrParents = new IDNA[2];

            arrParents[0] = this.MyRoulette.PickFromRange();
            arrParents[1] = this.MyRoulette.PickFromRange();

            return arrParents;
        }
    }
}
