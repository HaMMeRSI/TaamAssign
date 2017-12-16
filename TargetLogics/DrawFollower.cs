using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaamLogics
{
    public class DrawFollower
    {
        public int[] RotationsCount { get; set; }
        public int[] RotationsConstraint { get; set; }

        public int this[int key]
        {
            get
            {
                return this.RotationsCount[key];
            }
            set
            {
                this.RotationsCount[key] = value;
            }
        }

        public DrawFollower()
        {
            this.RotationsCount = Shared.SafeArray<int>(TaamCalendar.ChunksCount);
            this.RotationsConstraint = Shared.SafeArray<int>(TaamCalendar.ChunksCount);
        }
    }
}
