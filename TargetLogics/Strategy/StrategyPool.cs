using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetLogics
{
    public class CStrategyPool
    {
        private static TargetingStrategy ActiveStrategy { get; set; }
        private static ConcurrentStack<TargetingStrategy> FreeStrategyPool { get; set; } = new ConcurrentStack<TargetingStrategy>();

        public static void CreateStrategy(int nFriendlyCount, int nEnemyCount)
        {
            ActiveStrategy = new TargetingStrategy(nFriendlyCount, nEnemyCount);
            FreeStrategyPool.Clear();
        }

        public static void SetStrategy(TargetingStrategy strategy)
        {
            ActiveStrategy = strategy;
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
