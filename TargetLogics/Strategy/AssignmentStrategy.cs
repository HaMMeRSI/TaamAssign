using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaamLogics
{
    public class AssignmentStrategy : ICloneable<AssignmentStrategy>, IUpdateable
    {
        public CSimpleBattalion[] BattalionsData { get; set; }
        public CSimpleSector[] SectorsData { get; set; }
        public static Dictionary<ESectorialBrigade, SectorialBrigade> BrigadesData { get; set; }

        public List<int> YearlyPotentialBattalion { get; set; }

        public AssignmentStrategy(IStrategyDataSource DataSource)
        {
            AssignmentStrategy.BrigadesData = new Dictionary<ESectorialBrigade, SectorialBrigade>();
            AssignmentStrategy.BrigadesData[ESectorialBrigade.Brigade1] = new SectorialBrigade(ESectorialBrigade.Brigade1);
            AssignmentStrategy.BrigadesData[ESectorialBrigade.Brigade2] = new SectorialBrigade(ESectorialBrigade.Brigade2);
            AssignmentStrategy.BrigadesData[ESectorialBrigade.Brigade3] = new SectorialBrigade(ESectorialBrigade.Brigade3);
            AssignmentStrategy.BrigadesData[ESectorialBrigade.Brigade4] = new SectorialBrigade(ESectorialBrigade.Brigade4);
            AssignmentStrategy.BrigadesData[ESectorialBrigade.Brigade5] = new SectorialBrigade(ESectorialBrigade.Brigade5);
            AssignmentStrategy.BrigadesData[ESectorialBrigade.Brigade6] = new SectorialBrigade(ESectorialBrigade.Brigade6);
            AssignmentStrategy.BrigadesData[ESectorialBrigade.Brigade7] = new SectorialBrigade(ESectorialBrigade.Brigade7);
            AssignmentStrategy.BrigadesData[ESectorialBrigade.Brigade8] = new SectorialBrigade(ESectorialBrigade.Brigade8);
            AssignmentStrategy.BrigadesData[ESectorialBrigade.Brigade9] = new SectorialBrigade(ESectorialBrigade.Brigade9);
            AssignmentStrategy.BrigadesData[ESectorialBrigade.Brigade10] = new SectorialBrigade(ESectorialBrigade.Brigade10);

            this.BattalionsData = DataSource.GetBatalionData();
            this.SectorsData = DataSource.GetSectorData();
            this.YearlyPotentialBattalion = this.GetPotentialBattlions();
        }

        public AssignmentStrategy Clone()
        {
            throw new NotImplementedException();
        }

        public int GetBattalionsCount()
        {
            return this.BattalionsData.Length;
        }

        public int GetSectorsCount()
        {
            return this.SectorsData.Length;
        }

        public int GetRandomBattalionUID()
        {
            return this.YearlyPotentialBattalion[Shared.Next(this.YearlyPotentialBattalion.Count)];
        }

        public int GetRandomSectorUID()
        {
            return Shared.Next(this.SectorsData.Length);
        }

        private List<int> GetPotentialBattlions()
        {
            List<int> Potential = new List<int>();
            int RequieredForces = this.GetSectorsCount() * TaamCalendar.ChunksCount;

            var OrderedReserved = this.BattalionsData.Where(x => x.IsReservedDuty).OrderBy(x=>x.Justice).ToList();
            for (int i = 0; i < OrderedReserved.Count; i++)
            {
                Potential.Add(OrderedReserved[i].UID);
            }

            var BattalionByJustice = this.BattalionsData.Where(x => !x.IsReservedDuty).OrderBy(x => x.Justice).ToList();
            foreach (var Battalion in BattalionByJustice)
            {
                for (int i = 0; i < (int)Math.Ceiling((double)TaamCalendar.ChunksCount / 2); i++)
                {
                    Potential.Add(Battalion.UID);
                }
            }

            int nIterator = 0;
            while(Potential.Count < RequieredForces)
            {
                Potential.Add(BattalionByJustice[nIterator].UID);
                if(++nIterator == BattalionByJustice.Count)
                {
                    nIterator = 0;
                }
            }

            return Potential;
        }

        public void Update()
        {
        }
    }
}
