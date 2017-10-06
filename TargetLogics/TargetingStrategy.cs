using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TargetLogics
{
    public class TargetingStrategy : IDrawable
    {
        public CMap Terrain;
        public CSimpleArtillary[] FriendliesData;
        public CSimpleArtillary[] EnemiesData;

        public int FriendliesTotalAmmunition { get; set; }

        public TargetingStrategy(int nFriendlyCount, int nEnemyCount)
        {
            this.Terrain = new CMap(GlobalConfiguration.GameSettings.GridSize, 100);
            this.FriendliesData = new CSimpleArtillary[nFriendlyCount];
            this.EnemiesData = new CSimpleArtillary[nEnemyCount];
            GlobalConfiguration.GameData.MaxAttackPrice = 0;
            GlobalConfiguration.GameData.MaxAttackImportance = 0;
            // SHOULD Be replaced by dataSource
            for (int UIDCoutner = 0; UIDCoutner < nFriendlyCount; UIDCoutner++)
            {
                Point2D point = null;

                do
                {
                    point = new Point2D(
                        this.CenterizeArtillaryInGrid(Shared.Next(this.Terrain.GetColSize())),
                        this.CenterizeArtillaryInGrid(this.Terrain.GetRowSize() - Shared.Next(this.Terrain.GetRowSize() / 3) - 1));
                }
                while (this.Contains(this.FriendliesData, point));

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
                CSimpleArtillary objCannon = new CSimpleArtillary(Range, Ammo, Damage, PricePerShot, ForceConstraints, Accuracy, MinAccuracy, 1);
                objCannon
                    .SetLocation(point).
                    SetUID(UIDCoutner);

                this.FriendliesData[UIDCoutner] = objCannon;
            }

            // SHOULD Be replaced by dataSource
            for (int i = 0; i < nEnemyCount; i++)
            {
                Point2D point = null;

                do
                {
                    point = new Point2D(
                        this.CenterizeArtillaryInGrid(Shared.Next(this.Terrain.GetColSize())),
                        this.CenterizeArtillaryInGrid(Shared.Next(this.Terrain.GetRowSize() / 3)));
                }
                while (this.Contains(this.EnemiesData, point));

                int MinAccuracy = Math.Max(Shared.Next(GlobalConfiguration.GameSettings.MaxAccuracyForShot), GlobalConfiguration.GameSettings.MinAccuracyForShot);
                int Importance = Math.Max(Shared.Next(GlobalConfiguration.GameSettings.MaxImportance), GlobalConfiguration.GameSettings.MinImportance);
                GlobalConfiguration.GameData.MaxAttackImportance += Importance;

                int ForceConstraints = 0;
                ForceConstraints |= Shared.HitChance(.6) ? (int)ENUMForces.Land : 0;
                ForceConstraints |= Shared.HitChance(.6) ? (int)ENUMForces.Air : 0;
                ForceConstraints |= Shared.HitChance(.6) ? (int)ENUMForces.Sea : 0;

                CSimpleArtillary objCannon = new CSimpleArtillary(250, 1, 1, 1, ForceConstraints, 1, MinAccuracy, Importance);
                objCannon.SetLocation(point);

                this.EnemiesData[i] = objCannon;
            }

            this.FriendliesTotalAmmunition = 0;
            foreach (CSimpleArtillary Cannon in this.FriendliesData)
            {
                this.FriendliesTotalAmmunition += Cannon.Ammunition;
            }

            GlobalConfiguration.GameData.MaxAttackPrice = GlobalConfiguration.GameData.MaxAttackPrice == 0 ? 1 : GlobalConfiguration.GameData.MaxAttackPrice;
            GlobalConfiguration.GameData.MaxAttackImportance = GlobalConfiguration.GameData.MaxAttackImportance == 0 ? 1 : GlobalConfiguration.GameData.MaxAttackImportance;
        }

        public CSimpleArtillary[] GetMutatedFriendlyArtillary()
        {
            CSimpleArtillary[] FriendlyArtillary = new CSimpleArtillary[this.FriendliesData.Length];
            for (int i = 0; i < this.FriendliesData.Length; i++)
            {
                FriendlyArtillary[i] = this.FriendliesData[i].Clone();
                FriendlyArtillary[i].Mutate();
            }

            return FriendlyArtillary;
        }

        public CSimpleArtillary[] GetEnemyArtillary()
        {
            CSimpleArtillary[] EnemyArtillary = new CSimpleArtillary[this.EnemiesData.Length];
            for (int i = 0; i < this.EnemiesData.Length; i++)
            {
                EnemyArtillary[i] = this.EnemiesData[i].Clone();
            }

            return EnemyArtillary;
        }

        public void Reorder()
        {
            if (Shared.HitChance(.05))
            {
                int nReplaceWith;
                CSimpleArtillary Temp;
                for (int i = 0; i < this.FriendliesData.Length; i++)
                {
                    if (Shared.HitChance(.6))
                    {
                        nReplaceWith = Shared.Next(this.FriendliesData.Length);
                        Temp = this.FriendliesData[nReplaceWith];
                        this.FriendliesData[nReplaceWith] = this.FriendliesData[i];
                        this.FriendliesData[i] = Temp;
                    }
                }
            }
        }

        public void ResetEnemyStatus()
        {
            foreach (CSimpleArtillary Cannon in this.EnemiesData)
            {
                Cannon.ResetStatus();
            }
        }

        public int GetFriendlyCount()
        {
            return this.FriendliesData.Length;
        }

        public int GetEnemyCount()
        {
            return this.EnemiesData.Length;
        }

        public void Draw(Graphics g)
        {
            this.Terrain.Draw(g);
        }

        private float CenterizeArtillaryInGrid(double nNum)
        {
            return (float)nNum * this.Terrain.CellSize + this.Terrain.CellSize / 2;
        }

        private bool Contains(CSimpleArtillary[] list, Point2D Target)
        {
            foreach (CSimpleArtillary item in list)
            {
                if(item == null)
                {
                    return false;
                }

                if(item.Location.Equals(Target))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
