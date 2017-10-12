﻿using Library;
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

        public CSimpleArtillary SetUID(int UID)
        {
            this.UID = UID;
            return this;
        }

        #endregion

        public CSimpleArtillary(float fRange, int nAmmunition, float fDamage, int nPriceForShot, int ForceConstraint, int nAccuracy, int MaxAccuracyRequired, int nImportance)
        {
            this.Damage = fDamage;
            this.Range = fRange;
            this.Ammunition = nAmmunition;
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


        public int Fire(CSimpleArtillary ActualTargets, SlimEnemy SlimEnemy, SlimFriendly Cannon)
        {
            int IsEnemyDead = 0;

            if (Cannon.Targets.Length > Cannon.ShotsTaken)
            {
                if (SlimEnemy.Health > 0 && this.CheckFireConstraints(ActualTargets))
                {
                    SlimEnemy.Health -= this.Damage;
                    SlimEnemy.HittedBy.Add(this.UID);

                    if (SlimEnemy.Health <= 0)
                    {
                        IsEnemyDead = 1;
                    }
                }

                Cannon.ShotsTaken++;
            }

            return IsEnemyDead;
        }

        public int Fire(CSimpleArtillary ActualTarget, SlimEnemy SlimEnemy, SingleTargetFriendly Cannon)
        {
            int IsEnemyDead = 0;

            if (SlimEnemy.Health > 0 && this.CheckFireConstraints(ActualTarget))
            {
                SlimEnemy.Health -= this.Damage;
                SlimEnemy.HittedBy.Add(Cannon.CannonUID);

                if (SlimEnemy.Health <= 0)
                {
                    IsEnemyDead = 1;
                }
            }

            return IsEnemyDead;
        }

        private bool CheckFireConstraints(CSimpleArtillary Target)
        {
            return 
                this.Location.Dot(Target.Location) <= this.Range * this.Range / 4 && 
                (Target.ForceConstraint & this.ForceConstraint) > 0 &&
                this.Accuracy <= Target.MaxAccuracyRequired;
        }

        public CSimpleArtillary Clone()
        {
            return (new CSimpleArtillary(this.Range, this.Ammunition, this.Damage, this.PriceForShot, this.ForceConstraint, this.Accuracy, this.MaxAccuracyRequired, this.Importance))
                .SetLocation(this.Location.X, this.Location.Y)
                .SetUID(this.UID);
        }

        public CSimpleArtillary Revive()
        {
            return (new CSimpleArtillary(this.Range, this.Ammunition, this.Damage, this.PriceForShot, this.ForceConstraint, this.Accuracy, this.MaxAccuracyRequired, this.Importance))
                .SetLocation(this.Location.X, this.Location.Y)
                .SetUID(this.UID);
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

            //if (this.HittedBy.Count > 0 && this.Health <= 0)
            //{
            //    foreach (int Cannon in this.HittedBy)
            //    {
            //        Pen pp = new Pen(Cannon.MyColor, 2);
            //        g.DrawLine(pp, this.CentralizeShoot(this.Location, this.HittedBy.Count > 1), CentralizeShoot(Cannon.Location, false));
            //    }
            //}

            if (this.DrawRange)
            {
                string DataOutput = string.Format(
@"Damage: {0}
Importance: {6}
Ammo: {2}
Accuracy: {4}
Max accuracy: {5}
Price: {3}
Range: {1}
", this.Damage, this.Range, this.Ammunition, this.PriceForShot, this.Accuracy, this.MaxAccuracyRequired, this.Importance);
                g.FillEllipse(new SolidBrush(Color.FromArgb(127, 255, 0, 0)), new RectangleF((float)this.Location.X - this.Range / 2, (float)this.Location.Y - this.Range / 2, this.Range, this.Range));
                g.DrawString(DataOutput, new Font("Microsoft Sans Serif", 12), new SolidBrush(Color.White), (float)this.RenderLoc.X-20, (float)this.RenderLoc.Y-45);
            }
            else
            {
                g.DrawString("A: " + this.Ammunition.ToString(), new Font("Microsoft Sans Serif", 12), new SolidBrush(Color.Black), (float)this.Location.X - 15, (float)this.Location.Y - 20);
                g.DrawString("P: " + this.PriceForShot.ToString(), new Font("Microsoft Sans Serif", 12), new SolidBrush(Color.Black), (float)this.Location.X - 15, (float)this.Location.Y);
            }
        }

        public static Point2D CentralizeShoot(Point2D Original, bool Randomize)
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
            return string.Format("UID: {0}", this.UID);
        }
    }
}
