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
    public class CCannonWorld : AWorld<SlimFriendly>
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
            List<SlimFriendly> remains = this.Genes.Select(x => x).ToList();

            while (remains.Count > 0)
            {
                for (int i = 0; i < remains.Count; i++)
                {
                    SlimFriendly SCannon = remains[i];
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

        protected override void Mutate()
        {
            bool Mutated = false;
            foreach (SlimFriendly Cannon in this.Genes)
            {
                if (Shared.HitChance(GlobalConfiguration.MutationChance / 100))
                {
                    Cannon.Targets = null;
                    Mutated = true;
                }
            }

            if (GlobalConfiguration.PartialGenomCrossover && Shared.HitChance(GlobalConfiguration.MutationChance / 100))
            {
                int nReplaceWith;
                SlimFriendly Temp;
                for (int i = 0; i < this.Genes.Length; i++)
                {
                    if (Shared.HitChance(.6))
                    {
                        nReplaceWith = Shared.Next(this.Genes.Length);
                        Temp = this[nReplaceWith];
                        this[nReplaceWith] = this[i];
                        this[i] = Temp;
                    }
                }
            }

            if (Mutated)
            {
                this.Execute();
            }
        }

        #endregion
    }
}