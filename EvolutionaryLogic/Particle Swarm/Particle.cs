using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationLogics
{
    public class Particle<T>
    {
        public IDNA<T> DNA { get; set; }
        public IDNA<T> PBest { get; set; }
        public int[] Velocity { get; set; }
        public float Fitness
        {
            get
            {
                return this.DNA.GetFitnesss();
            }
        }

        public Particle(Func<IDNA<T>> GetDNA)
        {
            this.DNA = GetDNA();
            this.PBest = this.DNA;
            this.Velocity = new int[this.DNA.GetGenes().Length];

            for (int i = 0; i < this.Velocity.Length; i++)
            {
                this.Velocity[i] = 0;
            }
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
