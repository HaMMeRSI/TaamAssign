using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logics
{
    public class DNA
    {
        #region Properties

        private char[] genes { get; set; }
        public float Fitness { get; set; }

        private string Mutations = " abcde fghi jklmn opqr stuvw xyz ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        #endregion
        public DNA(int nGenesCount)
        {
            this.genes = new char[nGenesCount];
            this.Fitness = -1;

            for (int i = 0; i < this.genes.Length; i++)
            {
                this.genes[i] = this.getFromMutations();
            }
        }

        public void calcFitness(string target)
        {
            int score = 0;

            for (int i = 0; i < this.genes.Length; i++)
            {
                if(target[i] == this.genes[i])
                {
                    score++;
                }
            }

            this.Fitness = (float)score / target.Length;
        }

        public DNA crossover(DNA partner)
        {
            DNA child = new DNA(this.genes.Length);

            for (int i = 0; i < partner.genes.Length; i++)
            {
                child.genes[i] = Shared.Coin() ? this.genes[i] : partner.genes[i];
            }

            child.mutate();

            return child;
        }

        private void mutate()
        {           
            for (int i = 0; i < this.genes.Length; i++)
            {
                if(Shared.HitChance(.01))
                {
                    this.genes[i] = this.getFromMutations();
                }
            }
        }

        private char getFromMutations()
        {
            return this.Mutations[Shared.Next(this.Mutations.Length)];
        }

        public override string ToString()
        {
            return new string(this.genes) + " - " + this.Fitness;
        }
    }
}
