using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetLogics
{
    public class CArtillary : CSimpleArtillary
    {
        public CArtillary(float fRange, int nAmmunition, float fDamage, int nPriceForShot, int ForceConstraint, int nAccuracy) : 
            base(fRange, nAmmunition, fDamage, nPriceForShot, ForceConstraint, nAccuracy, 0, 0)
        {
        }
    }
}
