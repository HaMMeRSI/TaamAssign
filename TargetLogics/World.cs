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
    public class CWorld : DNA<SlimCannon>, ILive
    {
        private TargetingStrategy Strategy { get; set; }
        public SlimCannon[] Enemies { get; set; }

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
                this.Genes[i] = new SlimCannon(Strategy.FriendliesData[i].UID); ;
            }

        }

        private CWorld(TargetingStrategy Strategy, bool isSimple)
            : base(Strategy.GetFriendlyCount())
        {
            this.Strategy = Strategy;
            this.TotalAttackPrice = 0;
            this.DeadCount = 0;
            this.TotalAttackImportance = 0;
        }

        #region DNA

        public override void Execute()
        {
            foreach (SlimCannon Cannon in this.Genes)
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
            Strategy.ResetStrategyStatus();

            bool blnEndIndicator = false;
            CSimpleArtillary FCannon;

            while (!blnEndIndicator)
            {
                blnEndIndicator = true;
                foreach (SlimCannon SCannon in this.Genes)
                {
                    FCannon = Strategy.FriendliesData[SCannon.UID];
                    this.DeadCount += FCannon.Fire(Strategy.EnemiesData, SCannon.Targets);
                    blnEndIndicator &= FCannon.ShotsTaken == FCannon.Ammunition;
                }
            }

            float DeadFactor = (float)this.DeadCount / this.Strategy.GetEnemyCount();

            foreach (CSimpleArtillary EnemyCannon in Strategy.EnemiesData)
            {
                if (EnemyCannon.Health <= 0)
                {
                    foreach (int HittedBy in EnemyCannon.HittedBy)
                    {
                        this.TotalAttackPrice += Strategy.FriendliesData[HittedBy].PriceForShot;
                    }

                    this.TotalAttackImportance += EnemyCannon.Importance;
                }
            }

            double PriceFactor = 1 - ((double)this.TotalAttackPrice / GlobalConfiguration.GameData.MaxAttackPrice);
            double ImportanceFactor = ((double)this.TotalAttackImportance / GlobalConfiguration.GameData.MaxAttackImportance);

            this.Fitness = (float)
                (PriceFactor * GlobalConfiguration.GameSettings.PriceWeight + 
                DeadFactor * GlobalConfiguration.GameSettings.DeadCountWeight +
                ImportanceFactor * GlobalConfiguration.GameSettings.ImportanceWeight);
        }

        protected override void Mutate()
        {
            bool Mutated = false;
            foreach (SlimCannon Cannon in this.Genes)
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
                SlimCannon Temp;
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

            world.Enemies = new SlimCannon[Strategy.EnemiesData.Length];
            for (int i = 0; i < Strategy.EnemiesData.Length; i++)
            {
                world.Enemies[i] = new SlimCannon(i);
                world.Enemies[i].Health = Strategy.EnemiesData[i].Health;
                world.Enemies[i].Targets = new int[Strategy.EnemiesData[i].HittedBy.Count];
                Strategy.EnemiesData[i].HittedBy.CopyTo(world.Enemies[i].Targets);
            }
            // Attend best fitness
            //for (int i = 0; i < this.Enemies.Length; i++)
            //{
            //    world.Enemies[i] = this.Enemies[i].Clone();
            //}

            return world;
        }

        public override IDNA Revive()
        {
            CWorld world = new CWorld(this.Strategy, true);

            for (int i = 0; i < this.Genes.Length; i++)
            {
                world[i] = this[i].Clone();
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
            int nGenesPassed = 0;
            List<int> colPassedGenesUIDs = new List<int>();

            for (int i = nStart; i < nEnd; i++)
            {
                child[i] = partner[i].Clone();
                colPassedGenesUIDs.Add(partner[i].UID);
                nGenesPassed++;
            }

            int nGeneInsertionPos = 0;
            for (int i = 0; i < this.Genes.Length && nGeneInsertionPos < this.Genes.Length; i++)
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
