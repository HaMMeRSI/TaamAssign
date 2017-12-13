using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaamLogics
{
    public class BattalionAssignmentFollower
    {
        public List<int> Rotations { get; set; }
        // public Dictionary<int, int> Sectors { get; set; }
        public bool SectorsValid { get; set; }
        public List<int> Sectors { get; set; }

        public BattalionAssignmentFollower()
        {
            this.Rotations = new List<int>();
            this.Sectors = new List<int>();
            this.SectorsValid = true;
        }

        public void AddSector(int SectorUID)
        {
            if(this.Sectors.Contains(SectorUID))
            {
                this.SectorsValid = false;
            }

            this.Sectors.Add(SectorUID);
        }

        public void AddRotation(int Rotation)
        {
            int x = this.Rotations.BinarySearch(Rotation);
            this.Rotations.Insert((x >= 0) ? x : ~x, Rotation);
            //for (int i = 0; i < this.Rotations.Count; i++)
            //{
            //    if(Rotation <= this.Rotations[i])
            //    {
            //        this.Rotations.Insert(i, Rotation);
            //        return;
            //    }
            //}

            //this.Rotations.Add(Rotation);
        }
    }
}
