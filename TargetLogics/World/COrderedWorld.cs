using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionaryLogic;

namespace TargetLogics
{
    public class COrderedWorld : AWorld<SingleTargetFriendly>
    {
        #region CTors

        public COrderedWorld() : base(GlobalConfiguration.GameData.TotalAttackAmmo)
        {
            int j = 0;
            foreach (CSimpleArtillary Cannon in CStrategyPool.ActiveStrategy.FriendliesData.Values)
            {
                for (int i = 0; i < Cannon.Ammunition; i++)
                {
                    this.Genes[j + i] = new SingleTargetFriendly(j + i, Cannon.UID);
                }

                j += Cannon.Ammunition;
            }
        }

        private COrderedWorld(bool isSimple)
            : base(GlobalConfiguration.GameData.TotalAttackAmmo, isSimple)
        {
        }

        public override IWorld CreateInstance(bool IsSimple)
        {
            return IsSimple ? new COrderedWorld(IsSimple) : new COrderedWorld();
        }

        #endregion

        public override void Execute()
        {
            foreach (SingleTargetFriendly Cannon in this.Genes)
            {
                if (Cannon.Target == -1)
                {
                    Cannon.Target = Shared.Next(CStrategyPool.ActiveStrategy.GetEnemyCount());
                }
            }
        }

        protected override void DeadFitness()
        {
            foreach (SingleTargetFriendly SCannon in this.Genes)
            {
                this.DeadCount += CStrategyPool.ActiveStrategy.FriendliesData[SCannon.CannonUID]
                                    .Fire(CStrategyPool.ActiveStrategy.EnemiesData[SCannon.Target], this.Enemies[SCannon.Target], SCannon);
            }
        }

        protected override void Mutate()
        {
            bool Mutated = false;
            foreach (SingleTargetFriendly Cannon in this.Genes)
            {
                if (Shared.HitChance(GlobalConfiguration.MutationChance / 100))
                {
                    Cannon.Target = -1;
                    Mutated = true;
                }
            }

            if (GlobalConfiguration.PartialGenomCrossover && Shared.HitChance(GlobalConfiguration.MutationChance / 100))
            {
                int nReplaceWith;
                SingleTargetFriendly Temp;
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
    }
}
