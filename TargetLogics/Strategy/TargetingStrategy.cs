using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using EvolutionaryLogic;

namespace TargetLogics
{
    public class TargetingStrategy : IUpdateable, ICloneable<TargetingStrategy>
    {
        public Dictionary<int, CSimpleArtillary> FriendliesData { get; set; }
        public CSimpleArtillary[] EnemiesData { get; set; }

        public TargetingStrategy(IStrategyDataSource DataSource)
        {
            this.FriendliesData = new Dictionary<int, CSimpleArtillary>();
            GlobalConfiguration.GameData.MaxAttackPrice = 0;
            GlobalConfiguration.GameData.MaxAttackImportance = 0;
            GlobalConfiguration.GameData.TotalAttackAmmo = 0;
            CSimpleArtillary[] FriendlyData = DataSource.GetFriendlyData();
            foreach (CSimpleArtillary Cannon in FriendlyData)
            {
                this.FriendliesData[Cannon.UID] = Cannon;
            }

            this.EnemiesData = DataSource.GetEnemyData();

            GlobalConfiguration.GameData.MaxAttackPrice = GlobalConfiguration.GameData.MaxAttackPrice == 0 ? 1 : GlobalConfiguration.GameData.MaxAttackPrice;
            GlobalConfiguration.GameData.MaxAttackImportance = GlobalConfiguration.GameData.MaxAttackImportance == 0 ? 1 : GlobalConfiguration.GameData.MaxAttackImportance;
        }

        private TargetingStrategy(int nEnemyCount)
        {
            this.FriendliesData = new Dictionary<int, CSimpleArtillary>();
            this.EnemiesData = new CSimpleArtillary[nEnemyCount];
        }

        public int GetFriendlyCount()
        {
            return this.FriendliesData.Count;
        }

        public int GetEnemyCount()
        {
            return this.EnemiesData.Length;
        }

        public void Update()
        {
            foreach (CSimpleArtillary MyCannon in this.EnemiesData)
            {
                MyCannon.Update();
            }

            foreach (CSimpleArtillary MyCannon in this.FriendliesData.Values)
            {
                MyCannon.Update();
            }
        }

        public TargetingStrategy Clone()
        {
            TargetingStrategy s = new TargetingStrategy(this.EnemiesData.Length);

            foreach (int UID in this.FriendliesData.Keys)
            {
                s.FriendliesData[UID] = this.FriendliesData[UID].Clone();
            }

            for (int i = 0; i < this.EnemiesData.Length; i++)
            {
                s.EnemiesData[i] = this.EnemiesData[i].Clone();
            }

            return s;
        }
    }
}
