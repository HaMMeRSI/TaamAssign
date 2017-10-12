using System;
using Library;

namespace TargetLogics
{
    public class SingleTargetFriendly : ISlim
    {
        public int UID { get; set; }
        public int CannonUID { get; set; }
        public int Target { get; set; }

        public SingleTargetFriendly(int UID, int CannonUID)
        {
            this.UID = UID;
            this.CannonUID = CannonUID;
            this.Target = -1;
        }

        public void ResetTarget()
        {
            this.Target = -1;
        }

        public object Clone()
        {
            SingleTargetFriendly Cannon = new SingleTargetFriendly(this.UID, this.CannonUID);
            Cannon.Target = this.Target;

            return Cannon;
        }

        public override string ToString()
        {
            return string.Format("UID: {0}, CannonUID: {1}, Target: {2}", this.UID, this.CannonUID, this.Target);
        }
    }
}
