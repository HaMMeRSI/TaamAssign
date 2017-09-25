using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using EvolutionaryLogic;

namespace TargetLogics
{
    public class CSimpleArtillary
    {
        public const int ArtilSize = 50;
        public Point2D Location { get; set; }

        public float Radius { get; set; }
        public float Damage { get; set; }
        public int Ammunition { get; set; }
        public float Health { get; set; }
        public int ShotsToFire { get; set; }

        public int ShotsTaken { get; set; }
        public List<CSimpleArtillary> Targets { get; set; }

        #region Builder

        public CSimpleArtillary SetLocation(float nX, float nY)
        {
            this.Location = new Point2D(nX, nY);
            return this;
        }

        public CSimpleArtillary SetLocation(Point2D Location)
        {
            this.Location = Location;
            return this;
        }

        #endregion

        public CSimpleArtillary()
        {
            this.ShotsTaken = 0;
            this.Targets = new List<CSimpleArtillary>();
            this.Health = 1;// Shared.Next(5) + 1;
        }

        public void InitiateGenome()
        {
            this.Radius = Shared.Next(25) + 1;
            this.Damage = Shared.Next(5) + 1;
            this.Ammunition = Shared.Next(3) + 1;
            this.Health = 1;// Shared.Next(5) + 1;
            this.ShotsToFire = Shared.Next(this.Ammunition + 1);
        }

        public int Shoot(CSimpleArtillary[] colTargets)
        {
            int nTargetInd = Shared.Next(colTargets.Length);
            int IsEnemyDead = 0;

            if (colTargets[nTargetInd].Health > 0)
            {
                this.Targets.Add(colTargets[nTargetInd]);
                colTargets[nTargetInd].Health -= this.Damage;

                if(colTargets[nTargetInd].Health <= 0)
                {
                    IsEnemyDead = 1;
                }
            }

            return IsEnemyDead;
        }
    }
}
