using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetLogics
{
    public class SlimEnemy : ICloneable<SlimEnemy>
    {
        public int UID { get; set; }
        public List<int> HittedBy { get; set; }
        public float Health { get; set; }

        public SlimEnemy(int UID)
        {
            this.UID = UID;
            this.Health = 1;
            this.HittedBy = new List<int>();
        }

        private SlimEnemy(int UID, List<int> HittedBy, float Health)
        {
            this.UID = UID;
            this.Health = Health;
            this.HittedBy = new List<int>(HittedBy);
        }

        public SlimEnemy Clone()
        {
            return new SlimEnemy(this.UID, this.HittedBy, this.Health);
        }

        public override string ToString()
        {
            return string.Format("UID: {0}, HittedBy: {1}, Health: {2}", this.UID, this.HittedBy.Count, this.Health);
        }
    }
}
