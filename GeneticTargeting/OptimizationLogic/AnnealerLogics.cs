using EvolutionaryLogic;
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
    class AnnealerLogic : BaseOptimizationLogic
    {
        public AnnealingProccess Annealer { get; set; }

        public override CTaamAssignment GetBestFitness()
        {
            return Annealer.BestFitness as CTaamAssignment;
        }

        public override void InitPopulation()
        {
            this.Annealer = new AnnealingProccess(this.GetPopulationGenerator());
        }

        public override Task LaunchOptimizer(Progress<IDNA> progress)
        {
            return Task.Factory.StartNew(() => Annealer.Anneal(progress), TaskCreationOptions.LongRunning);
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
