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

        public static int PopulationCount = 500;
        public static float MutationChance = 7f;
        public static float ParentChance = 10f;
        public static bool ApplyElitist = true;
        private static Dictionary<string, Action<object>> Delegates = new Dictionary<string, Action<object>>();

        static GlobalConfiguration()
        {
            Delegates["PopulationCount"] = (value) => PopulationCount = Convert.ToInt32(value);
            Delegates["MutationChance"] = (value) => MutationChance = (float)Convert.ToDouble(value);
            Delegates["ParentChance"] = (value) => ParentChance = (float)Convert.ToDouble(value);
            Delegates["ApplyElitist"] = (value) => ApplyElitist = Convert.ToBoolean(value);
        }

        public static Action<object> GetDelegate(string Name)
        {
            return Delegates[Name];
        }

        #endregion

        public class GameSettings
        {
            #region General
            public static int FriendlyCount = 20;
            public static int EnemyCount = 25; 
            #endregion

            #region DeadCount
            public static double MaxDamage = 1;
            public static double MinDamage = .3;
            public static int MaxRadius = 2500;
            public static int MinRadius = 1250;
            public static int MaxAmmunition = 5;
            public static int MinAmmunition = 1;
            public static int MaxShotsToFire = 5;
            public static int MinShotsToFire = 1;
            public static double DeadCountWeight = 1.7f;
            #endregion

            #region Price
            public static int MaxPricePerShot = 100;
            public static int MinPricePerShot = 50; 
            public static double PriceWeight = .3f;
            #endregion

            static GameSettings()
            {
                Delegates["FriendlyCount"] = (value) => FriendlyCount = Convert.ToInt32(value);
                Delegates["EnemyCount"] = (value) => EnemyCount = Convert.ToInt32(value);
                Delegates["MaxDamage"] = (value) => MaxDamage = Convert.ToDouble(value);
                Delegates["MinDamage"] = (value) => MinDamage = Convert.ToDouble(value);
                Delegates["MaxRadius"] = (value) => MaxRadius = Convert.ToInt32(value);
                Delegates["MinRadius"] = (value) => MinRadius = Convert.ToInt32(value);
                Delegates["MaxAmmunition"] = (value) => MaxAmmunition = Convert.ToInt32(value);
                Delegates["MinAmmunition"] = (value) => MinAmmunition = Convert.ToInt32(value);
                Delegates["MaxPricePerShot"] = (value) => MaxPricePerShot = Convert.ToInt32(value);
                Delegates["MinPricePerShot"] = (value) => MinPricePerShot = Convert.ToInt32(value);
                Delegates["DeadCountWeight"] = (value) => { double val = Convert.ToDouble(value); DeadCountWeight = val;  PriceWeight = 2 - val; };
                Delegates["PriceWeight"] = (value) => { double val = Convert.ToDouble(value); PriceWeight = val; DeadCountWeight = 2 - val; };
            }

            public static Action<object> GetDelegate(string Name)
            {
                return Delegates[Name];
            }
        }
    }
}
