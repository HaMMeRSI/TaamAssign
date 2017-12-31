using OptimizationLogics;
using Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaamLogics;

namespace TaamAssign
{
    class AnnealerLogic<T> : BaseOptimizationLogic<T>
    {
        public AnnealingProccess<T> Annealer { get; set; }

        public override CTaamAssignment GetBestFitness()
        {
            return Annealer.BestFitness as CTaamAssignment;
        }

        public override void InitPopulation(Func<DNA<T>> GetPopulationGenerator)
        {
            this.Annealer = new AnnealingProccess<T>(GetPopulationGenerator);
        }

        public override Task LaunchOptimizer(Progress<IDNA<T>> progress)
        {
            return Task.Factory.StartNew(() => Annealer.MultiAnneal(GlobalConfiguration.AnealingInstances), TaskCreationOptions.LongRunning);
        }

        public override CStatutsGraph GetStatusGraph()
        {
            return this.Annealer?.StatusGraph;
        }

        public override Action<Graphics> GetLoggerDrawer()
        {
            return g =>
            {
                string Log = string.Format(@"Best Fitness: {0}
Tempature: {1}", this.Annealer?.BestFitness.GetFitnesss(), this.Annealer?.Temperature);

                g.DrawString(Log, f, b, new Point2D());
            };
        }
    }
}
