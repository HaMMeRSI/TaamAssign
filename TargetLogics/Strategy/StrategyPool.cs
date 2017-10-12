using Library;
using System.Collections.Concurrent;

namespace TargetLogics
{
    public class CStrategyPool
    {
        public static TargetingStrategy ActiveStrategy { get; private set; }
        private static ConcurrentStack<TargetingStrategy> FreeStrategyPool { get; set; } = new ConcurrentStack<TargetingStrategy>();

        public static void CreateRandomStrategy(CMap Terrain)
        {
            RandomStrategyDataSource ds = new RandomStrategyDataSource(Terrain);
            ActiveStrategy = new TargetingStrategy(ds);
            FreeStrategyPool.Clear();
        }

        public static void CreateFixedStrategy(CMap Terrain)
        {
            FixedStrategyDataSource ds = new FixedStrategyDataSource(Terrain);
            ActiveStrategy = new TargetingStrategy(ds);
            FreeStrategyPool.Clear();
        }

        public static TargetingStrategy GetFromPool()
        {
            TargetingStrategy FreeStrategy = null;
            bool b = FreeStrategyPool.TryPop(out FreeStrategy);
            if(!b)
            {
                FreeStrategy = ActiveStrategy.Clone();
            }

            return FreeStrategy;
        }

        public static void Release(TargetingStrategy strategy)
        {
            FreeStrategyPool.Push(strategy);
        }
    }
}
