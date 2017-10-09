using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetLogics
{
    public class SlimFriendly: ICloneable<SlimFriendly>
    {
        public int UID { get; set; }
        public int[] Targets { get; set; }

        public SlimFriendly(int UID)
        {
            this.UID = UID;
        }

        public SlimFriendly Clone()
        {
            SlimFriendly Cannon = new SlimFriendly(this.UID);
            Cannon.Targets = (int[])Targets.Clone();

            return Cannon;
        }

        public override string ToString()
        {
            return string.Format("UID: {0}, Targets: {1}", this.UID, this.Targets?.Length);
        }
    }
}
