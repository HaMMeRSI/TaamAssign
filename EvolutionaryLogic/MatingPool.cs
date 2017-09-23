using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logics
{
    public class MatingPool
    {
        public RandomByRange<DNA> MyMatingPool { get; set; }

        public MatingPool(List<DNA> Population)
        {
            this.MyMatingPool = new RandomByRange<DNA>();
            for (int i = Population.Count - 1; i >= 0; i--)
            {
                int n = (int)(Population[i].Fitness * 100);
                this.MyMatingPool.AddToRange(n, Population[i], (int item) => item * item);
            }
        }

        public DNA GetChild()
        {
            DNA[] arrParents = this.PickParents();

            return arrParents[0].crossover(arrParents[1]);
        }

        private DNA[] PickParents()
        {
            DNA[] arrParents = new DNA[2];

            //arrParents[0] = this.MyMatingPool[Shared.rnd.Next(this.MyMatingPool.Count)];
            //arrParents[1] = this.MyMatingPool[Shared.rnd.Next(this.MyMatingPool.Count)];

            arrParents[0] = this.MyMatingPool.PickFromRange();
            arrParents[1] = this.MyMatingPool.PickFromRange();

            return arrParents;
        }
    }
}
