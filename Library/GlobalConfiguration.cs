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
        private static Dictionary<string, Action<decimal>> Delegates = new Dictionary<string, Action<decimal>>();

        static GlobalConfiguration()
        {
            Delegates["FriendlyCount"] = (value) => FriendlyCount = (int)value;
            Delegates["EnemyCount"] = (value) => EnemyCount = (int)value;
            Delegates["PopulationCount"] = (value) => PopulationCount = (int)value;
            Delegates["MutationChance"] = (value) => MutationChance = (float)value;
        }

        public static Action<decimal> GetDelegate(string Name)
        {
            return Delegates[Name];
        }

        #endregion

        public class GameSettings
        {
            public static double MaxDamage = 1;
            public static double MinDamage = .3;
            public static int MaxRadius = 2500;
            public static int MinRadius = 1250;
            public static int MaxAmmunition = 5;
            public static int MinAmmunition = 1;
            public static int MaxShotsToFire = 5;
            public static int MinShotsToFire = 1;
            private static Dictionary<string, Action<decimal>> Delegates = new Dictionary<string, Action<decimal>>();

            static GameSettings()
            {
                Delegates["MaxDamage"] = (value) => MaxDamage = (double)value;
                Delegates["MinDamage"] = (value) => MinDamage = (double)value;
                Delegates["MaxRadius"] = (value) => MaxRadius = (int)value;
                Delegates["MinRadius"] = (value) => MinRadius = (int)value;
                Delegates["MaxAmmunition"] = (value) => MaxAmmunition = (int)value;
                Delegates["MinAmmunition"] = (value) => MinAmmunition = (int)value;
                Delegates["MaxShotsToFire"] = (value) => MaxShotsToFire = (int)value;
                Delegates["MinShotsToFire"] = (value) => MinShotsToFire = (int)value;
            }

            public static Action<decimal> GetDelegate(string Name)
            {
                return Delegates[Name];
            }
        }
    }
}
