using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryLogic
{
    public interface IDNA
    {
        IDNA Crossover(IDNA objPartner);
        void CalculateFitness();
        float GetFitnesss();
        void Execute();
    }
}
