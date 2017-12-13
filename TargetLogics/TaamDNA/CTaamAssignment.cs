using EvolutionaryLogic;
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

                    for (int j = 0; j < TaamCalendar.ChunksCount; j++)
                    {
                        this[SectorUID * TaamCalendar.ChunksCount + j] = new CSingleAssignment(SectorUID * TaamCalendar.ChunksCount + j, Taams[j].Start, Taams[j].End, SectorUID);
                    }
                }
            }
        }

        public override void Execute()
        {
            foreach (var Assignment in this.Genes)
            {
                // DNASequence.Execute();
                if(Assignment.BattalionUID == -1)
                {
                    Assignment.BattalionUID = CStrategyPool.ActiveStrategy.GetRandomBattalionUID();
                }
            }
        }

        public override void CalculateFitness()
        {
            float AssignmentRules = this.CalculateAssignmentRulesFitness();

            float BattalionReservedFitness = 0;
            //Dictionary<int, int> ReservesionForBattalionScore = new Dictionary<int, int>();
            int[] ReservesionForBattalionScore = Shared.SafeArray<int>(CStrategyPool.ActiveStrategy.GetBattalionsCount());

            for (int i = 0; i < CStrategyPool.ActiveStrategy.GetSectorsCount(); i++)
            {
                for (int j = 0; j < TaamCalendar.ChunksCount; j++)
                {
                    CSingleAssignment Assignment = this[i * TaamCalendar.ChunksCount + j];
                    ReservesionForBattalionScore[Assignment.BattalionUID] += 
                        CStrategyPool.ActiveStrategy.BattalionsData[Assignment.BattalionUID].ScoreAssignment(Assignment);
                }
            }

            for (int i = 0; i < ReservesionForBattalionScore.Length; i++)
            {
                BattalionReservedFitness += (float)ReservesionForBattalionScore[i] /
                    CStrategyPool.ActiveStrategy.BattalionsData[i].GetReservationsScore();
            }

            BattalionReservedFitness = 1-(BattalionReservedFitness / CStrategyPool.ActiveStrategy.GetBattalionsCount());
            this.Fitness = (AssignmentRules * .85f + BattalionReservedFitness * .15f);
        }

        private float CalculateAssignmentRulesFitness()
        {
            Dictionary<int, BattalionAssignmentFollower> BattalionFollowers = new Dictionary<int, BattalionAssignmentFollower>();
            HashSet<int>[] BattalionDestrebution = new HashSet<int>[TaamCalendar.ChunksCount];
            for (int i = 0; i < BattalionDestrebution.Length; i++)
            {
                BattalionDestrebution[i] = new HashSet<int>();
            }

            for (int i = 0; i < this.Genes.Length; i++)
            {
                BattalionDestrebution[i % 4].Add(this.Genes[i].BattalionUID);

                if(!BattalionFollowers.ContainsKey(this.Genes[i].BattalionUID))
                {
                    BattalionFollowers[this.Genes[i].BattalionUID] = new BattalionAssignmentFollower();
                }

                BattalionFollowers[this.Genes[i].BattalionUID].AddRotation(i % TaamCalendar.ChunksCount);
                BattalionFollowers[this.Genes[i].BattalionUID].AddSector(this.Genes[i].SectorUID);
            }

            float TotalDestrebutionFitness = ((float)BattalionDestrebution.Sum(x => x.Count) / (CStrategyPool.ActiveStrategy.GetSectorsCount() * TaamCalendar.ChunksCount));
            // float TotalDestrebutionFitness = BattalionDestrebution.Sum(x => (float)x.Count / CStrategyPool.ActiveStrategy.GetBattalionsCount() / TaamCalendar.ChunksCount) / TaamCalendar.ChunksCount;
            float TotalRotationSameFitness = 0;
            float TotatlRotationSequenceFitness = 0;
            float TotalSectorBattalionScore = 0;

            foreach (var follower in BattalionFollowers.Values)
            {
                int RotationSameSum = 1;
                int RotationSequenceSum = 1;

                if (follower.Rotations.Count > 1)
                {
                    //RotationSameSum = 0;
                    //RotationSequenceSum = 0;
                    for (int j = 0; j < follower.Rotations.Count - 1; j++)
                    {
                        int Score = Math.Abs(follower.Rotations[j] - follower.Rotations[j + 1]);
                        if (Score == 0)
                        {
                            RotationSameSum = 0;
                            RotationSequenceSum = 0;
                            break;
                        }
                        else if (Score != 2)
                        {
                            RotationSequenceSum = 0;
                        }
                    }
                }

                TotalRotationSameFitness += RotationSameSum;
                TotatlRotationSequenceFitness += RotationSequenceSum;
                TotalSectorBattalionScore += Convert.ToInt32(follower.SectorsValid);
            }

            float RotationScore = (TotalRotationSameFitness * .3f +
                        TotatlRotationSequenceFitness * .5f +
                        TotalSectorBattalionScore * .2f) / BattalionFollowers.Count;

            return (RotationScore * .7f + TotalDestrebutionFitness * .3f);
        }

        public override IDNA Clone()
        {
            CTaamAssignment Copy = new CTaamAssignment(false);
            Copy.Fitness = this.Fitness;
            for (int i = 0; i < this.Genes.Length; i++)
            {
                Copy[i] = this[i].Clone() as CSingleAssignment;
            }

            return Copy;
        }

        public override IDNA Crossover(IDNA objPartner)
        {
            return GlobalConfiguration.PartialGenomCrossover ? this.PartialGenomeCrossover(objPartner) : this.CoinCrossover(objPartner);
        }

        public IDNA CoinCrossover(IDNA objPartner)
        {
            CTaamAssignment Child = new CTaamAssignment(false);
            for (int i = 0; i < this.Genes.Length; i++)
            {
                CTaamAssignment Selected = Shared.Coin() ? this : objPartner as CTaamAssignment;
                Child[i] = Selected[i].Clone() as CSingleAssignment;
            }

            return Child;
        }

        public IDNA PartialGenomeCrossover(IDNA objPartner)
        {
            CTaamAssignment child = new CTaamAssignment(false);
            CTaamAssignment partner = (CTaamAssignment)objPartner;

            int nStart = Shared.Next(this.Genes.Length / 2)+1;
            int nEnd = nStart + Shared.Next(this.Genes.Length / 2);
            List<int> colPassedGenesUIDs = new List<int>();

            for (int i = nStart; i < nEnd; i++)
            {
                child[i] = (CSingleAssignment)partner[i].Clone();
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

                child[nGeneInsertionPos] = (CSingleAssignment)this.Genes[i].Clone();
                nGeneInsertionPos++;
            }

            child.Mutate();

            return child;
        }

        public override IDNA Revive()
        {
            return this.Clone();
        }

        public override bool Mutate()
        {
            bool Mutated = false;

            for (int i = 0; i < this.Genes.Length; i++)
            {
                if (Shared.HitChance(GlobalConfiguration.MutationChance / 100))
                {
                    this[i].BattalionUID = CStrategyPool.ActiveStrategy.GetRandomBattalionUID();
                }
            }

            //if (Mutated)
            //{
            //    this.Execute();
            //}

            return Mutated;
        }
    }
}
