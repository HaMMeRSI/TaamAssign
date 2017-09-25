using EvolutionaryLogic;
using Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetLogics
{
    public class CWorld: DNA<CSimpleArtillary>, IDrawable
    {
        public CSimpleArtillary[] Enemies { get; set; }
        public int DeadCount { get; set; }
        private TargetingStrategy Strategy{ get; set; }

        public CWorld(TargetingStrategy Strategy)
            :base(Strategy.GetFriendlyCount())
        {
            this.Strategy = Strategy;
            this.DeadCount = 0;

            this.Genes = Strategy.GetFriendlyArtillary();
            this.Enemies = Strategy.GetEnemyArtillary();
            this.Execute();
        }

        public void Execute()
        {
            bool blnEndIndicator = false;
            while (!blnEndIndicator)
            {
                if (this.DeadCount == this.Enemies.Length) break;

                blnEndIndicator = true;
                foreach (CSimpleArtillary Cannon in this.Genes)
                {
                    if (Cannon.Targets.Count < Cannon.ShotsToFire)
                    {
                        this.DeadCount += Cannon.Shoot(this.Enemies);
                    }

                    blnEndIndicator &= Cannon.Targets.Count == Cannon.ShotsToFire;
                }
            }
        }
        
        public override void CalculateFitness()
        {
            int nDeadDiff = this.Enemies.Length - this.DeadCount;

            this.Fitness = this.DeadCount;
        }

        protected override void Mutate()
        {
            foreach (CSimpleArtillary Cannon in this.Genes)
            {
                if(Shared.HitChance(.01))
                {
                    Cannon.InitiateGenome();
                }
            }
        }

        public override IDNA Clone()
        {
            CWorld c =  new CWorld(this.Strategy);
            c.Genes = this.Genes;
            c.Enemies = this.Enemies;

            return c;
        }

        #region Render

        Pen p = new Pen(Color.Green, 2);
        public void Draw(Graphics g)
        {
            foreach (CSimpleArtillary MyCannon in this.Enemies)
            {
                g.FillEllipse(new SolidBrush(Color.Red), (float)MyCannon.Location.X, (float)MyCannon.Location.Y, CSimpleArtillary.ArtilSize, CSimpleArtillary.ArtilSize);
            }

            foreach (CSimpleArtillary MyCannon in this.Genes)
            {
                g.FillEllipse(new SolidBrush(Color.Cyan), (float)MyCannon.Location.X, (float)MyCannon.Location.Y, CSimpleArtillary.ArtilSize, CSimpleArtillary.ArtilSize);

                foreach (CSimpleArtillary EnemyCannon in MyCannon.Targets)
                {
                    g.DrawLine(p, this.CentralizeShoot(MyCannon.Location), CentralizeShoot(EnemyCannon.Location));
                }
            }
        }

        private Point2D CentralizeShoot(Point2D Original)
        {
            return new Point2D(Original.X + CSimpleArtillary.ArtilSize / 2, Original.Y + CSimpleArtillary.ArtilSize / 2);
        }

        #endregion
    }
}
