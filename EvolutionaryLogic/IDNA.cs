using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationLogics
{
    public interface IDNA<T>: INextGeneration<IDNA<T>>
    {
        IDNA<T> Crossover(IDNA<T> objPartner);
        bool Mutate();
        bool Mutate(Random rnd);
        void CalculateFitness();
        float GetFitnesss();
        void Execute();
        T[] GetGenes();
    }
}
