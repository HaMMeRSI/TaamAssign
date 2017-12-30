using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryLogic
{
    public class AnnealingProccess
    {
        public IDNA BestFitness { get; set; }
        public CStatutsGraph StatusGraph { get; set; }
        public double Temperature { get; set; }

        public AnnealingProccess(Func<IDNA> GetDNA)
        {
            this.StatusGraph = new CStatutsGraph();
            this.BestFitness = GetDNA();
            this.BestFitness.Execute();
            this.BestFitness.CalculateFitness();
        }

        public void Anneal(IProgress<IDNA> progress)
        {
            this.Temperature = GlobalConfiguration.InitialTempature;
            this.StatusGraph.ClearHistory();

            IDNA CurrentIterator = this.BestFitness.Clone();

            while (this.Temperature > 0)
            {
                IDNA Neighbour = CurrentIterator.Clone();
                Neighbour.Mutate();
                Neighbour.CalculateFitness();

                double probability = AcceptanceProbability(1 / CurrentIterator.GetFitnesss() * 100000, 1 / Neighbour.GetFitnesss() * 100000, this.Temperature);
                if (Shared.HitChance(probability))
                {
                    CurrentIterator = Neighbour;
                }

                if (BestFitness.GetFitnesss() < Neighbour.GetFitnesss())
                {
                    this.BestFitness = CurrentIterator;
                }

                this.StatusGraph.AddToHistory(CurrentIterator.GetFitnesss());
                this.StatusGraph.Average = 0;

                this.Temperature *= 1 - GlobalConfiguration.TempatureDecay;

                //if(this.Temperature> 1)
                //progress.Report(this.BestFitness);
            }

        }

        public double AcceptanceProbability(float energy, float newEnergy, double temperature)
        {
            // If the new solution is better, accept it
            if (newEnergy < energy)
            {
                return 1.0;
            }

            // If the new solution is worse, calculate an acceptance probability
            return Math.Exp((energy - newEnergy) / temperature);
        }
    }
}
