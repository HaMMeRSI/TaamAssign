using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetLogics
{
    public class CTarget : CSimpleArtillary
    {
        public CTarget(int ForceConstraint, int MaxAccuracyRequired, int nImportance) 
            : base(250, 0, 0, 0, ForceConstraint, 0, MaxAccuracyRequired, nImportance)
        {
        }
    }
}
