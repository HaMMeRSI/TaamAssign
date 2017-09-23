using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TargetLogics
{
    public class CMap: ILive
    {
        public int[,] Map { get; set; }
        public int CellSize { get; set; }

        public CMap(int nMapSize, int nCellSize)
        {
            this.Map = new int[nMapSize, nMapSize];
            this.CellSize = nCellSize;
        }

        public int GetWidth()
        {
            return this.Map.GetLength(0) * this.CellSize;
        }

        public int GetHeight()
        {
            return this.Map.GetLength(1) * this.CellSize;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        Pen p = new Pen(Color.Black, 2);
        public void Draw(Graphics g)
        {
            for (int y = 0; y < this.Map.GetLength(0); ++y)
            {
                g.DrawLine(p, 0, y * this.CellSize, this.Map.GetLength(0) * this.CellSize, y * this.CellSize);
            }

            for (int x = 0; x < this.Map.GetLength(0); ++x)
            {
                g.DrawLine(p, x * this.CellSize, 0, x * this.CellSize, this.Map.GetLength(0) * this.CellSize);
            }

            g.DrawLine(p, 0, (this.Map.GetLength(0) + 0) * this.CellSize, (this.Map.GetLength(0) + 0) * this.CellSize, (this.Map.GetLength(0) + 0) * this.CellSize);
            g.DrawLine(p, (this.Map.GetLength(0) + 0) * this.CellSize, 0, (this.Map.GetLength(0) + 0) * this.CellSize, (this.Map.GetLength(0) + 0) * this.CellSize);
        }
    }
}
