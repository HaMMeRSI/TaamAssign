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
    public class CSimpleArtillary : DNA<float>
    {
        public Point2D Location { get; set; }

        #region Genome

        public float Radius
        {
            get
            {
                return this[0];
            }
            set
            {
                this[0] = value;
            }
        }
        public float Damage
        {
            get
            {
                return this[1];
            }
            set
            {
                this[1] = value;
            }
        }
        public int Ammunition
        {
            get
            {
                return (int)this[2];
            }
            set
            {
                this[2] = value;
            }
        }
        public float Health
        {
            get
            {
                return this[3];
            }
            set
            {
                this[3] = value;
            }
        }
        public int ShotsToFire {
            get
            {
                return (int)this[4];
            }
            set
            {
                this[4] = value;
            }
        }
        
        #endregion

        public int ShotsTaken { get; set; }
        public List<CSimpleArtillary> Targets { get; set; }

        #region Builder

        public CSimpleArtillary SetLocation(float nX, float nY)
        {
            this.Location = new Point2D(nX, nY);
            return this;
        }

        #endregion

        public CSimpleArtillary() : 
            base(5)
        {
            this.ShotsTaken = 0;
            this.Targets = new List<CSimpleArtillary>();
        }

        public void InitiateGenome()
        {
            // Radius
            this[0] = Shared.Next(25) + 1;

            // Damage
            this[1] = Shared.Next(5) + 1;

            // Ammunition
            this[2] = Shared.Next(3) + 1;

            // Health
            this[3] = Shared.Next(5) + 1;

            // Shots to fire
            this[4] = Shared.Next((int)this[2]);
        }

        public void Shoot(List<CSimpleArtillary> colTargets)
        {
            int nTargetInd = Shared.Next(colTargets.Count);

            if (colTargets[nTargetInd].Health > 0)
            {
                this.Targets.Add(colTargets[nTargetInd]);
                colTargets[nTargetInd].Health -= this.Damage;
            }
        }

        public override void CalculateFitness()
        {
            this.Fitness = this.Targets.Count;
        }

        protected override void Mutate()
        {
            throw new NotImplementedException();
        }

        protected override IDNA GetObj()
        {
            return new CSimpleArtillary();
        }
    }
}
