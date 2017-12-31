using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaamLogics
{
    public class CSingleAssignment : ICloneable<CSingleAssignment>
    {
        public int UID { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int BattalionUID { get; set; }
        public int SectorUID { get; set; }

        public CSingleAssignment(int UID, DateTime Start, DateTime End, int SectorUID)
        {
            this.UID = UID;
            this.Start = Start;
            this.End = End;
            this.SectorUID = SectorUID;
            this.BattalionUID = -1;
        }

        public CSingleAssignment Clone()
        {
            CSingleAssignment Copy = new CSingleAssignment(this.UID, new DateTime(this.Start.Ticks), new DateTime(this.End.Ticks), this.SectorUID);
            Copy.BattalionUID = this.BattalionUID;

            return Copy;
        }

        public void Reset()
        {
            this.BattalionUID = -1;
        }

        public override string ToString()
        {
            return "S: " + this.SectorUID + " B: " + this.BattalionUID;
        }
    }
}
