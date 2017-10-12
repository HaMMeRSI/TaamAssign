using EvolutionaryLogic;
using Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetLogics
{
    public class CCannonWorld : AWorld
    {
        #region CTors

        public CCannonWorld()
            : base(CStrategyPool.ActiveStrategy.GetFriendlyCount())
        {
            for (int i = 0; i < CStrategyPool.ActiveStrategy.GetFriendlyCount(); i++)
            {
                this.Genes[i] = new SlimFriendly(CStrategyPool.ActiveStrategy.FriendliesData[i].UID);
            }
        }

        private CCannonWorld(bool isSimple)
            : base(CStrategyPool.ActiveStrategy.GetFriendlyCount(), isSimple)
        {
        }

        public override IWorld CreateInstance(bool IsSimple)
        {
            return IsSimple ? new CCannonWorld(IsSimple) : new CCannonWorld();
        }

        #endregion

        #region DNA

        public override void Execute()
        {
            foreach (SlimFriendly Cannon in this.Genes)
            {
                if (Cannon.Targets == null)
                {
                    int nAmmo = CStrategyPool.ActiveStrategy.FriendliesData[Cannon.UID].Ammunition;
                    Cannon.Targets = new int[nAmmo];

                    for (int i = 0; i < nAmmo; i++)
                    {
                        Cannon.Targets[i] = Shared.Next(CStrategyPool.ActiveStrategy.GetEnemyCount());
                    }
                }
            }
        }

        protected override void DeadFitness()
        {
            CSimpleArtillary FCannon;
            List<ISlim> remains = this.Genes.Select(x => x).ToList();

            while (remains.Count > 0)
            {
                for (int i = 0; i < remains.Count; i++)
                {
                    SlimFriendly SCannon = (SlimFriendly)remains[i];
                    FCannon = CStrategyPool.ActiveStrategy.FriendliesData[SCannon.UID];
                    this.DeadCount += FCannon
                                        .Fire(CStrategyPool.ActiveStrategy.EnemiesData[SCannon.Targets[SCannon.ShotsTaken]], this.Enemies[SCannon.Targets[SCannon.ShotsTaken]], SCannon);

                    if (SCannon.ShotsTaken == FCannon.Ammunition)
                    {
                        remains.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

        #endregion
    }
}