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
        public static bool ApplyNaturalSelection = true; 
        private static Dictionary<string, Action<object>> Delegates = new Dictionary<string, Action<object>>();

        static GlobalConfiguration()
        {
            Delegates["PopulationCount"] = (value) => PopulationCount = Convert.ToInt32(value);
            Delegates["MutationChance"] = (value) => MutationChance = (float)Convert.ToDouble(value);
            Delegates["ParentChance"] = (value) => ParentChance = (float)Convert.ToDouble(value);
            Delegates["ApplyElitist"] = (value) => ApplyElitist = Convert.ToBoolean(value);
            Delegates["ApplyNaturalSelection"] = (value) => ApplyNaturalSelection = Convert.ToBoolean(value);
        }

        public static Action<object> GetDelegate(string Name)
        {
            return Delegates[Name];
        }

        #endregion

        public class GameData
        {
            public static int MaxAttackPrice = 1;
            public static int MaxAttackImportance = 1;
        }

        public class GameSettings
        {
            #region General
            public static int FriendlyCount = 20;
            public static int EnemyCount = 25;
            public static int GridSize = 10;
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
            public static int MinAccuracyForShot = 50;
            public static int MaxAccuracyForShot = 100;
            #endregion

            #region Price
            public static int MaxPricePerShot = 50;
            public static int MinPricePerShot = 0;

            public static int MaxImportance = 1000;
            public static int MinImportance = 0;
            #endregion

            #region Weights
            public static double DeadCountWeight = .7f;
            public static double PriceWeight = .15f;
            public static double ImportanceWeight = .15f;
            #endregion

            static GameSettings()
            {
                Delegates["FriendlyCount"] = (value) => FriendlyCount = Convert.ToInt32(value);
                Delegates["EnemyCount"] = (value) => EnemyCount = Convert.ToInt32(value);
                Delegates["GridSize"] = (value) => GridSize = Convert.ToInt32(value);
                Delegates["MaxDamage"] = (value) => MaxDamage = Convert.ToDouble(value);
                Delegates["MinDamage"] = (value) => MinDamage = Convert.ToDouble(value);
                Delegates["MaxRadius"] = (value) => MaxRadius = Convert.ToInt32(value);
                Delegates["MinRadius"] = (value) => MinRadius = Convert.ToInt32(value);
                Delegates["MaxAmmunition"] = (value) => MaxAmmunition = Convert.ToInt32(value);
                Delegates["MinAmmunition"] = (value) => MinAmmunition = Convert.ToInt32(value);
                Delegates["MinAccuracyForShot"] = (value) => MinAccuracyForShot = Convert.ToInt32(value);
                Delegates["MaxAccuracyForShot"] = (value) => MaxAccuracyForShot = Convert.ToInt32(value);

                Delegates["MinImportance"] = (value) => MinImportance = Convert.ToInt32(value);
                Delegates["MaxImportance"] = (value) => MaxImportance = Convert.ToInt32(value);

                Delegates["MaxPricePerShot"] = (value) => MaxPricePerShot = Convert.ToInt32(value);
                Delegates["MinPricePerShot"] = (value) => MinPricePerShot = Convert.ToInt32(value);
                Delegates["DeadCountWeight"] = (value) => { double val = Convert.ToDouble(value); DeadCountWeight = val;};
                Delegates["PriceWeight"] = (value) => { double val = Convert.ToDouble(value); PriceWeight = val;};
                Delegates["ImportanceWeight"] = (value) => { double val = Convert.ToDouble(value); ImportanceWeight = val; };
            }
        }
    }
}
