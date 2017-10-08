using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetLogics
{
    public class SlimCannon: ICloneable<SlimCannon>
    {
        public int UID { get; set; }
        public int[] Targets { get; set; }
        public float Health { get; set; }

        public SlimCannon(int UID)
        {
            this.UID = UID;
            this.Health = 1;
        }

        public SlimCannon Clone()
        {
            SlimCannon Cannon = new SlimCannon(this.UID);
            Cannon.Targets = (int[])Targets.Clone();

            return Cannon;
        }

        public override string ToString()
        {
            return string.Format("UID: {0}, Targets: {1}, Health: {2}", this.UID, this.Targets?.Length, this.Health);
        }
    }
}
