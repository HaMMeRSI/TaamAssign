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
        private Point2D[] Friendlies;
        private Point2D[] Enemies;

        public TargetingStrategy(int nFriendlyCount, int nEnemyCount)
        {
            this.Terrain = new CMap(10, 100);
            this.Friendlies = new Point2D[nFriendlyCount];
            this.Enemies = new Point2D[nEnemyCount];

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

                this.Friendlies[i] = point;
            }

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
                this.Enemies[i] = point;
            }
        }

        public CSimpleArtillary[] GetFriendlyArtillary()
        {
            CSimpleArtillary[] FriendlyArtillary = new CSimpleArtillary[this.Friendlies.Length];
            for (int i = 0; i < this.Friendlies.Length; i++)
            {
                CSimpleArtillary obj = new CSimpleArtillary();
                obj.InitiateGenome();
                obj.SetLocation(this.Friendlies[i]);
                FriendlyArtillary[i] = obj;
            }

            return FriendlyArtillary;
        }

        public CSimpleArtillary[] GetEnemyArtillary()
        {
            CSimpleArtillary[] EnemyArtillary = new CSimpleArtillary[this.Enemies.Length];
            for (int i = 0; i < this.Enemies.Length; i++)
            {
                CSimpleArtillary obj = new CSimpleArtillary();
                // obj.InitiateGenome();
                obj.SetLocation(this.Enemies[i]);
                EnemyArtillary[i] = obj;
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

        private bool Contains(Point2D[] list, Point2D Target)
        {
            foreach (Point2D item in list)
            {
                if(item == null)
                {
                    return false;
                }

                if(item.Equals(Target))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
