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
            this.Terrain = new CMap(10, 100);
            this.FriendliesData = new CSimpleArtillary[nFriendlyCount];
            this.EnemiesData = new CSimpleArtillary[nEnemyCount];

            // SHOULD Be replaced by dataSource
            for (int i = 0; i < nFriendlyCount; i++)
            {
                Point2D point = null;

                do
                {
                    point = new Point2D(
                        this.CenterizeArtillaryInGrid(Shared.Next(this.Terrain.GetColSize())),
                        this.CenterizeArtillaryInGrid(this.Terrain.GetRowSize() - Shared.Next(this.Terrain.GetRowSize() / 3) - 1));
                }
                while (this.Contains(this.FriendliesData, point));

                double fDamage = Shared.GetMinMax(Shared.rnd.NextDouble(), GlobalConfiguration.GameSettings.MinDamage, GlobalConfiguration.GameSettings.MaxDamage);
                int Radius = Math.Max(Shared.Next(GlobalConfiguration.GameSettings.MaxRadius), GlobalConfiguration.GameSettings.MinRadius);
                int Ammo = Math.Max(Shared.Next(GlobalConfiguration.GameSettings.MaxAmmunition), GlobalConfiguration.GameSettings.MinAmmunition);

                CSimpleArtillary objCannon = new CSimpleArtillary(Radius, Ammo, (float)fDamage);
                objCannon.SetLocation(point);

                this.FriendliesData[i] = objCannon;
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

                CSimpleArtillary objCannon = new CSimpleArtillary(1, 1, 1);
                objCannon.SetLocation(point);

                this.EnemiesData[i] = objCannon;
            }

            this.FriendliesTotalAmmunition = 0;
            foreach (CSimpleArtillary Cannon in this.FriendliesData)
            {
                this.FriendliesTotalAmmunition += Cannon.Ammunition;
            }
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
