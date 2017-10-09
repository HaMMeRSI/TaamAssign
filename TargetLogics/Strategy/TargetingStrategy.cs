using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TargetLogics
{
    public class TargetingStrategy : ILive, ICloneable<TargetingStrategy>
    {
        public CWorld BestFitness { get; set; }
        public CMap Terrain { get; set; }
        public Dictionary<int, CSimpleArtillary> FriendliesData { get; set; }
        public CSimpleArtillary[] EnemiesData { get; set; }

        public TargetingStrategy(int nFriendlyCount, int nEnemyCount)
        {
            this.Terrain = new CMap(GlobalConfiguration.GameSettings.GridSize, 100);
            //this.FriendliesData = new CSimpleArtillary[nFriendlyCount];
            this.EnemiesData = new CSimpleArtillary[nEnemyCount];
            this.FriendliesData = new Dictionary<int, CSimpleArtillary>();
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

            GlobalConfiguration.GameData.MaxAttackPrice = GlobalConfiguration.GameData.MaxAttackPrice == 0 ? 1 : GlobalConfiguration.GameData.MaxAttackPrice;
            GlobalConfiguration.GameData.MaxAttackImportance = GlobalConfiguration.GameData.MaxAttackImportance == 0 ? 1 : GlobalConfiguration.GameData.MaxAttackImportance;
        }

        private TargetingStrategy()
        {
            this.FriendliesData = new Dictionary<int, CSimpleArtillary>();
        }

        public void ResetStrategyStatus()
        {
            foreach (CSimpleArtillary Cannon in this.EnemiesData)
            {
                Cannon.ResetStatus();
            }

            foreach (CSimpleArtillary Cannon in this.FriendliesData.Values)
            {
                Cannon.ResetStatus();
            }
        }

        public int GetFriendlyCount()
        {
            return this.FriendliesData.Count;
        }

        public int GetEnemyCount()
        {
            return this.EnemiesData.Length;
        }


        private float CenterizeArtillaryInGrid(double nNum)
        {
            return (float)nNum * this.Terrain.CellSize + this.Terrain.CellSize / 2;
        }

        private bool Contains(Dictionary<int, CSimpleArtillary> collection, Point2D Target)
        {
            return collection.Values.FirstOrDefault(x => x.Location.Equals(Target)) != null;
        }

        private bool Contains(CSimpleArtillary[] collection, Point2D Target)
        {
            return collection.FirstOrDefault(x => x != null && x.Location.Equals(Target)) != null;
        }

        #region ILive

        public void Draw(Graphics g)
        {
            this.Terrain.Draw(g);
            CSimpleArtillary Cannon;

            foreach (SlimEnemy ECannon in this.BestFitness.Enemies)
            {
                this.EnemiesData[ECannon.UID].Draw(g);
                
                if (ECannon.HittedBy != null && ECannon.Health <= 0)
                {
                    foreach (int FCannon in ECannon.HittedBy)
                    {
                        Cannon = this.FriendliesData[FCannon];
                        Pen pp = new Pen(Cannon.MyColor, 2);
                        g.DrawLine(pp, CSimpleArtillary.CentralizeShoot(this.EnemiesData[ECannon.UID].Location, ECannon.HittedBy != null), CSimpleArtillary.CentralizeShoot(Cannon.Location, false));
                    }
                }
            }

            foreach (CSimpleArtillary MyCannon in this.FriendliesData.Values)
            {
                MyCannon.Draw(g);
            }
        }

        public void Update()
        {
            foreach (CSimpleArtillary MyCannon in this.EnemiesData)
            {
                MyCannon.Update();
            }

            foreach (CSimpleArtillary MyCannon in this.FriendliesData.Values)
            {
                MyCannon.Update();
            }
        }

        public TargetingStrategy Clone()
        {
            TargetingStrategy s = new TargetingStrategy();
            s.EnemiesData = new CSimpleArtillary[this.EnemiesData.Length];
            s.Terrain = this.Terrain;
            s.BestFitness = this.BestFitness;

            foreach (int UID in this.FriendliesData.Keys)
            {
                s.FriendliesData[UID] = this.FriendliesData[UID].Clone();
            }

            for (int i = 0; i < this.EnemiesData.Length; i++)
            {
                s.EnemiesData[i] = this.EnemiesData[i].Clone();
            }

            return s;
        }

        #endregion
    }
}
