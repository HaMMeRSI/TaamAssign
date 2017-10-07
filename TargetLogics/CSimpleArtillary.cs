using Library;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace TargetLogics
{
    public class CSimpleArtillary: ILive, INextGeneration<CSimpleArtillary>
    {
        public const int ArtilSize = 50;
        public int UID { get; set; }

        #region Stats / Static data

        public float Range { get; set; }
        public float Damage { get; set; }
        public int PriceForShot { get; set; }
        public int Ammunition { get; set; }
        public int ForceConstraint { get; set; }
        public int Accuracy { get; set; }
        public int MaxAccuracyRequired { get; set; }
        public int Importance { get; set; }
        public Point2D Location { get; set; }
        public Color MyColor { get; set; }

        #endregion

        public float Health { get; set; }
        public int ShotsTaken { get; set; }
        public List<CSimpleArtillary> HittedBy { get; set; }
        public List<int> Targets { get; set; }

        private Point2D RenderLoc { get; set; }

        #region Builder

        public CSimpleArtillary SetLocation(double nX, double nY)
        {
            this.Location.X = nX;
            this.Location.Y = nY;
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

        public CSimpleArtillary SetHittedBy(List<CSimpleArtillary> colCannons)
        {
            this.HittedBy = colCannons;
            return this;
        }

        public CSimpleArtillary SetUID(int UID)
        {
            this.UID = UID;
            return this;
        }

        #endregion

        public CSimpleArtillary(float fRange, int nAmmunition, float fDamage, int nPriceForShot, int ForceConstraint, int nAccuracy, int MaxAccuracyRequired, int nImportance)
            :this(1, fRange, nAmmunition, 0, fDamage, nPriceForShot, ForceConstraint, nAccuracy, MaxAccuracyRequired, nImportance)
        {
        }

        protected CSimpleArtillary(float fHealth, float fRange, int nAmmunition, int nShotsTaken, float fDamage, int nPriceForShot, int ForceConstraint, int nAccuracy, int MaxAccuracyRequired, int nImportance)
        {
            this.Targets = new List<int>();
            this.HittedBy = new List<CSimpleArtillary>();
            this.Health = fHealth;
            this.Damage = fDamage;
            this.Range = fRange;
            this.Ammunition = nAmmunition;
            this.ShotsTaken = nShotsTaken;
            this.PriceForShot = nPriceForShot;
            this.ForceConstraint = ForceConstraint;
            this.Accuracy = nAccuracy;
            this.MaxAccuracyRequired = MaxAccuracyRequired;
            this.Importance = nImportance;
            this.Location = new Point2D();
            this.MyColor = Color.FromArgb(
                255,
                (ForceConstraint & (int)ENUMForces.Air) / (int)ENUMForces.Air * 255,
                (ForceConstraint & (int)ENUMForces.Land) / (int)ENUMForces.Land * 255,
                (ForceConstraint & (int)ENUMForces.Sea) / (int)ENUMForces.Sea * 255);
        }


        public int Fire(CSimpleArtillary[] colTargets)
        {
            int IsEnemyDead = 0;

            if (this.Targets.Count > this.ShotsTaken)
            {
                CSimpleArtillary currTarget = colTargets[this.Targets[this.ShotsTaken]];

                if (this.CheckFireConstraints(currTarget))
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

        private bool CheckFireConstraints(CSimpleArtillary Target)
        {
            return 
                this.Location.Distance(Target.Location) <= this.Range / 2 && 
                (Target.ForceConstraint & this.ForceConstraint) > 0 &&
                this.Accuracy <= Target.MaxAccuracyRequired;
        }

        public void ChooseTargets(CSimpleArtillary[] colTargets)
        {
            for (int i = 0; i < this.Ammunition; i++)
            {
                this.Targets.Add(Shared.Next(colTargets.Length));
            }
        }

        public CSimpleArtillary Mutate()
        {
            this.Targets.Clear();
            return this;
        }

        public CSimpleArtillary Clone()
        {
            return (new CSimpleArtillary(this.Health, this.Range, this.Ammunition, this.ShotsTaken, this.Damage, this.PriceForShot, this.ForceConstraint, this.Accuracy, this.MaxAccuracyRequired, this.Importance))
                .SetLocation(this.Location.X, this.Location.Y)
                .SetUID(this.UID)
                .SetTargets(new List<int>(this.Targets))
                .SetHittedBy(new List<CSimpleArtillary>(this.HittedBy));
        }

        public CSimpleArtillary Revive()
        {
            return (new CSimpleArtillary(this.Range, this.Ammunition, this.Damage, this.PriceForShot, this.ForceConstraint, this.Accuracy, this.MaxAccuracyRequired, this.Importance))
                .SetLocation(this.Location.X, this.Location.Y)
                .SetUID(this.UID)
                .SetTargets(new List<int>(this.Targets));
        }

        public void ResetStatus()
        {
            this.Health = 1;
            this.ShotsTaken = 0;
            this.Targets.Clear();
            this.HittedBy.Clear();
        }

        #region ILive

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
            g.FillEllipse(new SolidBrush(this.MyColor), (float)this.RenderLoc.X, (float)this.RenderLoc.Y, CSimpleArtillary.ArtilSize, CSimpleArtillary.ArtilSize);

            if (this.HittedBy.Count > 0 && this.Health <= 0)
            {
                foreach (CSimpleArtillary Cannon in this.HittedBy)
                {
                    Pen pp = new Pen(Cannon.MyColor, 2);
                    g.DrawLine(pp, this.CentralizeShoot(this.Location, this.HittedBy.Count > 1), CentralizeShoot(Cannon.Location, false));
                }
            }

            if (this.DrawRange)
            {
                string DataOutput = string.Format(
@"Damage: {0}
Importance: {7}
Ammo: {3}
Accuracy: {5}
Max accuracy: {6}
Price: {4}
Range: {2}
HP: {1}
", this.Damage, this.Health, this.Range, this.Ammunition, this.PriceForShot, this.Accuracy, this.MaxAccuracyRequired, this.Importance);
                g.FillEllipse(new SolidBrush(Color.FromArgb(127, 255, 0, 0)), new RectangleF((float)this.Location.X - this.Range / 2, (float)this.Location.Y - this.Range / 2, this.Range, this.Range));
                g.DrawString(DataOutput, new Font("Microsoft Sans Serif", 12), new SolidBrush(Color.White), (float)this.RenderLoc.X-20, (float)this.RenderLoc.Y-45);
            }
            else
            {
                g.DrawString("A: " + this.Ammunition.ToString(), new Font("Microsoft Sans Serif", 12), new SolidBrush(Color.White), (float)this.Location.X - 15, (float)this.Location.Y - 20);
                g.DrawString("P: " + this.PriceForShot.ToString(), new Font("Microsoft Sans Serif", 12), new SolidBrush(Color.White), (float)this.Location.X - 15, (float)this.Location.Y);
            }
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

        #endregion

        public override string ToString()
        {
            return string.Format("UID: {0}, HP: {1}, HitBy: {2}, Targets:{3}", this.UID, Health, HittedBy.Count, Targets.Count);
        }

    }
}
