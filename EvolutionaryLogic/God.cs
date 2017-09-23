using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logics
{
    public class God
    {
        #region Properties

        private List<DNA> Population { get; set; }
        private int MyPopulationSize { get; set; }
        private string Target { get; set; }
        public PopulationSelector MySelector { get; set; }

        public DNA BestFitness { get; set; }
        public int GenerationCount { get; set; }
        public float AvreageFitness { get; set; } 

        #endregion

        public God(int nPopSize, string strTarget)
        {
            this.Target = strTarget;
            this.Population = new List<DNA>();
            this.MySelector = new PopulationSelector();
            this.MyPopulationSize = nPopSize;
            this.GenerationCount = 0;

            for (int i = 0; i < this.MyPopulationSize; i++)
            {
                this.Population.Add(new DNA(this.Target.Length));
            }

            this.AssessPopulation();
        }

        public void GeneratePopulation()
        {
            this.MySelector.NaturalSelection(this.Population);

            MatingPool pool = new MatingPool(this.Population);
            List<DNA> NewPop = new List<DNA>();

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
            DNA BestDNA = new DNA(this.Target.Length);
            float TotalFintess = 0;

            foreach (DNA objDNA in this.Population)
            {
                objDNA.calcFitness(this.Target);

                TotalFintess += objDNA.Fitness;
                if (objDNA.Fitness > BestDNA.Fitness)
                {
                    BestDNA = objDNA;
                }
            }

            this.BestFitness = BestDNA;
            this.AvreageFitness = TotalFintess / this.MyPopulationSize;
        }

        public string PrintAll()
        {
            string strAll = "";
            foreach (DNA obj in this.Population)
            {
                strAll += obj.ToString();
                strAll += Environment.NewLine;
            }

            return strAll;
        }
    }
}
