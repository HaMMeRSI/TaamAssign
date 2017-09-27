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
    public class CSimpleArtillary: IDrawable
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

        public CSimpleArtillary(float nRadius, int nAmmunition, float nDamage, int nShotsToFire)
        {
            this.Targets = new List<CSimpleArtillary>();
            this.Health = 1;
            this.Damage = nDamage;
            this.Radius = nRadius;
            this.Ammunition = nAmmunition;
            this.ShotsToFire = nShotsToFire;
            this.ShotsTaken = 0;
        }

        public CSimpleArtillary Mutate()
        {
            this.ShotsToFire = Shared.Next(this.Ammunition + 1);
            return this;
        }

        public int Shoot(CSimpleArtillary[] colTargets)
        {
            int nTargetInd = Shared.Next(colTargets.Length);
            int IsEnemyDead = 0;
            this.ShotsTaken++;

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

        public void ResetGeneome()
        {
            this.Targets = new List<CSimpleArtillary>();
            this.Health = 1;
            this.ShotsTaken = 0;
        }

        public CSimpleArtillary Clone()
        {
            return (new CSimpleArtillary(this.Radius, this.Ammunition, this.Damage, this.ShotsToFire)).SetLocation(this.Location.Clone());
        }

        Pen p = new Pen(Color.Green, 2);
        public void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Cyan), (float)this.Location.X, (float)this.Location.Y, CSimpleArtillary.ArtilSize, CSimpleArtillary.ArtilSize);
            foreach (CSimpleArtillary EnemyCannon in this.Targets)
            {
                g.DrawLine(p, this.CentralizeShoot(this.Location, false), CentralizeShoot(EnemyCannon.Location, true));
            }
            g.DrawString(this.ShotsToFire.ToString(), new Font("Microsoft Sans Serif", 12),new SolidBrush(Color.Black), (float)this.Location.X, (float)this.Location.Y);
            g.DrawString(this.Ammunition.ToString(), new Font("Microsoft Sans Serif", 12),new SolidBrush(Color.Black), (float)this.Location.X + 20, (float)this.Location.Y);
            g.DrawString(this.ShotsTaken.ToString(), new Font("Microsoft Sans Serif", 12),new SolidBrush(Color.Black), (float)this.Location.X + 40, (float)this.Location.Y);
            g.DrawString(this.Targets.Count.ToString(), new Font("Microsoft Sans Serif", 12),new SolidBrush(Color.Black), (float)this.Location.X + 40, (float)this.Location.Y + 20);
        }

        private Point2D CentralizeShoot(Point2D Original, bool Randomize)
        {
            if (!Randomize)
            {
                return new Point2D(Original.X + CSimpleArtillary.ArtilSize / 2, Original.Y + CSimpleArtillary.ArtilSize / 2);
            }

            int randomX = CSimpleArtillary.ArtilSize / 2 - Shared.Next(CSimpleArtillary.ArtilSize);
            int randomY = CSimpleArtillary.ArtilSize / 2 - Shared.Next(CSimpleArtillary.ArtilSize);
            return new Point2D(Original.X + CSimpleArtillary.ArtilSize / 2 + randomX, Original.Y + CSimpleArtillary.ArtilSize / 2 + randomY);
        }
    }
}
