using EvolutionaryLogic;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaamLogics
{
    public class CTaamAssignment : DNA<DNASubSequence>
    {
        public BattalionAssigner MyAssigner { get; set; }

        public CTaamAssignment() : base(CStrategyPool.ActiveStrategy.GetSectorsCount())
        {
            this.MyAssigner = new BattalionAssigner();

            for (int i = 0; i < CStrategyPool.ActiveStrategy.GetSectorsCount(); i++)
            {
                this[i] = new DNASubSequence(CStrategyPool.ActiveStrategy.SectorsData[i].UID, this.MyAssigner);
            }
        }

        public override void Execute()
        {
            foreach (var DNASequence in this.Genes)
            {
                DNASequence.Execute();
            }
        }

        public override void CalculateFitness()
        {
            float TotalAsssignmentScore = 0;
            float BadScore = (float)this.MyAssigner.GetAssignmentScore(1) / CStrategyPool.ActiveStrategy.GetBattalionsCount();

            foreach (var Sequence in this.Genes)
            {
                Sequence.CalculateFitness();
                TotalAsssignmentScore += Sequence.Fitness;
            }

            this.Fitness = (TotalAsssignmentScore / this.Genes.Length + BadScore) / 2;
        }

        public override IDNA Clone()
        {
            CTaamAssignment Copy = new CTaamAssignment();
            Copy.Fitness = this.Fitness;
            for (int i = 0; i < this.Genes.Length; i++)
            {
                Copy[i] = this[i].Clone() as DNASubSequence;
            }

            return Copy;
        }

        public override IDNA Crossover(IDNA objPartner)
        {
            CTaamAssignment Child = new CTaamAssignment();
            for (int i = 0; i < CStrategyPool.ActiveStrategy.GetSectorsCount(); i++)
            {
                CTaamAssignment Selected = Shared.Coin() ? this : objPartner as CTaamAssignment;
                Child[i] = Selected[i].Clone() as DNASubSequence;
            }

            return Child;
        }

        public override IDNA Revive()
        {
            throw new NotImplementedException();
        }

        public override bool Mutate()
        {
            bool Mutated = false;

            for (int i = 0; i < CStrategyPool.ActiveStrategy.GetSectorsCount(); i++)
            {
                Mutated = this[i].Mutate() || Mutated;
            }

            if (Mutated)
            {
                this.Execute();
            }

            return Mutated;
        }
    }
}
