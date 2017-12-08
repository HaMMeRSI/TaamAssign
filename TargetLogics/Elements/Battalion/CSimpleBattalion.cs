using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaamLogics
{
    public class CSimpleBattalion
    {
        public const int RenderSize = 50;

        public int UID { get; set; }
        public Point2D Location { get; set; }
        public List<Reservation> Reservations { get; set; }
        public EConstraints Force { get; set; }
        public int Price { get; set; }
        public int Justice { get; set; }

        #region Builder
        private Point2D RenderLoc { get; set; }

        public CSimpleBattalion SetLocation(double nX, double nY)
        {
            this.Location.X = nX;
            this.Location.Y = nY;
            this.RenderLoc = new Point2D(nX - RenderSize / 2, nY - RenderSize / 2);
            return this;
        }

        public CSimpleBattalion SetLocation(Point2D Location)
        {
            this.Location = Location;
            this.RenderLoc = new Point2D(Location.X - RenderSize / 2, Location.Y - RenderSize / 2);
            return this;
        }

        public CSimpleBattalion SetUID(int UID)
        {
            this.UID = UID;
            return this;
        }

        #endregion

        public CSimpleBattalion(EConstraints Force, int Price)
        {
            this.Location = new Point2D();
            this.Reservations = new List<Reservation>();
            this.Force = Force;
            this.Price = Price;
            this.Justice = 0;
        }

        public int ScoreAssignment(CSingleAssignment Assignment)
        {
            int Score = 0;
            foreach (Reservation item in this.Reservations)
            {
                Score += item.Date >= Assignment.Start && item.Date <= Assignment.End ? (int)item.Importance : 0;
            }

            return Score;
        }

        public int GetReservationsScore()
        {
            return this.Reservations.Sum(x => (int)x.Importance);
        }
    }
}
