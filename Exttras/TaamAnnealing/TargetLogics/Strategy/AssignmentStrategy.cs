using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaamLogics
{
    public class AssignmentStrategy :ICloneable<AssignmentStrategy>, IUpdateable
    {
        public CSimpleBattalion[] BattalionsData { get; set; }
        public CSimpleSector[] SectorsData { get; set; }
        public static Dictionary<ESectorialBrigade, SectorialBrigade> BrigadesData { get; set; }

        public AssignmentStrategy(IStrategyDataSource DataSource)
        {
            AssignmentStrategy.BrigadesData                                 = new Dictionary<ESectorialBrigade, SectorialBrigade>();
            AssignmentStrategy.BrigadesData[ESectorialBrigade.Brigade1]     = new SectorialBrigade(ESectorialBrigade.Brigade1);
            AssignmentStrategy.BrigadesData[ESectorialBrigade.Brigade2]     = new SectorialBrigade(ESectorialBrigade.Brigade2);
            AssignmentStrategy.BrigadesData[ESectorialBrigade.Brigade3]     = new SectorialBrigade(ESectorialBrigade.Brigade3);
            AssignmentStrategy.BrigadesData[ESectorialBrigade.Brigade4]     = new SectorialBrigade(ESectorialBrigade.Brigade4);
            AssignmentStrategy.BrigadesData[ESectorialBrigade.Brigade5]     = new SectorialBrigade(ESectorialBrigade.Brigade5);
            AssignmentStrategy.BrigadesData[ESectorialBrigade.Brigade6]     = new SectorialBrigade(ESectorialBrigade.Brigade6);
            AssignmentStrategy.BrigadesData[ESectorialBrigade.Brigade7]     = new SectorialBrigade(ESectorialBrigade.Brigade7);
            AssignmentStrategy.BrigadesData[ESectorialBrigade.Brigade8]     = new SectorialBrigade(ESectorialBrigade.Brigade8);
            AssignmentStrategy.BrigadesData[ESectorialBrigade.Brigade9]     = new SectorialBrigade(ESectorialBrigade.Brigade9);
            AssignmentStrategy.BrigadesData[ESectorialBrigade.Brigade10]    = new SectorialBrigade(ESectorialBrigade.Brigade10);

            this.BattalionsData = DataSource.GetBatalionData();
            this.SectorsData = DataSource.GetSectorData();
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
            return Shared.Next(this.BattalionsData.Length);
        }

        public int GetRandomSectorUID()
        {
            return Shared.Next(this.SectorsData.Length);
        }

        public void Update()
        {
        }
    }
}
