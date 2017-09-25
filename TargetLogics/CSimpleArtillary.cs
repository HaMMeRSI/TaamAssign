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
        public float Ammunition
        {
            get
            {
                return this[2];
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

        #endregion

        #region Builder

        public CSimpleArtillary SetLocation(float nX, float nY)
        {
            this.Location = new Point2D(nX, nY);
            return this;
        }

        #endregion

        public CSimpleArtillary() : 
            base(4)
        {
            // Radius
            this[0] = Shared.Next(25) + 1;

            // Damage
            this[1] = Shared.Next(5) + 1;

            // Ammunition
            this[2] = Shared.Next(3) + 1;

            // Health
            this[3] = Shared.Next(5) + 1;
        }


        public override void CalculateFitness(string target)
        {
            throw new NotImplementedException();
        }

        protected override void Mutate()
        {
            throw new NotImplementedException();
        }

        protected override IDNA GetObj()
        {
            return new CSimpleArtillary(this.Genes.Length);
        }
    }
}
