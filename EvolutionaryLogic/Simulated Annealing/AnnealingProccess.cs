using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationLogics
{
    public class AnnealingProccess<T>
    {
        public IDNA<T> BestFitness { get; set; }
        public CStatutsGraph StatusGraph { get; set; }
        public double Temperature { get; set; }

        public AnnealingProccess(Func<IDNA<T>> GetDNA)
        {
            this.StatusGraph = new CStatutsGraph();
            this.BestFitness = GetDNA();
            this.BestFitness.Execute();
            this.BestFitness.CalculateFitness();
        }

        public void MultiAnneal(int Instances)
        {
            if (Instances == 1)
            {
                this.SingleAnneal();
            }
            else
            {
                Task<IDNA<T>>[] AnnealingInstances = new Task<IDNA<T>>[Instances];

                for (int i = 0; i < Instances; i++)
                {
                    AnnealingInstances[i] = Task.Factory.StartNew(() => this.Anneal(this.BestFitness.Clone()), TaskCreationOptions.None);
                }

                Task.WaitAll(AnnealingInstances);

                for (int i = 0; i < Instances; i++)
                {
                    if (AnnealingInstances[i].Result.GetFitnesss() > this.BestFitness.GetFitnesss())
                    {
                        this.BestFitness = AnnealingInstances[i].Result;
                    }
                }
            }
        }

        public IDNA<T> Anneal(IDNA<T> Initial)
        {
            double InstanceTempature = GlobalConfiguration.InitialTempature;
            Random rnd = new Random((int)DateTime.Now.Ticks);
            IDNA<T> CurrentIterator = Initial.Clone();
            IDNA<T> InstanceBest = Initial.Clone();

            while (InstanceTempature > 1)
            {
                IDNA<T> Neighbour = CurrentIterator.Clone();
                Neighbour.Mutate(rnd);
                Neighbour.CalculateFitness();

                double probability = AcceptanceProbability(1 / CurrentIterator.GetFitnesss() * 100000, 1 / Neighbour.GetFitnesss() * 100000, InstanceTempature);
                if (Shared.HitChance(rnd, probability))
                {
                    CurrentIterator = Neighbour;
                }

                if (BestFitness.GetFitnesss() < Neighbour.GetFitnesss())
                {
                    InstanceBest = CurrentIterator;
                }

                InstanceTempature *= 1 - GlobalConfiguration.TempatureDecay;
            }

            return InstanceBest;
        }

        public void SingleAnneal()
        {
            IDNA<T> CurrentIterator = this.BestFitness.Clone();
            this.BestFitness = this.BestFitness.Clone();
            this.StatusGraph.ClearHistory();
            this.StatusGraph.Average = 0;
            this.Temperature = GlobalConfiguration.InitialTempature;

            while (this.Temperature > 1)
            {
                IDNA<T> Neighbour = CurrentIterator.Clone();
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
                this.Temperature *= 1 - GlobalConfiguration.TempatureDecay;
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
