using EvolutionaryLogic;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TargetLogics
{
    public abstract class AWorld<T> : DNA<T>, IWorld where T : ICloneable<T>, IIdentifiable
    {
        public SlimEnemy[] Enemies { get; set; }
        public int TotalAttackPrice { get; set; }
        public int DeadCount { get; set; }
        public int TotalAttackImportance { get; set; }

        public AWorld(int nGenesCount) : this(nGenesCount, true)
        {
            for (int i = 0; i < this.Enemies.Length; i++)
            {
                this.Enemies[i] = new SlimEnemy(i);
            }
        }

        protected AWorld(int nGenesCount, bool isSimple) : base(nGenesCount)
        {
            this.TotalAttackPrice = 0;
            this.DeadCount = 0;
            this.TotalAttackImportance = 0;
            this.Enemies = new SlimEnemy[CStrategyPool.ActiveStrategy.GetEnemyCount()];
        }


        public override void CalculateFitness()
        {
            this.DeadFitness();
            this.OtherFitness();

            float DeadFactor = (float)this.DeadCount / CStrategyPool.ActiveStrategy.GetEnemyCount();
            float PriceFactor = 1 - ((float)this.TotalAttackPrice / GlobalConfiguration.GameData.MaxAttackPrice);
            float ImportanceFactor = ((float)this.TotalAttackImportance / GlobalConfiguration.GameData.MaxAttackImportance);

            this.Fitness =
                (PriceFactor * GlobalConfiguration.GameSettings.PriceWeight +
                DeadFactor * GlobalConfiguration.GameSettings.DeadCountWeight +
                ImportanceFactor * GlobalConfiguration.GameSettings.ImportanceWeight);
        }

        public override IDNA Crossover(IDNA objPartner)
        {
            return GlobalConfiguration.PartialGenomCrossover ? this.PartialGenomeCrossover(objPartner) : this.CoinCrossover(objPartner);
        }

        #region Genetic Methods

        public IDNA CoinCrossover(IDNA objPartner)
        {
            AWorld<T> child = (AWorld<T>)this.CreateInstance(false);
            AWorld<T> partner = (AWorld<T>)objPartner;

            for (int i = 0; i < partner.Genes.Length; i++)
            {
                child[i] = Shared.Coin() ? this[i].Clone() : partner[i].Clone();
            }

            child.Mutate();

            return child;
        }

        public IDNA PartialGenomeCrossover(IDNA objPartner)
        {
            AWorld<T> child = (AWorld<T>)this.CreateInstance(false);
            AWorld<T> partner = (AWorld<T>)objPartner;

            int nStart = Shared.Next(this.Genes.Length / 2 + 1);
            int nEnd = nStart + Shared.Next(this.Genes.Length / 2);
            List<int> colPassedGenesUIDs = new List<int>();

            for (int i = nStart; i < nEnd; i++)
            {
                child[i] = partner[i].Clone();
                colPassedGenesUIDs.Add(partner[i].UID);
            }

            int nGeneInsertionPos = 0;
            for (int i = 0; i < this.Genes.Length; i++)
            {
                if (nGeneInsertionPos == nStart)
                {
                    nGeneInsertionPos = nEnd;
                }

                if (colPassedGenesUIDs.Contains(this.Genes[i].UID))
                {
                    continue;
                }

                child[nGeneInsertionPos] = this.Genes[i].Clone();
                nGeneInsertionPos++;
            }

            child.Mutate();

            return child;
        }

        #endregion

        public override IDNA Clone()
        {
            AWorld<T> world = (AWorld<T>)this.CreateInstance(true);
            world.TotalAttackImportance = this.TotalAttackImportance;
            world.TotalAttackPrice = this.TotalAttackPrice;
            world.DeadCount = this.DeadCount;
            world.Fitness = this.Fitness;

            for (int i = 0; i < this.Genes.Length; i++)
            {
                world[i] = this[i].Clone();
            }

            for (int i = 0; i < this.Enemies.Length; i++)
            {
                world.Enemies[i] = this.Enemies[i].Clone();
            }

            return world;
        }

        public override IDNA Revive()
        {
            AWorld<T> world = (AWorld<T>)this.CreateInstance(true);

            for (int i = 0; i < this.Genes.Length; i++)
            {
                world[i] = this[i].Clone();
            }

            for (int i = 0; i < this.Enemies.Length; i++)
            {
                world.Enemies[i] = new SlimEnemy(i);
            }

            return world;
        }

        public abstract IWorld CreateInstance(bool IsSimple);
        public override abstract void Execute();
        protected abstract void DeadFitness();
        protected virtual void OtherFitness()
        {
            foreach (SlimEnemy EnemyCannon in this.Enemies)
            {
                if (EnemyCannon.Health <= 0)
                {
                    foreach (int HittedBy in EnemyCannon.HittedBy)
                    {
                        this.TotalAttackPrice += CStrategyPool.ActiveStrategy.FriendliesData[HittedBy].PriceForShot;
                    }

                    this.TotalAttackImportance += CStrategyPool.ActiveStrategy.EnemiesData[EnemyCannon.UID].Importance;
                }
            }
        }
    }
}
