using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaamLogics
{
    public interface IStrategyDataSource
    {
        CSimpleBattalion[] GetBatalionData();
        CSimpleSector   [] GetSectorData();
    }
}
