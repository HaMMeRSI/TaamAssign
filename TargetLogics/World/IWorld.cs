using EvolutionaryLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetLogics
{
    public interface IWorld : IDNA
    {
        SlimEnemy[] Enemies { get; set; }
        int TotalAttackPrice { get; set; }
        int DeadCount { get; set; }
        int TotalAttackImportance { get; set; }

        IWorld CreateInstance(bool IsSimple);
    }
}
