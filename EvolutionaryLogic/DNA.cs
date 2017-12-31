using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationLogics
{
    public abstract class DNA<T>: IDNA<T>
    {
        #region Properties

        public T this[int key]
        {
            get
            {
                return this.Genes[key];
            }
            set
            {
                this.Genes[key] = value;
            }
        }

        protected T[] Genes { get; set; }
        public float Fitness { get; set; }

        #endregion
        public DNA(int nGenesCount)
        {
            this.Genes = new T[nGenesCount];
            this.Fitness = -1;

            // Initiallize genes in apply
        }

        public T[] GetGenes()
        {
            return this.Genes;
        }

        public float GetFitnesss()
        {
            return this.Fitness;
        }

        public abstract IDNA<T> Crossover(IDNA<T> objPartner);

        public override string ToString()
        {
            return this.Fitness.ToString(); // new string(this.genes) + " - " + this.Fitness;
        }

        public virtual void Execute()
        {

        }

        public abstract void CalculateFitness();
        public abstract bool Mutate();
        public abstract bool Mutate(Random rnd);
        public abstract IDNA<T> Clone();
        public abstract IDNA<T> Revive();
    }
}
