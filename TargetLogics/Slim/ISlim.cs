using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetLogics
{
    public interface ISlim : ICloneable, IIdentifiable
    {
        void ResetTarget();
    }
}
