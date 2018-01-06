using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaamLogics
{
    public class OriginalStrategyDataSource : IStrategyDataSource
    {
        public CSimpleBattalion[] GetBatalionData()
        {
            CSimpleBattalion[] Battalions = new CSimpleBattalion[GlobalConfiguration.Assignemnt.BattalionCount + GlobalConfiguration.Assignemnt.ReservedCount];
            for (int i = 0; i < 21; i++)
            {
                Battalions[i] = this.CreateBattalion(i, "Bat" + i, EConstraints.Land);
            }

            for (int i = 21; i < 33; i++)
            {
                Battalions[i] = this.CreateBattalion(i, "Armor" + i, EConstraints.ArmoredBattalion);
            }

            for (int i = 33; i < 38; i++)
            {
                Battalions[i] = this.CreateBattalion(i, "Bomber" + i, EConstraints.Bombers);
            }

            for (int i = 38; i < Battalions.Length; i++)
            {
                Battalions[i] = this.CreateBattalion(i, "res" + i, EConstraints.All, true);
            }

            return Battalions;
        }

        private CSimpleBattalion CreateBattalion(int UID, string Name, EConstraints Constraints, bool IsReservedDuty = false)
        {
            CSimpleBattalion Battalion = new CSimpleBattalion(Name, Constraints);
            Battalion.SetUID(UID);
            Battalion.IsReservedDuty = IsReservedDuty;
            int Reseversions = Shared.Next(2);
            for (int j = 0; j < Reseversions; j++)
            {
                Reservation r = new Reservation();
                r.Date = (new DateTime(2018, 1, 1)).AddDays(Shared.Next(365));
                r.Importance = (EImportance)(Shared.Next(5) + 1);
                Battalion.Reservations.Add(r);
            }

            return Battalion;
        }

        public CSimpleSector[] GetSectorData()
        {
            CSimpleSector[] Secotrs = new CSimpleSector[GlobalConfiguration.Assignemnt.SectorCount];
            var objSectorialBrigade = Enum.GetValues(typeof(ESectorialBrigade));
            ESectorialBrigade[] BrigadeAss = new ESectorialBrigade[GlobalConfiguration.Assignemnt.SectorCount];


            for (int i = 9; i < GlobalConfiguration.Assignemnt.SectorCount; i++)
            {
                BrigadeAss[i] = (ESectorialBrigade)objSectorialBrigade.GetValue(Shared.Next(objSectorialBrigade.Length - 3) + 3);
            }

            BrigadeAss = BrigadeAss.OrderBy(x => (int)x).ToArray();

            DateTime FirstWednesday = new DateTime(2018, 1, 1);
            while (FirstWednesday.Date.DayOfWeek != DayOfWeek.Wednesday)
            {
                FirstWednesday = FirstWednesday.AddDays(1);
            }

            var c = 0;
            Secotrs[c] = new CSimpleSector("Sec0", EConstraints.ArmoredBattalion, ESectorialBrigade.Brigade1, FirstWednesday);
            Secotrs[c].SetUID(c++);
            Secotrs[c] = new CSimpleSector("Sec1", EConstraints.ArmoredBattalion, ESectorialBrigade.Brigade1, FirstWednesday);
            Secotrs[c].SetUID(c++);
            Secotrs[c] = new CSimpleSector("Sec2", EConstraints.Land, ESectorialBrigade.Brigade1, FirstWednesday);
            Secotrs[c].SetUID(c++);

            Secotrs[c] = new CSimpleSector("Sec3", EConstraints.Land, ESectorialBrigade.Brigade2, FirstWednesday);
            Secotrs[c].SetUID(c++);
            Secotrs[c] = new CSimpleSector("Sec4", EConstraints.All, ESectorialBrigade.Brigade2, FirstWednesday);
            Secotrs[c].SetUID(c++);
            Secotrs[c] = new CSimpleSector("Sec5", EConstraints.All, ESectorialBrigade.Brigade2, FirstWednesday);
            Secotrs[c].SetUID(c++);

            Secotrs[c] = new CSimpleSector("Sec6", EConstraints.Land, ESectorialBrigade.Brigade3, FirstWednesday);
            Secotrs[c].SetUID(c++);
            Secotrs[c] = new CSimpleSector("Sec7", EConstraints.All, ESectorialBrigade.Brigade3, FirstWednesday);
            Secotrs[c].SetUID(c++);
            Secotrs[c] = new CSimpleSector("Sec8", EConstraints.All, ESectorialBrigade.Brigade3, FirstWednesday);
            Secotrs[c].SetUID(c++);


            for (int i = c; i < Secotrs.Length; i++)
            {
                Secotrs[i] = new CSimpleSector("Sec"+i, EConstraints.All, BrigadeAss[i], FirstWednesday);
                Secotrs[i].SetUID(i);
            }

            return Secotrs;
        }
    }
}
