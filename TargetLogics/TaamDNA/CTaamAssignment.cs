using OptimizationLogics;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaamLogics
{
    public class CTaamAssignment : DNA<CSingleAssignment>
    {
        public CTaamAssignment() : this(true)
        {
        }

        private CTaamAssignment(bool InitChunks)
            : base(CStrategyPool.ActiveStrategy.GetSectorsCount() * TaamCalendar.ChunksCount)
        {
            if(InitChunks)
            {
                TaamCalendar CalendarGen = new TaamCalendar();

                for (int SectorUID = 0; SectorUID < CStrategyPool.ActiveStrategy.GetSectorsCount(); SectorUID++)
                {
                    var Taams = CalendarGen.GetTaamChunks(CStrategyPool.ActiveStrategy.SectorsData[SectorUID].StartOfYear);

                    for (int Rotation = 0; Rotation < TaamCalendar.ChunksCount; Rotation++)
                    {
                        this[SectorUID * TaamCalendar.ChunksCount + Rotation] = 
                            new CSingleAssignment(SectorUID * TaamCalendar.ChunksCount + Rotation, Taams[Rotation].Start, Taams[Rotation].End, SectorUID);
                    }
                }
            }
        }

        public override void Execute()
        {
            List<int> BattalionSpread = new List<int>(CStrategyPool.ActiveStrategy.YearlyPotentialBattalion);

            foreach (var Assignment in this.Genes)
            {
                var index = Shared.Next(BattalionSpread.Count);
                Assignment.BattalionUID = BattalionSpread[index];
                BattalionSpread.RemoveAt(index);
            }
        }

        public override void CalculateFitness()
        {
            int[] ReservesionForBattalionScore = Shared.SafeArray<int>(CStrategyPool.ActiveStrategy.GetBattalionsCount());
            Dictionary<int, BattalionAssignmentFollower> BattalionFollowers = new Dictionary<int, BattalionAssignmentFollower>();
            HashSet<int>[] BattalionDestrebution = Shared.SafeArray(TaamCalendar.ChunksCount, () => new HashSet<int>());
            float ConstraintsFitness = 0;

            for (int i = 0; i < this.Genes.Length; i++)
            {
                // Constraint counter
                ConstraintsFitness += this.CalculateConstraintsFitness(i);

                // Reservation follower
                ReservesionForBattalionScore[this.Genes[i].BattalionUID] +=
                    CStrategyPool.ActiveStrategy.BattalionsData[this.Genes[i].BattalionUID].ScoreAssignment(this.Genes[i].Start, this.Genes[i].End);

                // Battalion follower
                BattalionDestrebution[i % 4].Add(this.Genes[i].BattalionUID);

                if (!BattalionFollowers.ContainsKey(this.Genes[i].BattalionUID))
                {
                    BattalionFollowers[this.Genes[i].BattalionUID] = new BattalionAssignmentFollower();
                }

                BattalionFollowers[this.Genes[i].BattalionUID].AddRotation(i % TaamCalendar.ChunksCount);
                BattalionFollowers[this.Genes[i].BattalionUID].AddSector(this.Genes[i].SectorUID);
            }

            ConstraintsFitness = ConstraintsFitness / this.Genes.Length;

            this.Fitness =
                this.CalculateAssignmentRulesFitness(BattalionDestrebution, BattalionFollowers) * .65f +
                this.CalculateReservesionFitness(ReservesionForBattalionScore) * .125f +
                ConstraintsFitness * .225f;
        }

        private float CalculateAssignmentRulesFitness(HashSet<int>[] BattalionDestrebution, Dictionary<int, BattalionAssignmentFollower> BattalionFollowers)
        {
            float TotalDestrebutionFitness = ((float)BattalionDestrebution.Sum(x => x.Count) / (CStrategyPool.ActiveStrategy.GetSectorsCount() * TaamCalendar.ChunksCount));
            float TotalRotationSameFitness = 0;
            float TotatlRotationSequenceFitness = 0;
            float TotalSectorBattalionScore = 0;
            float TotalReservedScore = 0;

            foreach (var followerPair in BattalionFollowers)
            {
                var follower = followerPair.Value;
                int ReservedScore = 1;
                int RotationSameSum = 1;
                int RotationSequenceSum = 1;

                if(follower.Rotations.Count == 2)
                {
                    int Score = Math.Abs(follower.Rotations[0] - follower.Rotations[1]);
                    if (Score == 0)
                    {
                        RotationSameSum = 0;
                        RotationSequenceSum = 0;
                    }
                    else if (Score != 2)
                    {
                        RotationSequenceSum = 0;
                    }

                }
                else if (follower.Rotations.Count == 3)
                {
                    int Score1 = Math.Abs(follower.Rotations[0] - follower.Rotations[1]);
                    int Score2 = Math.Abs(follower.Rotations[1] - follower.Rotations[2]);

                    if (Score1 == Score2)
                    {
                        RotationSequenceSum = 0;
                    }

                    if (follower.Rotations[0] == follower.Rotations[1] || 
                        follower.Rotations[1] == follower.Rotations[2] ||
                        follower.Rotations[0] == follower.Rotations[2])
                    {
                        RotationSequenceSum = 0;
                    }

                }
                else if(follower.Rotations.Count > 3)
                {
                    RotationSameSum = 0;
                    RotationSequenceSum = 0;
                }

                if (CStrategyPool.ActiveStrategy.BattalionsData[followerPair.Key].IsReservedDuty && follower.Rotations.Count > 1)
                {
                    ReservedScore = 0;
                }

                TotalReservedScore += ReservedScore;
                TotalRotationSameFitness += RotationSameSum;
                TotatlRotationSequenceFitness += RotationSequenceSum;
                TotalSectorBattalionScore += Convert.ToInt32(follower.SectorsValid);
            }

            float RotationScore = (
                        TotalReservedScore * .3f +
                        TotalRotationSameFitness * .15f +
                        TotatlRotationSequenceFitness * .35f +
                        TotalSectorBattalionScore * .2f) / BattalionFollowers.Count;

            return (RotationScore * .7f + TotalDestrebutionFitness * .3f);
        }

        private float CalculateReservesionFitness(int[] ReservesionForBattalionScore)
        {
            float BattalionReservedFitness = 0;
            for (int i = 0; i < ReservesionForBattalionScore.Length; i++)
            {
                BattalionReservedFitness += (float)ReservesionForBattalionScore[i] /
                    CStrategyPool.ActiveStrategy.BattalionsData[i].GetReservationsScoreSum();
            }

            return 1 - (BattalionReservedFitness / CStrategyPool.ActiveStrategy.GetBattalionsCount());
        }

        private float CalculateConstraintsFitness(int GeneIdx)
        {
            CSimpleBattalion Battalion  = CStrategyPool.ActiveStrategy.BattalionsData[this.Genes[GeneIdx].BattalionUID];
            CSimpleSector Sector        = CStrategyPool.ActiveStrategy.SectorsData[this.Genes[GeneIdx].SectorUID];

            return ((Battalion.Force & Sector.ForceConstraint) > 0) ? 1 : 0;
        }


        public override IDNA<CSingleAssignment> Clone()
        {
            CTaamAssignment Copy = new CTaamAssignment(false);
            Copy.Fitness = this.Fitness;
            for (int i = 0; i < this.Genes.Length; i++)
            {
                Copy[i] = this[i].Clone() as CSingleAssignment;
            }

            return Copy;
        }

        public override IDNA<CSingleAssignment> Crossover(IDNA<CSingleAssignment> objPartner)
        {
            return GlobalConfiguration.PartialGenomCrossover || GlobalConfiguration.SwitchMutation ? this.PartialGenomeCrossover(objPartner) : this.CoinCrossover(objPartner);
        }

        public IDNA<CSingleAssignment> CoinCrossover(IDNA<CSingleAssignment> objPartner)
        {
            CTaamAssignment Child = new CTaamAssignment(false);
            for (int i = 0; i < this.Genes.Length; i++)
            {
                CTaamAssignment Selected = Shared.Coin() ? this : objPartner as CTaamAssignment;
                Child[i] = Selected[i].Clone() as CSingleAssignment;
            }

            return Child;
        }

        public IDNA<CSingleAssignment> PartialGenomeCrossover(IDNA<CSingleAssignment> objPartner)
        {
            CTaamAssignment child = new CTaamAssignment(false);
            CTaamAssignment partner = (CTaamAssignment)objPartner;

            int nStart = Shared.Next(this.Genes.Length / 2) + 1;
            int nEnd = nStart + Shared.Next(this.Genes.Length / 2);
            List<int> colPassedGenesUIDs = new List<int>();

            for (int i = nStart; i < nEnd; i++)
            {
                child[i] = partner[i].Clone();
                colPassedGenesUIDs.Add(partner[i].UID);
            }

            int nGeneInsertionPos = 0;
            for (int i = 0; i < this.Genes.Length; i++)
            {
                if (nGeneInsertionPos == nStart)
                {
                    nGeneInsertionPos = nEnd;
                }

                if (colPassedGenesUIDs.Contains(this.Genes[i].UID))
                {
                    continue;
                }

                child[nGeneInsertionPos] = this.Genes[i].Clone();
                nGeneInsertionPos++;
            }

            child.Mutate();

            return child;
        }

        public override IDNA<CSingleAssignment> Revive()
        {
            return this.Clone();
        }

        public override bool Mutate()
        {
            return this.Mutate(Shared.rnd);
        }

        public override bool Mutate(Random rnd)
        {
            bool Mutated = false;

            if (GlobalConfiguration.SwitchMutation)
            {
                int index1 = rnd.Next(this.Genes.Length);
                int index2 = rnd.Next(this.Genes.Length);
                int t = this[index2].BattalionUID;
                this[index2].BattalionUID = this[index1].BattalionUID;
                this[index1].BattalionUID = t;
            }
            else
            {
                for (int i = 0; i < this.Genes.Length; i++)
                {
                    if (Shared.HitChance(rnd, GlobalConfiguration.MutationChance / 100))
                    {
                        this[i].BattalionUID = CStrategyPool.ActiveStrategy.GetRandomBattalionUID();
                    }
                }
            }

            return Mutated;
        }
    }
}
