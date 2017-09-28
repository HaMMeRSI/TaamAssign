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
        public List<CSimpleArtillary> HittedBy { get; set; }

        public List<int> Targets { get; set; }

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

        public CSimpleArtillary SetTargets(List<int> colTargets)
        {
            this.Targets = colTargets;
            return this;
        }

        #endregion

        public CSimpleArtillary(float nRadius, int nAmmunition, float nDamage, int nShotsToFire)
        {
            this.Targets = new List<int>();
            this.HittedBy = new List<CSimpleArtillary>();
            this.Health = 1;
            this.Damage = nDamage;
            this.Radius = nRadius;
            this.Ammunition = nAmmunition;
            this.ShotsToFire = nShotsToFire;
            this.ShotsTaken = 0;
        }

        public CSimpleArtillary(float nRadius, int nAmmunition, float nDamage):
            this(nRadius, nAmmunition, nDamage, 0)
        {
            
        }

        public CSimpleArtillary Mutate()
        {
            this.ShotsToFire = Shared.Next(this.Ammunition + 1);
            this.Targets.Clear();

            return this;
        }

        //public int Shoot(CSimpleArtillary[] colTargets)
        //{
        //    int nTargetInd = Shared.Next(colTargets.Length);
        //    int IsEnemyDead = 0;
        //    this.ShotsTaken++;

        //    if (colTargets[nTargetInd].Health > 0)
        //    {
        //        this.Targets.Add(colTargets[nTargetInd]);
        //        colTargets[nTargetInd].Health -= this.Damage;

        //        if (colTargets[nTargetInd].Health <= 0)
        //        {
        //            IsEnemyDead = 1;
        //        }
        //    }

        //    return IsEnemyDead;
        //}

        public int Shoot(CSimpleArtillary[] colTargets)
        {
            int IsEnemyDead = 0;

            if (this.Targets.Count > this.ShotsTaken)
            {
                CSimpleArtillary currTarget = colTargets[this.Targets[this.ShotsTaken]];
                if (currTarget.Health > 0)
                {
                    currTarget.Health -= this.Damage;
                    currTarget.HittedBy.Add(this);

                    if (currTarget.Health <= 0)
                    {
                        IsEnemyDead = 1;
                    }
                }

                this.ShotsTaken++;
            }

            return IsEnemyDead;
        }

        public void ChooseTarget(CSimpleArtillary[] colTargets)
        {
            int nTargetInd = Shared.Next(colTargets.Length);
            this.Targets.Add(nTargetInd);
        }

        public void ResetGeneome()
        {
            this.Targets = new List<int>();
            this.Health = 1;
            this.ShotsTaken = 0;
        }

        public CSimpleArtillary Clone()
        {
            //List<CSimpleArtillary> colTargets = new List<CSimpleArtillary>();

            //foreach (CSimpleArtillary EnemyCannon in this.Targets)
            //{
            //    colTargets.Add(EnemyCannon.Clone());
            //}

            return (new CSimpleArtillary(this.Radius, this.Ammunition, this.Damage, this.ShotsToFire))
                .SetLocation(this.Location.Clone())
                .SetTargets(new List<int>(this.Targets));
        }

        Pen p = new Pen(Color.Green, 2);
        public void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Cyan), (float)this.Location.X, (float)this.Location.Y, CSimpleArtillary.ArtilSize, CSimpleArtillary.ArtilSize);
            //foreach (CSimpleArtillary EnemyCannon in this.Targets)
            //{
            //    g.DrawLine(p, this.CentralizeShoot(this.Location, false), CentralizeShoot(EnemyCannon.Location, true));
            //}

            if (this.HittedBy.Count > 0)
            {
                foreach (CSimpleArtillary Cannon in this.HittedBy)
                {
                    g.DrawLine(p, this.CentralizeShoot(this.Location, true), CentralizeShoot(Cannon.Location, false));
                }
            }
            g.DrawString(this.ShotsToFire.ToString(), new Font("Microsoft Sans Serif", 12),new SolidBrush(Color.Black), (float)this.Location.X, (float)this.Location.Y);
            g.DrawString(this.Ammunition.ToString(), new Font("Microsoft Sans Serif", 12),new SolidBrush(Color.Black), (float)this.Location.X + 20, (float)this.Location.Y);
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
