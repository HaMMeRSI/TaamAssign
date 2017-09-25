using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryLogic
{
    public interface IDNA
    {
        IDNA Crossover(IDNA partner);
        void CalculateFitness(string target);
        void Mutate();
        IDNA GetObj();
        float GetFitnesss();
    }
}
