using Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetLogics
{
    public class CWorld: IDrawable
    {
        public CMap Terrain { get; set; }
        const int ArtilSize = 50;
        public List<CSimpleArtillary> Friendly { get; set; }
        public List<CSimpleArtillary> Enemy { get; set; }

        public CWorld()
        {
            this.Terrain = new CMap(10, 100);
            this.Friendly = new List<CSimpleArtillary>();
            this.Enemy = new List<CSimpleArtillary>();

            this.InitiallizeArny();
        }

        public void InitiallizeArny()
        {
            for (int i = 0; i < 15; i++)
            {
                CSimpleArtillary obj = new CSimpleArtillary();
                obj.SetLocation(this.Centerize(Shared.Next(this.Terrain.GetColSize())), this.Centerize(this.Terrain.GetRowSize() - Shared.Next(this.Terrain.GetRowSize() / 3) - 1));
                this.Friendly.Add(obj);
            }

            for (int i = 0; i < 10; i++)
            {
                CSimpleArtillary obj = new CSimpleArtillary();
                obj.SetLocation(this.Centerize(Shared.Next(this.Terrain.GetColSize())), this.Centerize(Shared.Next(this.Terrain.GetRowSize() / 3)));
                this.Enemy.Add(obj);
            }
        }

        public void Draw(Graphics g)
        {
            this.Terrain.Draw(g);

            foreach (CSimpleArtillary artil in this.Friendly)
            {
                g.FillEllipse(new SolidBrush(Color.Cyan), (float)artil.Location.X, (float)artil.Location.Y, ArtilSize, ArtilSize);
            }

            foreach (CSimpleArtillary artil in this.Enemy)
            {
                g.FillEllipse(new SolidBrush(Color.Red), (float)artil.Location.X, (float)artil.Location.Y, ArtilSize, ArtilSize);
            }
        }

        private float Centerize(double nNum)
        {
            return (float)nNum * this.Terrain.CellSize + this.Terrain.CellSize / 2 - ArtilSize / 2;
        }
    }
}
