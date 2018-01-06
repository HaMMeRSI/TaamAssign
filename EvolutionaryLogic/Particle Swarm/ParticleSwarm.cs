using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationLogics
{
    public class ParticleSwarm<T>
    {
        public Particle<T> BestParticle { get; set; }
        public Particle<T>[] Particles { get; set; }
        public CStatutsGraph StatusGraph { get; set; }

        public ParticleSwarm(Func<IDNA<T>> GetDNA)
        {
            this.StatusGraph = new CStatutsGraph();

            this.Particles[0] = new Particle<T>(GetDNA);
            this.BestParticle = this.Particles[0];
            this.BestParticle.Execute();
            this.BestParticle.CalculateFitness();


            for (int i = 1; i < this.Particles.Length; i++)
            {
                this.Particles[i] = new Particle<T>(GetDNA);
                this.Particles[i].Execute();
                this.Particles[i].CalculateFitness();

                if(this.Particles[i].Fitness > this.BestParticle.Fitness)
                {
                    this.BestParticle = this.Particles[i];
                }
            }
        }

        public void Search()
        {
            Random rnd = new Random();

            int omega = 1;
            int LearnRate1 = 2, LearnRate2 = 2;

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < this.Particles.Length; j++)
                {
                    for (int d = 0; d < this.Particles[j].Velocity.Length; d++)
                    {
                        double Rp = rnd.NextDouble();
                        double Rb = rnd.NextDouble();
                        //this.Particles[i].Velocity[d] = omega * this.Particles[i].Velocity[d] + LearnRate1 * Rp (this.Particles[i].PBest.GetGenes()[d] - this.Particles[i].DNA.GetG)
                    }
                    // this.Particles[i].DNA = ;
                    // this.Particles[i].Velocity = ;
                }
            }
        }
    }
}
