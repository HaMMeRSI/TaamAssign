using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnealingLogic
{
    public class AnnealingProccess
    {
        public IDNA BestFitness { get; set; }
        public CStatutsGraph StatusGraph { get; set; }
        public double Temperature { get; set; }

        public AnnealingProccess()
        {
            this.StatusGraph = new CStatutsGraph();
        }

        public void Anneal(Func<IDNA> GetSolution, IProgress<IDNA> progress)
        {
            int initialTemp = 1000;
            // Set initial temp
            this.Temperature = initialTemp/2;
            this.StatusGraph.ClearHistory();

            // Cooling rate
            double coolingRate = 0.0001;

            this.BestFitness = GetSolution();
            this.BestFitness.Execute();
            this.BestFitness.CalculateFitness();
            IDNA CurrentIterator = this.BestFitness.Clone();

            while (this.Temperature > 1)
            {
                IDNA Neighbour = CurrentIterator.Clone();
                Neighbour.Mutate();
                Neighbour.CalculateFitness();

                double probability = AcceptanceProbability(1/CurrentIterator.GetFitnesss() * (initialTemp*20), 1/Neighbour.GetFitnesss() * (initialTemp*20), this.Temperature);
                if (Shared.HitChance(probability))
                {
                    CurrentIterator = Neighbour;
                }

                if(BestFitness.GetFitnesss() < Neighbour.GetFitnesss())
                {
                    this.BestFitness = CurrentIterator;
                }

                this.StatusGraph.AddToHistory(CurrentIterator.GetFitnesss());
                this.StatusGraph.Average = 0;

                this.Temperature *= 1 - coolingRate;

                progress.Report(this.BestFitness);
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
