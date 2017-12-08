using Library;
using System.Collections.Concurrent;

namespace TaamLogics
{
    public class CStrategyPool
    {
        public static AssignmentStrategy ActiveStrategy { get; private set; }
        private static ConcurrentStack<AssignmentStrategy> FreeStrategyPool { get; set; } = new ConcurrentStack<AssignmentStrategy>();

        public static void CreateRandomStrategy(CMap Terrain)
        {
            PartialFixedStrategyDataSource ds = new PartialFixedStrategyDataSource(Terrain);
            ActiveStrategy = new AssignmentStrategy(ds);
            FreeStrategyPool.Clear();
        }

        public static AssignmentStrategy GetFromPool()
        {
            AssignmentStrategy FreeStrategy = null;
            bool b = FreeStrategyPool.TryPop(out FreeStrategy);
            if(!b)
            {
                FreeStrategy = ActiveStrategy.Clone();
            }

            return FreeStrategy;
        }

        public static void Release(AssignmentStrategy strategy)
        {
            FreeStrategyPool.Push(strategy);
        }
    }
}
