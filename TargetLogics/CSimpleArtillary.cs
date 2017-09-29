using Library;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace TargetLogics
{
    public class CSimpleArtillary: ILive
    {
        public const int ArtilSize = 50;
        public Point2D Location { get; set; }

        public float Range { get; set; }
        public float Damage { get; set; }
        public int Ammunition { get; set; }
        public float Health { get; set; }
        public int ShotsToFire { get; set; }
        public int ShotsTaken { get; set; }
        public List<CSimpleArtillary> HittedBy { get; set; }

        public List<int> Targets { get; set; }
        Pen p = new Pen(Color.Green, 2);
        private Point2D RenderLoc { get; set; }
        #region Builder

        public CSimpleArtillary SetLocation(float nX, float nY)
        {
            this.Location = new Point2D(nX, nY);
            this.RenderLoc = new Point2D(nX - ArtilSize / 2, nY - ArtilSize / 2);
            return this;
        }

        public CSimpleArtillary SetLocation(Point2D Location)
        {
            this.Location = Location;
            this.RenderLoc = new Point2D(Location.X - ArtilSize / 2, Location.Y - ArtilSize / 2);
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
            this.Range = nRadius;
            this.Ammunition = nAmmunition;
            this.ShotsToFire = nShotsToFire;
            this.ShotsTaken = 0;

            p.Color = Color.FromArgb(Shared.Next(256), Shared.Next(256), Shared.Next(256));
        }

        public CSimpleArtillary(float nRadius, int nAmmunition, float nDamage):
            this(nRadius, nAmmunition, nDamage, nAmmunition)
        {
            
        }

        public CSimpleArtillary Mutate()
        {
            //this.ShotsToFire = Shared.Next(this.Ammunition + 1);
            this.Targets.Clear();

            return this;
        }

        public int Shoot(CSimpleArtillary[] colTargets)
        {
            int IsEnemyDead = 0;

            if (this.Targets.Count > this.ShotsTaken)
            {
                CSimpleArtillary currTarget = colTargets[this.Targets[this.ShotsTaken]];

                if (this.WithinRange(currTarget))
                {
                    if (currTarget.Health > 0)
                    {
                        currTarget.Health -= this.Damage;
                        currTarget.HittedBy.Add(this);

                        if (currTarget.Health <= 0)
                        {
                            IsEnemyDead = 1;
                        }
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

        public void ChooseTargets(CSimpleArtillary[] colTargets)
        {
            int nTargetInd;
            this.Targets.Clear();
            
            for (int i = 0; i < this.ShotsToFire; i++)
            {
                nTargetInd = Shared.Next(colTargets.Length);
                this.Targets.Add(nTargetInd);
            }
        }

        public bool WithinRange(CSimpleArtillary Cannon)
        {
            return this.Location.Distance(Cannon.Location) <= this.Range / 2;
        }

        public void ResetGeneome()
        {
            this.Targets = new List<int>();
            this.Health = 1;
            this.ShotsTaken = 0;
        }

        public CSimpleArtillary Clone()
        {
            return (new CSimpleArtillary(this.Range, this.Ammunition, this.Damage, this.ShotsToFire))
                .SetLocation(this.Location.Clone())
                .SetTargets(new List<int>(this.Targets));
        }

        private Point2D CentralizeShoot(Point2D Original, bool Randomize)
        {
            if (!Randomize)
            {
                return new Point2D(Original.X, Original.Y);
            }

            int randomX = CSimpleArtillary.ArtilSize / 2 - Shared.Next(CSimpleArtillary.ArtilSize);
            int randomY = CSimpleArtillary.ArtilSize / 2 - Shared.Next(CSimpleArtillary.ArtilSize);
            return new Point2D(Original.X + randomX, Original.Y + randomY);
        }

        public bool DrawRange { get; set; }
        public void Update()
        {
            RectangleF rec = new RectangleF((float)this.RenderLoc.X, (float)this.RenderLoc.Y, ArtilSize, ArtilSize);
            if (rec.Contains(Shared.MouseLocation))
            {
                this.DrawRange = true;
            }
            else
            {
                this.DrawRange = false;
            }
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(p.Color), (float)this.RenderLoc.X, (float)this.RenderLoc.Y, CSimpleArtillary.ArtilSize, CSimpleArtillary.ArtilSize);

            if (this.HittedBy.Count > 0 && this.Health <= 0)
            {
                foreach (CSimpleArtillary Cannon in this.HittedBy)
                {
                    Pen pp = new Pen(Cannon.p.Color, 2);
                    g.DrawLine(pp, this.CentralizeShoot(this.Location, true), CentralizeShoot(Cannon.Location, false));
                }
            }

            if (this.DrawRange)
            {
                g.FillEllipse(new SolidBrush(Color.FromArgb(127, 255, 0, 0)), new RectangleF((float)this.Location.X - this.Range / 2, (float)this.Location.Y - this.Range / 2, this.Range, this.Range));
                g.DrawString(this.Damage.ToString(), new Font("Microsoft Sans Serif", 12), new SolidBrush(Color.Black), (float)this.RenderLoc.X, (float)this.RenderLoc.Y);
                g.DrawString(this.Health.ToString(), new Font("Microsoft Sans Serif", 12), new SolidBrush(Color.Black), (float)this.RenderLoc.X, (float)this.RenderLoc.Y + 20);
            }
            else
            {
                g.DrawString(this.ShotsToFire.ToString(), new Font("Microsoft Sans Serif", 12), new SolidBrush(Color.Black), (float)this.RenderLoc.X, (float)this.RenderLoc.Y);
                g.DrawString(this.Ammunition.ToString(), new Font("Microsoft Sans Serif", 12), new SolidBrush(Color.Black), (float)this.RenderLoc.X + 20, (float)this.RenderLoc.Y);
                g.DrawString(this.ShotsTaken.ToString(), new Font("Microsoft Sans Serif", 12), new SolidBrush(Color.Black), (float)this.RenderLoc.X + 40, (float)this.RenderLoc.Y);
                g.DrawString(this.Targets.Count.ToString(), new Font("Microsoft Sans Serif", 12), new SolidBrush(Color.Black), (float)this.RenderLoc.X + 40, (float)this.RenderLoc.Y + 20);
            }
        }
    }
}
