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
            for (int i = 0; i < this.Particles.Length; i++)
            {
                // this.Particles[i].DNA = ;
                // this.Particles[i].Velocity = ;
            }
        }
    }
}
