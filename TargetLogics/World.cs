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
    public class CWorld : DNA<CSimpleArtillary>, ILive
    {
        public CSimpleArtillary[] Enemies { get; set; }
        private TargetingStrategy Strategy { get; set; }

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

            for (int i = 0; i < this.Genes.Length; i++)
            {
                this.Genes[i] = Strategy.FriendliesData[i].Clone();
            }

            //this.Enemies = Strategy.GetEnemyArtillary();

            this.Enemies = Strategy.EnemiesData;
        }

        private CWorld(TargetingStrategy Strategy, bool isSimple)
            : base(Strategy.GetFriendlyCount())
        {
            this.Strategy = Strategy;
            this.TotalAttackPrice = 0;
            this.DeadCount = 0;
            this.TotalAttackImportance = 0;
            this.Enemies = new CSimpleArtillary[Strategy.GetEnemyCount()];
        }

        #region DNA

        public override void Execute()
        {
            foreach (CSimpleArtillary Cannon in this.Genes)
            {
                if(Cannon.Targets.Count < Cannon.Ammunition)
                {
                    Cannon.ChooseTargets(this.Enemies);
                }
            }
        }

        public override void CalculateFitness()
        {
            bool blnEndIndicator = false;
            Strategy.ResetEnemyStatus();

            while (!blnEndIndicator)
            {
                blnEndIndicator = true;
                foreach (CSimpleArtillary Cannon in this.Genes)
                {
                    this.DeadCount += Cannon.Fire(this.Enemies);
                    blnEndIndicator &= Cannon.ShotsTaken == Cannon.Ammunition;
                }
            }

            float DeadFactor = (float)this.DeadCount / this.Strategy.GetEnemyCount();

            foreach (CSimpleArtillary EnemyCannon in this.Enemies)
            {
                if (EnemyCannon.Health <= 0)
                {
                    foreach (CSimpleArtillary HittedBy in EnemyCannon.HittedBy)
                    {
                        this.TotalAttackPrice += HittedBy.PriceForShot;
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
            foreach (CSimpleArtillary Cannon in this.Genes)
            {
                if (Shared.HitChance(GlobalConfiguration.MutationChance / 100))
                {
                    Cannon.Mutate();
                    Mutated = true;
                }
            }

            if (GlobalConfiguration.PartialGenomCrossover && Shared.HitChance(GlobalConfiguration.MutationChance / 100))
            {
                int nReplaceWith;
                CSimpleArtillary Temp;
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
                world[i] = this[i].Revive();
            }

            world.Enemies = this.Enemies;
            return world;
        }

        #endregion

        #region ILive

        public void Draw(Graphics g)
        {
            foreach (CSimpleArtillary MyCannon in this.Enemies)
            {
                MyCannon.Draw(g);
            }

            foreach (CSimpleArtillary MyCannon in this.Genes)
            {
                MyCannon.Draw(g);
            }
        }

        public void Update()
        {
            foreach (CSimpleArtillary MyCannon in this.Enemies)
            {
                MyCannon.Update();
            }

            foreach (CSimpleArtillary MyCannon in this.Genes)
            {
                MyCannon.Update();
            }
        }

        #endregion

        #region Genetic Methods

        public IDNA CoinCrossover(IDNA objPartner)
        {
            CWorld child = new CWorld(this.Strategy);
            CWorld partner = (CWorld)objPartner;

            for (int i = 0; i < partner.Genes.Length; i++)
            {
                child[i] = Shared.Coin() ? this[i].Revive() : partner[i].Revive();
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
                child[i] = partner[i].Revive();
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

                child[nGeneInsertionPos] = this.Genes[i].Revive();
                nGeneInsertionPos++;
            }

            child.Mutate();

            return child;
        }

        #endregion
    }
}
