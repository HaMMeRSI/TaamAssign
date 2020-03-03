using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaamLogics
{
    public class TaamChunk
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public override string ToString()
        {
            return "Start: " + Start.ToShortDateString() + ", End: " + End.ToShortDateString();
        }
    }
}
