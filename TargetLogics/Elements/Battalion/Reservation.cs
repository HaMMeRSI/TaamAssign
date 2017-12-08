using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaamLogics
{
    public class Reservation
    {
        public DateTime Date { get; set; }

        public EImportance Importance { get; set; }
    }

    public enum EImportance
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }
}
