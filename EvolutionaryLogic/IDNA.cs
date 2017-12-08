using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryLogic
{
    public interface IDNA: INextGeneration<IDNA>
    {
        IDNA Crossover(IDNA objPartner);
        bool Mutate();
        void CalculateFitness();
        float GetFitnesss();
        void Execute();
    }
}
