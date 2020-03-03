using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaamLogics
{
    public class BattalionAssigner
    {
        public List<int> FreeBattalion { get; set; }
        public List<int> BusyBattalion { get; set; }
        public Dictionary<int, List<int>> BattalionRotations { get; set; }

        public BattalionAssigner()
        {
            this.FreeBattalion = new List<int>();
            this.BusyBattalion = new List<int>();
            this.BattalionRotations = new Dictionary<int, List<int>>();

            foreach (CSimpleBattalion Battalion in CStrategyPool.ActiveStrategy.BattalionsData)
            {
                this.FreeBattalion.Add(Battalion.UID);
            }
            foreach (CSimpleBattalion Battalion in CStrategyPool.ActiveStrategy.BattalionsData)
            {
                this.FreeBattalion.Add(Battalion.UID);
            }
        }

        public int GetFreeBattalion(int Rotation)
        {
            int SelectedBattalion = -1;
            if (this.FreeBattalion.Count <= 0)
            {
                throw new Exception("Empty Battalion list");
            }

            int Index = Shared.Next(this.FreeBattalion.Count);
            SelectedBattalion = this.FreeBattalion[Index];
            this.FreeBattalion.RemoveAt(Index);
            this.BusyBattalion.Add(SelectedBattalion);

            if (!this.BattalionRotations.ContainsKey(SelectedBattalion))
            {
                this.BattalionRotations[SelectedBattalion] = new List<int>();
                this.BattalionRotations[SelectedBattalion].Add(Rotation);
            }
            else
            {
                for (int i = 0; i < this.BattalionRotations[SelectedBattalion].Count; i++)
                {
                    if (Rotation >= this.BattalionRotations[SelectedBattalion][i])
                    {
                        this.BattalionRotations[SelectedBattalion].Insert(i, Rotation);
                        break;
                    }
                }
            }

            return SelectedBattalion;
        }

        public void ReleaseBattalion(int Rotation, int BattalionUID)
        {
            this.BusyBattalion.Remove(BattalionUID);
            this.FreeBattalion.Add(BattalionUID);
            this.BattalionRotations[Rotation].Remove(Rotation);
        }

        public int GetAssignmentScore(int MinRotationDistance)
        {
            int TotalAssignmentScore = 0;
            foreach (var Rotations in this.BattalionRotations.Values)
            {
                for (int i = 0; i < Rotations.Count - 1; i++)
                {
                    if (Rotations[i + 1] - Rotations[i] < MinRotationDistance)
                    {
                        TotalAssignmentScore += 1;
                    }
                }
            }

            return TotalAssignmentScore;
        }
    }
}
