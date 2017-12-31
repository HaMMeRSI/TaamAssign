using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaamLogics
{
    public class PartialFixedStrategyDataSource : IStrategyDataSource
    {
        public CMap Terrain { get; set; }
        public PartialFixedStrategyDataSource()
        {
        }

        //public CSimpleBattalion[] GetBatalionData()
        //{
        //    CSimpleBattalion[] Battalions = new CSimpleBattalion[GlobalConfiguration.Assignemnt.BattalionCount];
        //    for (int i = 0; i < 14; i++)
        //    {
        //        Battalions[i] = new CSimpleBattalion(EConstraints.Land, 0);
        //        Battalions[i].SetUID(i);

        //        int Reseversions = Shared.Next(3);
        //        for (int j = 0; j < Reseversions; j++)
        //        {
        //            Reservation r = new Reservation();
        //            r.Date = (new DateTime(2018, 1, 1)).AddDays(Shared.Next(365));
        //            r.Importance = (EImportance)(Shared.Next(5) + 1);
        //            Battalions[i].Reservations.Add(r);
        //        }
        //    }

        //    for (int i = 14; i < 24; i++)
        //    {
        //        Battalions[i] = new CSimpleBattalion(EConstraints.ArmoredBattalion, 0);
        //        Battalions[i].SetUID(i);

        //        int Reseversions = Shared.Next(3);
        //        for (int j = 0; j < Reseversions; j++)
        //        {
        //            Reservation r = new Reservation();
        //            r.Date = (new DateTime(2018, 1, 1)).AddDays(Shared.Next(365));
        //            r.Importance = (EImportance)(Shared.Next(5) + 1);
        //            Battalions[i].Reservations.Add(r);
        //        }
        //    }

        //    for (int i = 24; i < Battalions.Length; i++)
        //    {
        //        Battalions[i] = new CSimpleBattalion(EConstraints.All, Shared.Next(80) + 20);
        //        Battalions[i].SetUID(i);

        //        int Reseversions = Shared.Next(2);
        //        for (int j = 0; j < Reseversions; j++)
        //        {
        //            Reservation r = new Reservation();
        //            r.Date = (new DateTime(2018, 1, 1)).AddDays(Shared.Next(365));
        //            r.Importance = (EImportance)(Shared.Next(5) + 1);
        //            Battalions[i].Reservations.Add(r);
        //        }
        //    }

        //    return Battalions;
        //}

        //public CSimpleSector[] GetSectorData()
        //{
        //    CSimpleSector[] Secotrs = new CSimpleSector[GlobalConfiguration.Assignemnt.SectorCount];
        //    var objSectorialBrigade = Enum.GetValues(typeof(ESectorialBrigade));

        //    DateTime FirstWednesday = new DateTime(2018, 1, 1);
        //    while (FirstWednesday.Date.DayOfWeek != DayOfWeek.Wednesday)
        //    {
        //        FirstWednesday = FirstWednesday.AddDays(1);
        //    }

        //    for (int i = 0; i < 3; i++)
        //    {
        //        Secotrs[i] = new CSimpleSector(EConstraints.ArmoredBattalion, ESectorialBrigade.Brigade1, FirstWednesday);
        //        Secotrs[i].SetUID(i);
        //    }

        //    for (int i = 3; i < 6; i++)
        //    {
        //        Secotrs[i] = new CSimpleSector(EConstraints.Land, ESectorialBrigade.Brigade2, FirstWednesday.AddMonths(1));
        //        Secotrs[i].SetUID(i);
        //    }

        //    for (int i = 6; i < 12; i++)
        //    {
        //        Secotrs[i] = new CSimpleSector(EConstraints.Land, ESectorialBrigade.Brigade3, FirstWednesday);
        //        Secotrs[i].SetUID(i);
        //    }

        //    for (int i = 0; i < 6; i++)
        //    {
        //        for (int j = 0; j < 3; j++)
        //        {
        //            int id = 12 + i * 3 + j;
        //            Secotrs[id] = new CSimpleSector(
        //                EConstraints.All,
        //                (ESectorialBrigade)objSectorialBrigade.GetValue(Shared.Next(objSectorialBrigade.Length - 3) + 3),
        //                FirstWednesday);
        //            Secotrs[id].SetUID(id);
        //        }
        //    }

        //    return Secotrs;
        //}

        public CSimpleBattalion[] GetBatalionData()
        {
            CSimpleBattalion[] Battalions = new CSimpleBattalion[GlobalConfiguration.Assignemnt.BattalionCount];

            for (int i = 0; i < Battalions.Length; i++)
            {
                Battalions[i] = new CSimpleBattalion(EConstraints.All, Shared.Next(80) + 20);
                Battalions[i].SetUID(i);

                int Reseversions = Shared.Next(2);
                for (int j = 0; j < Reseversions; j++)
                {
                    Reservation r = new Reservation();
                    r.Date = (new DateTime(2018, 1, 1)).AddDays(Shared.Next(365));
                    r.Importance = (EImportance)(Shared.Next(5) + 1);
                    Battalions[i].Reservations.Add(r);
                }
            }

            return Battalions;
        }

        public CSimpleSector[] GetSectorData()
        {
            CSimpleSector[] Secotrs = new CSimpleSector[GlobalConfiguration.Assignemnt.SectorCount];
            var objSectorialBrigade = Enum.GetValues(typeof(ESectorialBrigade));
            ESectorialBrigade[] BrigadeAss = new ESectorialBrigade[GlobalConfiguration.Assignemnt.SectorCount];

            for (int i = 0; i < GlobalConfiguration.Assignemnt.SectorCount; i++)
            {
                BrigadeAss[i] = (ESectorialBrigade)objSectorialBrigade.GetValue(Shared.Next(objSectorialBrigade.Length));
            }

            BrigadeAss = BrigadeAss.OrderBy(x => (int)x).ToArray();

            DateTime FirstWednesday = new DateTime(2018, 1, 1);
            while (FirstWednesday.Date.DayOfWeek != DayOfWeek.Wednesday)
            {
                FirstWednesday = FirstWednesday.AddDays(1);
            }

            for (int i = 0; i < Secotrs.Length; i++)
            {
                Secotrs[i] = new CSimpleSector(
                    EConstraints.All,
                    BrigadeAss[i],
                    FirstWednesday);
                Secotrs[i].SetUID(i);
            }

            return Secotrs;
        }
    }
}
