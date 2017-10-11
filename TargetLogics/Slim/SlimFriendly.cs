using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetLogics
{
    public class SlimFriendly: ICloneable<SlimFriendly>, IIdentifiable
    {
        public int UID { get; set; }
        public int[] Targets { get; set; }
        public int ShotsTaken { get; set; }

        public SlimFriendly(int UID)
        {
            this.UID = UID;
            this.ShotsTaken = 0;
        }

        public SlimFriendly Clone()
        {
            SlimFriendly Cannon = new SlimFriendly(this.UID);
            Cannon.Targets = new int[this.Targets.Length];
            Buffer.BlockCopy(this.Targets, 0, Cannon.Targets, 0, sizeof(int) * this.Targets.Length);

            return Cannon;
        }

        public override string ToString()
        {
            return string.Format("UID: {0}, Targets: {1}", this.UID, this.Targets?.Length);
        }
    }
}
