﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetLogics
{
    public interface IStrategyDataSource
    {
        CSimpleArtillary[] GetFriendlyData();
        CSimpleArtillary[] GetEnemyData();
    }
}
