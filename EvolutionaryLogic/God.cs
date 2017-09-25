using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryLogic
{
    public class God
    {
        #region Properties

        private List<IDNA> Population { get; set; }
        private int MyPopulationSize { get; set; }
        public PopulationSelector MySelector { get; set; }

        public IDNA BestFitness { get; set; }
        public int GenerationCount { get; set; }
        public float AvreageFitness { get; set; }

        #endregion

        public God(int nPopSize, Func<IDNA> PopulationGenerator)
        {
            this.Population = new List<IDNA>();
            this.MySelector = new PopulationSelector();
            this.MyPopulationSize = nPopSize;
            this.GenerationCount = 0;

            for (int i = 0; i < this.MyPopulationSize; i++)
            {
                this.Population.Add(PopulationGenerator());
            }

            this.AssessPopulation();
        }

        public void GeneratePopulation()
        {
            this.MySelector.NaturalSelection(this.Population);
            MatingPool pool = new MatingPool(this.Population);
            List<IDNA> NewPop = new List<IDNA>();

            for (int i = 0; i < this.MyPopulationSize; i++)
            {
                NewPop.Add(pool.GetChild());
            }

            this.Population = NewPop;
            this.GenerationCount++;
            this.AssessPopulation();
        }

        private void AssessPopulation()
        {
            IDNA BestDNA = null;
            float BestDNAFitness = -1;
            float TotalFintess = 0;

            foreach (IDNA objDNA in this.Population)
            {
                objDNA.CalculateFitness();

                TotalFintess += objDNA.GetFitnesss();
                if (objDNA.GetFitnesss() > BestDNAFitness)
                {
                    BestDNAFitness = objDNA.GetFitnesss();
                    BestDNA = objDNA;
                }
            }

            this.BestFitness = BestDNA;
            this.AvreageFitness = TotalFintess / this.MyPopulationSize;
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
