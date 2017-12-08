using EvolutionaryLogic;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaamLogics
{
    public class DNASubSequence : DNA<CSingleAssignment>
    {
        public int SectorUID { get; set; }
        private BattalionAssigner MyAssigner{ get; set; }

        public DNASubSequence(int SectorUID, BattalionAssigner Assigner) : 
            base(TaamCalendar.ChunksCount)
        {
            this.SectorUID = SectorUID;
            this.MyAssigner = Assigner;
            TaamCalendar CalendarGen = new TaamCalendar();

            var Taams = CalendarGen.GetTaamChunks(CStrategyPool.ActiveStrategy.SectorsData[SectorUID].StartOfYear);
            for (int i = 0; i < Taams.Length; i++)
            {
                this[i] = new CSingleAssignment(i, Taams[i].Start, Taams[i].End, SectorUID);
            }
        }

        private DNASubSequence(DNASubSequence Sequence) : 
            base(TaamCalendar.ChunksCount)
        {
            this.Fitness = Sequence.Fitness;
            this.SectorUID = Sequence.SectorUID;

            for (int i = 0; i < this.Genes.Length; i++)
            {
                this[i] = new CSingleAssignment(i, new DateTime(Sequence[i].Start.Ticks), new DateTime(Sequence[i].End.Ticks), Sequence[i].SectorUID);
                this[i].BattalionUID = Sequence[i].BattalionUID;
            }
        }

        public override void Execute()
        {
            for (int i = 0; i < this.Genes.Length; i++)
            {
                if (this[i].BattalionUID == -1)
                {
                    this[i].BattalionUID = this.MyAssigner.GetFreeBattalion(i);
                }
            }
        }

        public override void CalculateFitness()
        {
            int TotalSectorScore = 0;
            int TotalBattalionReservation = 0;
            foreach (var Assignment in this.Genes)
            {
                TotalSectorScore += CStrategyPool.ActiveStrategy.BattalionsData[Assignment.BattalionUID].ScoreAssignment(Assignment);
                TotalBattalionReservation += CStrategyPool.ActiveStrategy.BattalionsData[Assignment.BattalionUID].GetReservationsScore();
            }

            this.Fitness = TotalBattalionReservation ==0 ? 1 : 1 - (TotalSectorScore / TotalBattalionReservation);
        }

        public override IDNA Clone()
        {
            return new DNASubSequence(this);
        }

        public override IDNA Crossover(IDNA objPartner)
        {
            throw new NotImplementedException();
        }

        public override IDNA Revive()
        {
            throw new NotImplementedException();
        }

        public override bool Mutate()
        {
            bool Mutated = false;

            for (int i = 0; i < this.Genes.Length; i++)
            {
                if (Shared.HitChance(GlobalConfiguration.MutationChance / 100))
                {
                    this.MyAssigner.ReleaseBattalion(i, this[i].BattalionUID);
                    this[i].Reset();
                    Mutated = true;
                }
            }

            //if (Shared.HitChance(GlobalConfiguration.MutationChance / 100))
            //{
            //    TaamCalendar CalendarGen = new TaamCalendar();
            //    var Taams = CalendarGen.GetTaamChunks(
            //        CStrategyPool.ActiveStrategy.SectorsData[this.SectorUID].StartOfYear
            //        .AddDays(Shared.Next(TaamCalendar.TaamDuration)));

            //    for (int i = 0; i < Taams.Length; i++)
            //    {
            //        this[i].Start = Taams[i].Start;
            //        this[i].End   = Taams[i].End;
            //    }
            //}

            return Mutated;
        }
    }
}
