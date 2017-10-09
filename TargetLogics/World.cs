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
    public class CWorld : DNA<SlimFriendly>, ILive
    {
        private TargetingStrategy Strategy { get; set; }
        public SlimEnemy[] Enemies { get; set; }

        public int TotalAttackPrice { get; set; }
        public int DeadCount { get; set; }
        public int TotalAttackImportance { get; set; }

        public CWorld(TargetingStrategy Strategy)
            : base(Strategy.GetFriendlyCount())
        {
            this.Strategy = Strategy;
            this.TotalAttackPrice = 0;
            this.DeadCount = 0;
            this.TotalAttackImportance = 0;

            for (int i = 0; i < Strategy.GetFriendlyCount(); i++)
            {
                this.Genes[i] = new SlimFriendly(Strategy.FriendliesData[i].UID);
            }

            this.Enemies = new SlimEnemy[Strategy.GetEnemyCount()];
            for (int i = 0; i < this.Enemies.Length; i++)
            {
                this.Enemies[i] = new SlimEnemy(i);
            }
        }

        private CWorld(TargetingStrategy Strategy, bool isSimple)
            : base(Strategy.GetFriendlyCount())
        {
            this.Strategy = Strategy;
            this.TotalAttackPrice = 0;
            this.DeadCount = 0;
            this.TotalAttackImportance = 0;
            this.Enemies = new SlimEnemy[Strategy.GetEnemyCount()];
        }

        #region DNA

        public override void Execute()
        {
            foreach (SlimFriendly Cannon in this.Genes)
            {
                if (Cannon.Targets == null)
                {
                    int nAmmo = Strategy.FriendliesData[Cannon.UID].Ammunition;
                    Cannon.Targets = new int[nAmmo];

                    for (int i = 0; i < nAmmo; i++)
                    {
                        Cannon.Targets[i] = Shared.Next(Strategy.EnemiesData.Length);
                    }
                }
            }
        }

        public override void CalculateFitness()
        {
            TargetingStrategy ExecutedStrategy = CStrategyPool.GetFromPool();

            this.DeadFitness(ExecutedStrategy); 
            this.OtherFitness(ExecutedStrategy); 

            float DeadFactor = (float)this.DeadCount / ExecutedStrategy.GetEnemyCount();
            double PriceFactor = 1 - ((double)this.TotalAttackPrice / GlobalConfiguration.GameData.MaxAttackPrice);
            double ImportanceFactor = ((double)this.TotalAttackImportance / GlobalConfiguration.GameData.MaxAttackImportance);

            this.Fitness = (float)
                (PriceFactor * GlobalConfiguration.GameSettings.PriceWeight + 
                DeadFactor * GlobalConfiguration.GameSettings.DeadCountWeight +
                ImportanceFactor * GlobalConfiguration.GameSettings.ImportanceWeight);

            CStrategyPool.Release(ExecutedStrategy);
        }

        private void DeadFitness(TargetingStrategy ExecutedStrategy)
        {
            CSimpleArtillary FCannon;
            List<SlimFriendly> remains = this.Genes.Select(x => x).ToList();

            while (remains.Count > 0)
            {
                for (int i = 0; i < remains.Count; i++)
                {
                    SlimFriendly SCannon = remains[i];
                    FCannon = ExecutedStrategy.FriendliesData[SCannon.UID];
                    this.DeadCount += FCannon.Fire(ExecutedStrategy.EnemiesData, this.Enemies, SCannon);

                    if(SCannon.ShotsTaken == FCannon.Ammunition)
                    {
                        remains.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

        private void OtherFitness(TargetingStrategy ExecutedStrategy)
        {
            foreach (SlimEnemy EnemyCannon in this.Enemies)
            {
                if (EnemyCannon.Health <= 0)
                {
                    foreach (int HittedBy in EnemyCannon.HittedBy)
                    {
                        this.TotalAttackPrice += ExecutedStrategy.FriendliesData[HittedBy].PriceForShot;
                    }

                    this.TotalAttackImportance += ExecutedStrategy.EnemiesData[EnemyCannon.UID].Importance;
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

        public override IDNA Crossover(IDNA objPartner)
        {
            return GlobalConfiguration.PartialGenomCrossover ? this.PartialGenomeCrossover(objPartner) : this.CoinCrossover(objPartner);
        }

        public override IDNA Clone()
        {
            CWorld world = new CWorld(this.Strategy, true);
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
            CWorld world = new CWorld(this.Strategy, true);

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

        #endregion

        #region ILive

        public void Draw(Graphics g)
        {
            //foreach (CSimpleArtillary MyCannon in this.Enemies)
            //{
            //    MyCannon.Draw(g);
            //}

            //foreach (CSimpleArtillary MyCannon in this.Genes)
            //{
            //    MyCannon.Draw(g);
            //}
        }

        public void Update()
        {
            //foreach (CSimpleArtillary MyCannon in this.Enemies)
            //{
            //    MyCannon.Update();
            //}

            //foreach (CSimpleArtillary MyCannon in this.Genes)
            //{
            //    MyCannon.Update();
            //}
        }

        #endregion

        #region Genetic Methods

        public IDNA CoinCrossover(IDNA objPartner)
        {
            CWorld child = new CWorld(this.Strategy);
            CWorld partner = (CWorld)objPartner;

            for (int i = 0; i < partner.Genes.Length; i++)
            {
                child[i] = Shared.Coin() ? this[i].Clone() : partner[i].Clone();
            }

            child.Mutate();

            return child;
        }

        public IDNA PartialGenomeCrossover(IDNA objPartner)
        {
            CWorld child = new CWorld(this.Strategy);
            CWorld partner = (CWorld)objPartner;

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
    }
}
