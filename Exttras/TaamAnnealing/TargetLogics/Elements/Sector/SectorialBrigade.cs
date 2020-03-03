using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaamLogics
{
    public class SectorialBrigade
    {
        public ESectorialBrigade UID { get; set; }
        public List<CSimpleSector> MySectors { get; set; }

        public SectorialBrigade(ESectorialBrigade UID)
        {
            this.UID = UID;
            this.MySectors = new List<CSimpleSector>();
        }

        public void RegisterSector(CSimpleSector Sector)
        {
            this.MySectors.Add(Sector);
        }
    }
}
