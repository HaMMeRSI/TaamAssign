using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationLogics
{
    public class Particle
    {
        public IDNA DNA { get; set; }
        public IDNA PBest { get; set; }
        public int[] Velocity { get; set; }
        public float Fitness
        {
            get
            {
                return this.DNA.GetFitnesss();
            }
        }

        public Particle(Func<IDNA> GetDNA)
        {
            this.DNA = GetDNA();
            //this.Velocity = new int[this.DNA]
        }

        public void Execute()
        {
            this.DNA.Execute();
        }

        public void CalculateFitness()
        {
            this.DNA.CalculateFitness();
        }
    }
}
