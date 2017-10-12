using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetLogics 
{
    public class RandomStrategyDataSource : IStrategyDataSource
    {
        public CMap Terrain { get; set; }

        public RandomStrategyDataSource(CMap Terrain)
        {
            this.Terrain = Terrain;
        }

        public CSimpleArtillary[] GetEnemyData()
        {
            CSimpleArtillary[] EnemiesData = new CSimpleArtillary[GlobalConfiguration.GameSettings.EnemyCount];
            for (int i = 0; i < GlobalConfiguration.GameSettings.EnemyCount; i++)
            {
                Point2D point = null;

                do
                {
                    point = new Point2D(
                        this.CenterizeArtillaryInGrid(Shared.Next(this.Terrain.GetColSize())),
                        this.CenterizeArtillaryInGrid(Shared.Next(this.Terrain.GetRowSize() / 3)));
                }
                while (this.Contains(EnemiesData, point));

                int MinAccuracy = Math.Max(Shared.Next(GlobalConfiguration.GameSettings.MaxAccuracyForShot), GlobalConfiguration.GameSettings.MinAccuracyForShot);
                int Importance = Math.Max(Shared.Next(GlobalConfiguration.GameSettings.MaxImportance), GlobalConfiguration.GameSettings.MinImportance);
                GlobalConfiguration.GameData.MaxAttackImportance += Importance;

                int ForceConstraints = 0;
                ForceConstraints |= Shared.HitChance(.6) ? (int)ENUMForces.Land : 0;
                ForceConstraints |= Shared.HitChance(.6) ? (int)ENUMForces.Air : 0;
                ForceConstraints |= Shared.HitChance(.6) ? (int)ENUMForces.Sea : 0;

                CSimpleArtillary objCannon = new CSimpleArtillary(250, 1, 1, 1, ForceConstraints, 1, MinAccuracy, Importance);
                objCannon.SetLocation(point);

                EnemiesData[i] = objCannon;
            }

            return EnemiesData;
        }

        public CSimpleArtillary[] GetFriendlyData()
        {
            CSimpleArtillary[] FriendlyData = new CSimpleArtillary[GlobalConfiguration.GameSettings.FriendlyCount];
            for (int UIDCoutner = 0; UIDCoutner < GlobalConfiguration.GameSettings.FriendlyCount; UIDCoutner++)
            {
                Point2D point = null;

                do
                {
                    point = new Point2D(
                        this.CenterizeArtillaryInGrid(Shared.Next(this.Terrain.GetColSize())),
                        this.CenterizeArtillaryInGrid(this.Terrain.GetRowSize() - Shared.Next(this.Terrain.GetRowSize() / 3) - 1));
                }
                while (this.Contains(FriendlyData, point));

                float Damage = (float)Shared.GetMinMax(Shared.rnd.NextDouble(), GlobalConfiguration.GameSettings.MinDamage, GlobalConfiguration.GameSettings.MaxDamage);
                int Range = Math.Max(Shared.Next(GlobalConfiguration.GameSettings.MaxRadius), GlobalConfiguration.GameSettings.MinRadius);
                int Ammo = Math.Max(Shared.Next(GlobalConfiguration.GameSettings.MaxAmmunition), GlobalConfiguration.GameSettings.MinAmmunition);
                int PricePerShot = Math.Max(Shared.Next(GlobalConfiguration.GameSettings.MaxPricePerShot), GlobalConfiguration.GameSettings.MinPricePerShot);
                int Accuracy = Math.Max(Shared.Next(GlobalConfiguration.GameSettings.MaxAccuracyForShot), GlobalConfiguration.GameSettings.MinAccuracyForShot);
                int MinAccuracy = Math.Max(Shared.Next(GlobalConfiguration.GameSettings.MaxAccuracyForShot), GlobalConfiguration.GameSettings.MinAccuracyForShot);
                int ForceConstraints = 0;
                ForceConstraints |= Shared.HitChance(.6) ? (int)ENUMForces.Land : 0;
                ForceConstraints |= Shared.HitChance(.6) ? (int)ENUMForces.Air : 0;
                ForceConstraints |= Shared.HitChance(.6) ? (int)ENUMForces.Sea : 0;
                GlobalConfiguration.GameData.MaxAttackPrice += PricePerShot * Ammo;
                GlobalConfiguration.GameData.TotalAttackAmmo += Ammo;
                CSimpleArtillary objCannon = new CSimpleArtillary(Range, Ammo, Damage, PricePerShot, ForceConstraints, Accuracy, MinAccuracy, 1);
                objCannon
                    .SetLocation(point).
                    SetUID(UIDCoutner);

                FriendlyData[UIDCoutner] = objCannon;
            }

            return FriendlyData;
        }

        private float CenterizeArtillaryInGrid(double nNum)
        {
            return (float)nNum * this.Terrain.CellSize + this.Terrain.CellSize / 2;
        }
        private bool Contains(CSimpleArtillary[] collection, Point2D Target)
        {
            return collection.FirstOrDefault(x => x != null && x.Location.Equals(Target)) != null;
        }
    }
}
