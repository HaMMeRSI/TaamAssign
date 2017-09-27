using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryLogic
{
    public abstract class DNA<T>: IDNA
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

        public float GetFitnesss()
        {
            return this.Fitness;
        }

        public abstract IDNA Crossover(IDNA objPartner);

        public override string ToString()
        {
            return this.Fitness.ToString(); // new string(this.genes) + " - " + this.Fitness;
        }

        public virtual void Execute()
        {

        }

        public abstract void CalculateFitness();
        protected abstract void Mutate();
        public abstract IDNA CreateChild();
        public abstract void ResetForNewGeneration();
    }
}
