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
        public int DeadCount { get; set; }

        public CWorld(TargetingStrategy Strategy)
            : base(Strategy.GetFriendlyCount())
        {
            this.Strategy = Strategy;
            this.DeadCount = 0;

            for (int i = 0; i < this.Genes.Length; i++)
            {
                this.Genes[i] = Strategy.FriendliesData[i].Clone().Mutate();
            }

            this.Enemies = Strategy.GetEnemyArtillary();
        }

        #region DNA

        public override void Execute()
        {
            bool blnEndIndicator = false;
            while (!blnEndIndicator)
            {
                blnEndIndicator = true;

                foreach (CSimpleArtillary Cannon in this.Genes)
                {
                    if (Cannon.Targets.Count < Cannon.ShotsToFire)
                    {
                        Cannon.ChooseTarget(this.Enemies);
                    }

                    blnEndIndicator &= Cannon.Targets.Count == Cannon.ShotsToFire;
                }
            }
        }

        public override void CalculateFitness()
        {
            int nDeadCount = 0;
            bool blnEndIndicator = false;

            while (!blnEndIndicator)
            {
                blnEndIndicator = true;
                foreach (CSimpleArtillary Cannon in this.Genes)
                {
                    nDeadCount += Cannon.Shoot(this.Enemies);
                    blnEndIndicator &= Cannon.ShotsTaken == Cannon.ShotsToFire;
                }
            }

            this.Fitness = nDeadCount;
        }

        protected override void Mutate()
        {
            bool Mutated = false;
            foreach (CSimpleArtillary Cannon in this.Genes)
            {
                if (Shared.HitChance(.05))
                {
                    Cannon.Mutate();
                    Mutated = true;
                }
            }

            if (Mutated)
            {
                this.Execute();
            }
        }

        public override IDNA Crossover(IDNA objPartner)
        {
            CWorld child = new CWorld(this.Strategy);
            CWorld partner = (CWorld)objPartner;

            for (int i = 0; i < partner.Genes.Length; i++)
            {
                child[i] = Shared.Coin() ? this[i].Clone() : partner[i].Clone();
            }

            child.Mutate();
            // child.Execute();

            return child;
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

        public override string ToString()
        {
            bool s = this.Genes.Select(x => x.Targets.Count).Sum() == this.DeadCount;
            return string.Format("D: {0}, T: {1} - {2}", this.DeadCount, string.Join(", ", this.Genes.Select(x => x.Targets.Count).ToArray()), s);
        }
    }
}
