﻿using Library;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryLogic
{
    public class God
    {
        #region Properties

        private List<IDNA> Population { get; set; }
        public PopulationSelector MySelector { get; set; }

        public IDNA BestFitness { get; set; }
        public int GenerationCount { get; set; }
        public float AvreageFitness { get; set; }
        public CStatutsGraph StatusGraph { get; set; }

        #endregion

        public God(Func<IDNA> PopulationGenerator)
        {
            this.Population = new List<IDNA>();
            this.MySelector = new PopulationSelector();
            this.GenerationCount = 0;
            this.StatusGraph = new CStatutsGraph();

            for (int i = 0; i < GlobalConfiguration.PopulationCount; i++)
            {
                IDNA dna = PopulationGenerator();
                dna.Execute();
                this.Population.Add(dna);
            }

            this.AssessPopulation();
        }

        public void GeneratePopulation(int Generations, IProgress<IDNA> progress)
        {
            for (int i = 0; i < Generations; i++)
            {
                List<IDNA> NewPop = new List<IDNA>();
                int nElitilst = (int)(GlobalConfiguration.ApplyElitist ? Math.Max(this.Population.Count * .01f, 1) : 0);
                this.ChooseElitist(NewPop, nElitilst);

                MatingPool pool = new MatingPool(this.Population);

                for (int j = 0; j < GlobalConfiguration.PopulationCount - nElitilst; j++)
                {
                    var p = pool.GetChild();

                    NewPop.Add(p);
                }

                this.Population = NewPop;
                this.GenerationCount++;
                this.AssessPopulation();


                progress.Report(this.BestFitness);
            }
        }

        public void ChooseElitist(List<IDNA> colNewPopulation, int nElitistCount)
        {
            if (GlobalConfiguration.ApplyNaturalSelection)
            {
                this.MySelector.NaturalSelection(this.Population);
                for (int j = 0; j < nElitistCount; j++)
                {
                    colNewPopulation.Add(this.Population[this.Population.Count - 1 - j].Revive());
                }
            }
            else if (GlobalConfiguration.ApplyElitist)
            {
                IDNA[] Elitists = new IDNA[nElitistCount];
                for (int j = 0; j < nElitistCount; j++)
                {
                    Elitists[j] = this.Population[j];
                }

                for (int j = nElitistCount; j < this.Population.Count; j++)
                {
                    for (int k = 0; k < nElitistCount; k++)
                    {
                        if (this.Population[j].GetFitnesss() > Elitists[k].GetFitnesss())
                        {
                            Elitists[k] = this.Population[j];
                            break;
                        }
                    }
                }

                for (int j = 0; j < nElitistCount; j++)
                {
                    colNewPopulation.Add(Elitists[j].Revive());
                }
            }
        }

        private void AssessPopulation()
        {
            int nBulkSize = 100;
            int nChunksCount = this.Population.Count / nBulkSize;
            int nChunksRemainder = this.Population.Count % nBulkSize;
            int nRemainder = nChunksRemainder > 0 ? 1 : 0;
            Task[] Assesments = new Task[nChunksCount + nRemainder];

            for (int i = 0; i < Assesments.Length - nRemainder; i++)
            {
                int q = i;
                Assesments[i] = Task.Factory.StartNew(() => this.PartialAssesment(q * nBulkSize, nBulkSize), TaskCreationOptions.None);
            }
            if(nRemainder > 0)
            {
                Assesments[Assesments.Length - 1] = Task.Factory.StartNew(() => this.PartialAssesment((Assesments.Length - 1) * nBulkSize, nChunksRemainder), TaskCreationOptions.None);
            }

            Task.WaitAll(Assesments);
            int bestIdx = 0;
            float BestDNAFitness = -2;
            float TotalFintess = 0;

            for (int i = 0; i < this.Population.Count; i++)
            {
                IDNA objDNA = this.Population[i];
                TotalFintess += objDNA.GetFitnesss();

                if (objDNA.GetFitnesss() > BestDNAFitness)
                {
                    BestDNAFitness = objDNA.GetFitnesss();
                    bestIdx = i;
                }
            }

            this.BestFitness = this.Population[bestIdx].Clone();
            this.AvreageFitness = TotalFintess / GlobalConfiguration.PopulationCount;

            this.StatusGraph.AddToHistory(BestDNAFitness);
            this.StatusGraph.Average = this.AvreageFitness;
        }

        private void PartialAssesment(int nStart, int Offset)
        {
            for (int i = nStart; i < nStart + Offset; i++)
            {
                this.Population[i].CalculateFitness();
            }
        }

        public string PrintAll()
        {
            string strAll = "";
            foreach (IDNA obj in this.Population)
            {
                strAll += obj.ToString();
                strAll += Environment.NewLine;
            }

            return strAll;
        }
    }
}
