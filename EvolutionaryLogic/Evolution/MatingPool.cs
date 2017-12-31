using Library;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationLogics
{
    public class MatingPool<T>
    {
        public RandomByRange<IDNA<T>> MyRoulette { get; set; }

        public MatingPool()
        {
            this.MyRoulette = new RandomByRange<IDNA<T>>();
        }

        public List<IDNA<T>> GetEvolvedPopulation(List<IDNA<T>> Population, int nElitilstCount)
        {
            List<IDNA<T>> NewPop = new List<IDNA<T>>();
            NewPop.AddRange(this.ChooseElitist(Population, nElitilstCount));
            this.InitRoulette(Population);

            for (int j = 0; j < GlobalConfiguration.PopulationCount - nElitilstCount; j++)
            {
                NewPop.Add(this.Crossover());
            }

            return NewPop;
        }

        public IDNA<T> Crossover()
        {
            IDNA<T> child = null;
            IDNA<T>[] arrParents = this.PickParents();

            if (Shared.HitChance(GlobalConfiguration.ParentChance / 100))
            {
                child = Shared.Coin() ? arrParents[0].Revive() : arrParents[1].Revive();
            }
            else
            {
                child = arrParents[0].Crossover(arrParents[1]);
            }

            child.Mutate();

            return child;
        }

        private IDNA<T>[] PickParents()
        {
            IDNA<T>[] arrParents = new IDNA<T>[2];

            arrParents[0] = this.MyRoulette.Pick();
            arrParents[1] = this.MyRoulette.Pick();

            return arrParents;
        }

        private List<IDNA<T>> ChooseElitist(List<IDNA<T>> Population, int nElitistCount)
        {
            List<IDNA<T>> Elitist = new List<IDNA<T>>();
            if (GlobalConfiguration.ApplyElitist)
            {
                if (GlobalConfiguration.ApplyNaturalSelection)
                {
                    for (int j = 0; j < nElitistCount; j++)
                    {
                        Elitist.Add(Population[Population.Count - 1 - j].Revive());
                    }
                }
                else
                {
                    IDNA<T>[] Elitists = new IDNA<T>[nElitistCount];
                    for (int j = 0; j < nElitistCount; j++)
                    {
                        Elitists[j] = Population[j];
                    }

                    for (int j = nElitistCount; j < Population.Count; j++)
                    {
                        for (int k = 0; k < nElitistCount; k++)
                        {
                            if (Population[j].GetFitnesss() > Elitists[k].GetFitnesss())
                            {
                                Elitists[k] = Population[j];
                                break;
                            }
                        }
                    }

                    for (int j = 0; j < nElitistCount; j++)
                    {
                        Elitist.Add(Elitists[j].Revive());
                    }
                }
            }

            return Elitist;
        }

        private void InitRoulette(List<IDNA<T>> Population)
        {
            this.MyRoulette.Clear();
            for (int i = Population.Count - 1; i >= 0; i--)
            {
                double n = Population[i].GetFitnesss();
                Func<double, long> optimizationFunc = (item) => (long)(Math.Pow(item * 100, 3));
                //if (GlobalConfiguration.ApplyNaturalSelection)
                //{
                //    optimizationFunc = (item) => (long)(item*10 * (i * i));
                //}

                this.MyRoulette.AddToRange(n, Population[i], optimizationFunc);
            }
        }
    }
}
