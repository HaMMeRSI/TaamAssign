using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class GlobalConfiguration
    {
        #region Genetic configuration

        public static int FriendlyCount = 20;
        public static int EnemyCount = 25;
        public static int PopulationCount = 500;
        public static float MutationChance = 13f;

        public static Action<decimal> GetFriendlyCountDelegate()
        {
            return (value) => FriendlyCount = (int)value;
        }
        public static Action<decimal> GetEnemyCountDelegate()
        {
            return (value) => EnemyCount = (int)value;
        }
        public static Action<decimal> GetPopulationCountDelegate()
        {
            return (value) => PopulationCount = (int)value;
        }
        public static Action<decimal> GetMutationChanceDelegate()
        {
            return (value) => MutationChance = (float)value;
        }

        #endregion

        public class GameSettings
        {
            public static double MaxDamage = 1;
            public static double MinDamage = .3;
            public static int MaxRadius = 1500;
            public static int MinRadius = 800;
            public static int MaxAmmunition = 5;
            public static int MinAmmunition = 1;
            public static int MaxShotsToFire = 1;
            public static int MinShotsToFire = 1;
        }
    }
}
