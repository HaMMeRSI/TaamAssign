using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TaamLogics
{
    public class CSimpleSector: IDrawable
    {
        public const int RenderSize = 50;

        public int UID { get; set; }
        public EConstraints ForceConstraint { get; set; }
        public Point2D Location { get; set; }
        public ESectorialBrigade MySectorialBrigade { get; set; }
        public DateTime StartOfYear { get; set; }
        public CSimpleBattalion[] AssignedBattalions { get; set; }

        #region Builder

        public CSimpleSector SetLocation(double nX, double nY)
        {
            this.Location.X = nX;
            this.Location.Y = nY;
            return this;
        }

        public CSimpleSector SetLocation(Point2D Location)
        {
            this.Location = Location;
            return this;
        }

        public CSimpleSector SetUID(int UID)
        {
            this.UID = UID;
            return this;
        }

        #endregion

        public CSimpleSector(EConstraints ForceConstraint, ESectorialBrigade MySectorialBrigade, DateTime StartOfYear)
        {
            this.ForceConstraint = ForceConstraint;
            this.MySectorialBrigade = MySectorialBrigade;
            AssignmentStrategy.BrigadesData[MySectorialBrigade].RegisterSector(this);
            this.AssignedBattalions = new CSimpleBattalion[TaamCalendar.ChunksCount];
            this.StartOfYear = StartOfYear.AddDays((AssignmentStrategy.BrigadesData[MySectorialBrigade].MySectors.Count - 1) * 7);
            this.Location = new Point2D(0, 0);  
        }

        SolidBrush b = new SolidBrush(Color.Black);
        Pen p = new Pen(new SolidBrush(Color.Black), 3);
        Font f = new Font(FontFamily.GenericMonospace, 15);
        public void Draw(Graphics g)
        {
            g.DrawString(this.UID.ToString() + ":", f, b, (int)this.Location.X - 130, (int)this.Location.Y + 40);
            g.DrawString(this.MySectorialBrigade.ToString() + ":", f, b, (int)this.Location.X - 130, (int)this.Location.Y + 60);
            g.DrawRectangle(p, (int)this.Location.X, (int)this.Location.Y, 800, 100);

            for (int i = 0; i < TaamCalendar.ChunksCount; i++)
            {
                g.DrawLine(p, (int)this.Location.X + 200 * i, (int)this.Location.Y, (int)this.Location.X + 200 * i, (int)this.Location.Y + 100);
                if(this.AssignedBattalions[i] != null)
                {
                    int OffsetX = 90 + (200 * i);
                    g.DrawString(this.AssignedBattalions[i].UID.ToString(), f, b, (int)this.Location.X + OffsetX, (int)this.Location.Y + 40);
                }
            }
        }
    }
}
