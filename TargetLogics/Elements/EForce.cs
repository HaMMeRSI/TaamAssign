using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaamLogics
{
    public enum EConstraints
    {
        Air                 = 0b0000_0000_0000_0001,
        Land                = 0b0000_0000_0000_0010,
        Sea                 = 0b0000_0000_0000_0100,
        ArmoredBattalion    = 0b0000_0000_0000_1000,
        Bombers             = 0b0000_0000_0001_0000,
        All                 = 0b1111_1111_1111_1111
    }
}
