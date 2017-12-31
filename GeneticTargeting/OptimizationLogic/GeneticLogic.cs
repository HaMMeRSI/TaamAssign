using OptimizationLogics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TaamLogics;
using Library;
using System.Diagnostics;

namespace TaamAssign
{
    public class GeneticLogic<T> : BaseOptimizationLogic<T>
    {
        public God<T> PopGen { get; set; }

        public GeneticLogic()
        {

        }

        public override CTaamAssignment GetBestFitness()
        {
            return this.PopGen?.BestFitness as CTaamAssignment;
        }

        public override CStatutsGraph GetStatusGraph()
        {
            return this.PopGen?.StatusGraph;
        }

        public override void InitPopulation(Func<DNA<T>> GetPopulationGenerator)
        {
            this.PopGen = new God<T>(GetPopulationGenerator);
        }

        public override Task LaunchOptimizer(Progress<IDNA<T>> progress)
        {
            return Task.Factory.StartNew(() => PopGen.GeneratePopulation(GlobalConfiguration.GenerationCount, progress), TaskCreationOptions.LongRunning);
        }

        public override Action<Graphics> GetLoggerDrawer()
        {
            return g =>
            {
                string Log = string.Format(@"Curr gen count: {0}
Average fitness: {1}
Best Fitness: {2}", PopGen?.GenerationCount, PopGen?.AvreageFitness, PopGen?.BestFitness.GetFitnesss());

                g.DrawString(Log, f, b, new Point2D());
            };
        }
    }
}
