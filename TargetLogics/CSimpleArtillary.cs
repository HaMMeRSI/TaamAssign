using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TargetLogics
{
    public class CSimpleArtillary
    {
        public double Radius { get; set; }
        public int Damage { get; set; }
        public int Ammunition { get; set; }
        public int Health { get; set; }
        public Point2D Location { get; set; }


        public CSimpleArtillary()
        {

        }

        public CSimpleArtillary SetLocation(float nX, float nY)
        {
            this.Location = new Point2D(nX, nY);
            return this;
        }

        public void Randomize()
        {
            this.Radius = Shared.Next(25) + 1;
            this.Damage = Shared.Next(5) + 1;
            this.Ammunition = Shared.Next(3) + 1;
            this.Health = Shared.Next(5) + 1;
        }
    }
}
