using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationLogics
{
    public class ParticleSwarm
    {
        public Particle BestParticle { get; set; }
        public Particle[] Particles { get; set; }
        public CStatutsGraph StatusGraph { get; set; }

        public ParticleSwarm(Func<IDNA> GetDNA)
        {
            this.StatusGraph = new CStatutsGraph();

            this.Particles[0] = new Particle(GetDNA);
            this.BestParticle = this.Particles[0];
            this.BestParticle.Execute();
            this.BestParticle.CalculateFitness();


            for (int i = 1; i < this.Particles.Length; i++)
            {
                this.Particles[i] = new Particle(GetDNA);
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
