using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TargetLogics
{
    public class TargetingStrategy :IDrawable
    {
        public CMap Terrain;
        public CSimpleArtillary[] Friendlies;
        public CSimpleArtillary[] Enemies;

        public int FriendliesTotalAmmunition { get; set; }

        public TargetingStrategy(int nFriendlyCount, int nEnemyCount)
        {
            this.Terrain = new CMap(10, 100);
            this.Friendlies = new CSimpleArtillary[nFriendlyCount];
            this.Enemies = new CSimpleArtillary[nEnemyCount];

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
                while (this.Contains(this.Friendlies, point));

                CSimpleArtillary objCannon = new CSimpleArtillary(1, Shared.Next(5), 1,0);
                objCannon.Mutate();
                objCannon.SetLocation(point);

                this.Friendlies[i] = objCannon;
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
                while (this.Contains(this.Enemies, point));

                CSimpleArtillary objCannon = new CSimpleArtillary(1, 1, 1, 0);
                objCannon.SetLocation(point);

                this.Enemies[i] = objCannon;
            }

            this.FriendliesTotalAmmunition = 0;
            foreach (CSimpleArtillary Cannon in this.Friendlies)
            {
                this.FriendliesTotalAmmunition += Cannon.Ammunition;
            }
        }

        public CSimpleArtillary[] GetMutatedFriendlyArtillary()
        {
            CSimpleArtillary[] FriendlyArtillary = new CSimpleArtillary[this.Friendlies.Length];
            for (int i = 0; i < this.Friendlies.Length; i++)
            {
                FriendlyArtillary[i] = this.Friendlies[i].Clone();
                FriendlyArtillary[i].Mutate();
            }

            return FriendlyArtillary;
        }

        public CSimpleArtillary[] GetEnemyArtillary()
        {
            CSimpleArtillary[] EnemyArtillary = new CSimpleArtillary[this.Enemies.Length];
            for (int i = 0; i < this.Enemies.Length; i++)
            {
                EnemyArtillary[i] = this.Enemies[i].Clone();
            }

            return EnemyArtillary;
        }

        public int GetFriendlyCount()
        {
            return this.Friendlies.Length;
        }

        public int GetEnemyCount()
        {
            return this.Enemies.Length;
        }

        public void Draw(Graphics g)
        {
            this.Terrain.Draw(g);
        }

        private float CenterizeArtillaryInGrid(double nNum)
        {
            return (float)nNum * this.Terrain.CellSize + this.Terrain.CellSize / 2 - CSimpleArtillary.ArtilSize / 2;
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
