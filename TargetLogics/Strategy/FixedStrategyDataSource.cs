using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetLogics
{
    class FixedStrategyDataSource : IStrategyDataSource
    {
        public CMap Terrain { get; set; }

        public FixedStrategyDataSource(CMap Terrain)
        {
            this.Terrain = Terrain;
        }

        public CSimpleArtillary[] GetEnemyData()
        {
            CSimpleArtillary[] EnemiesData = new CSimpleArtillary[20];

            #region LeftSide - 50 - Land
            //ForceConstraint, MaxAccuracyRequired, nImportance
            CSimpleArtillary artillary0 = new CTarget((int)(ENUMForces.Land), 50, 1000);
            artillary0.SetLocation(this.CenterizeArtillaryInGrid(0, 0));
            EnemiesData[0] = artillary0;

            //ForceConstraint, MaxAccuracyRequired, nImportance
            CSimpleArtillary artillary1 = new CTarget((int)(ENUMForces.Land), 50, 548);
            artillary1.SetLocation(this.CenterizeArtillaryInGrid(1, 0));
            EnemiesData[1] = artillary1;

            //ForceConstraint, MaxAccuracyRequired, nImportance
            CSimpleArtillary artillary5 = new CTarget((int)(ENUMForces.Land), 50, 752);
            artillary5.SetLocation(this.CenterizeArtillaryInGrid(2, 1));
            EnemiesData[5] = artillary5;

            //ForceConstraint, MaxAccuracyRequired, nImportance
            CSimpleArtillary artillary17 = new CTarget((int)(ENUMForces.Land), 50, 345);
            artillary17.SetLocation(this.CenterizeArtillaryInGrid(3, 1));
            EnemiesData[17] = artillary17;

            //ForceConstraint, MaxAccuracyRequired, nImportance
            CSimpleArtillary artillary9 = new CTarget((int)(ENUMForces.Land), 50, 872);
            artillary9.SetLocation(this.CenterizeArtillaryInGrid(0, 1));
            EnemiesData[9] = artillary9;

            //ForceConstraint, MaxAccuracyRequired, nImportance
            CSimpleArtillary artillary13 = new CTarget((int)(ENUMForces.Land), 50, 700);
            artillary13.SetLocation(this.CenterizeArtillaryInGrid(1, 2));
            EnemiesData[13] = artillary13;
            #endregion

            #region Middle - 35 - Air
            //ForceConstraint, MaxAccu1racyRequired, nImportance
            CSimpleArtillary artillary15 = new CTarget((int)(ENUMForces.Air), 35, 999);
            artillary15.SetLocation(this.CenterizeArtillaryInGrid(4, 0));
            EnemiesData[15] = artillary15;

            //ForceConstraint, MaxAccuracyRequired, nImportance
            CSimpleArtillary artillary2 = new CTarget((int)(ENUMForces.Air), 35, 245);
            artillary2.SetLocation(this.CenterizeArtillaryInGrid(5, 0));
            EnemiesData[2] = artillary2;

            //ForceConstraint, MaxAccuracyRequired, nImportance
            CSimpleArtillary artillary16 = new CTarget((int)(ENUMForces.Air), 35, 452);
            artillary16.SetLocation(this.CenterizeArtillaryInGrid(6, 0));
            EnemiesData[16] = artillary16;
            
            //ForceConstraint, MaxAccuracyRequired, nImportance
            CSimpleArtillary artillary3 = new CTarget((int)(ENUMForces.Air), 35, 10);
            artillary3.SetLocation(this.CenterizeArtillaryInGrid(7, 0));
            EnemiesData[3] = artillary3;

            //ForceConstraint, MaxAccuracyRequired, nImportance
            CSimpleArtillary artillary6 = new CTarget((int)(ENUMForces.Air), 35, 105);
            artillary6.SetLocation(this.CenterizeArtillaryInGrid(4, 1));
            EnemiesData[6] = artillary6;

            //ForceConstraint, MaxAccuracyRequired, nImportance
            CSimpleArtillary artillary7 = new CTarget((int)(ENUMForces.Air), 35, 10);
            artillary7.SetLocation(this.CenterizeArtillaryInGrid(5, 1));
            EnemiesData[7] = artillary7;

            //ForceConstraint, MaxAccuracyRequired, nImportance
            CSimpleArtillary artillary18 = new CTarget((int)(ENUMForces.Air), 35, 555);
            artillary18.SetLocation(this.CenterizeArtillaryInGrid(6, 1));
            EnemiesData[18] = artillary18;

            //ForceConstraint, MaxAccuracyRequired, nImportance
            CSimpleArtillary artillary8 = new CTarget((int)(ENUMForces.Air), 35, 275);
            artillary8.SetLocation(this.CenterizeArtillaryInGrid(7, 1));
            EnemiesData[8] = artillary8;

            //ForceConstraint, MaxAccuracyRequired, nImportance
            CSimpleArtillary artillary12 = new CTarget((int)(ENUMForces.Air), 35, 127);
            artillary12.SetLocation(this.CenterizeArtillaryInGrid(4, 2));
            EnemiesData[12] = artillary12;
            #endregion

            #region RightSide - 30 - Sea
            //ForceConstraint, MaxAccuracyRequired, nImportance
            CSimpleArtillary artillary19 = new CTarget((int)(ENUMForces.Sea), 30, 654);
            artillary19.SetLocation(this.CenterizeArtillaryInGrid(8, 0));
            EnemiesData[19] = artillary19;

            //ForceConstraint, MaxAccuracyRequired, nImportance
            CSimpleArtillary artillary4 = new CTarget((int)(ENUMForces.Sea), 30, 345);
            artillary4.SetLocation(this.CenterizeArtillaryInGrid(9, 0));
            EnemiesData[4] = artillary4;

            //ForceConstraint, MaxAccuracyRequired, nImportance
            CSimpleArtillary artillary10 = new CTarget((int)(ENUMForces.Sea), 30, 782);
            artillary10.SetLocation(this.CenterizeArtillaryInGrid(9, 1));
            EnemiesData[10] = artillary10;

            //ForceConstraint, MaxAccuracyRequired, nImportance
            CSimpleArtillary artillary14 = new CTarget((int)(ENUMForces.Sea), 30, 287);
            artillary14.SetLocation(this.CenterizeArtillaryInGrid(9, 2));
            EnemiesData[14] = artillary14;
            #endregion

            //ForceConstraint, MaxAccuracyRequired, nImportance
            CSimpleArtillary artillary11 = new CTarget((int)(ENUMForces.Sea), 30, 527);
            artillary11.SetLocation(this.CenterizeArtillaryInGrid(3, 2));
            EnemiesData[11] = artillary11;

            GlobalConfiguration.GameSettings.EnemyCount = EnemiesData.Length;
            foreach (CSimpleArtillary Cannon in EnemiesData)
            {
                GlobalConfiguration.GameData.MaxAttackImportance += Cannon.Importance;
            }

            return EnemiesData;
        }

        public CSimpleArtillary[] GetFriendlyData()
        {
            CSimpleArtillary[] FriendlyData = new CSimpleArtillary[12];

            #region LeftSide - Land
            //fRange, nAmmunition, fDamage, nPriceForShot, ForceConstraint, nAccuracy
            CSimpleArtillary artillary9 = new CArtillary(2424, 5, .4f, 222, (int)(ENUMForces.Land), 50);
            artillary9.SetLocation(this.CenterizeArtillaryInGrid(2, 7));
            artillary9.SetUID(9);
            FriendlyData[9] = artillary9;

            //fRange, nAmmunition, fDamage, nPriceForShot, ForceConstraint, nAccuracy
            CSimpleArtillary artillary8 = new CArtillary(2222, 3, .9333314f, 923, (int)(ENUMForces.Land), 50);
            artillary8.SetLocation(this.CenterizeArtillaryInGrid(3, 7));
            artillary8.SetUID(8);
            FriendlyData[8] = artillary8;

            //fRange, nAmmunition, fDamage, nPriceForShot, ForceConstraint, nAccuracy
            CSimpleArtillary artillary6 = new CArtillary(2345, 2, .5f, 675, (int)(ENUMForces.Land), 35);
            artillary6.SetLocation(this.CenterizeArtillaryInGrid(4, 8));
            artillary6.SetUID(6);
            FriendlyData[6] = artillary6;

            //fRange, nAmmunition, fDamage, nPriceForShot, ForceConstraint, nAccuracy
            CSimpleArtillary artillary4 = new CArtillary(1800, 3, .63333f, 400, (int)(ENUMForces.Land), 50);
            artillary4.SetLocation(this.CenterizeArtillaryInGrid(2, 9));
            artillary4.SetUID(4);
            FriendlyData[4] = artillary4;
            #endregion

            #region Middle - 35 - Air
            //fRange, nAmmunition, fDamage, nPriceForShot, ForceConstraint, nAccuracy
            CSimpleArtillary artillary7 = new CArtillary(2483, 4, .47748f, 457, (int)(ENUMForces.Air), 35);
            artillary7.SetLocation(this.CenterizeArtillaryInGrid(6, 8));
            artillary7.SetUID(7);
            FriendlyData[7] = artillary7;

            //fRange, nAmmunition, fDamage, nPriceForShot, ForceConstraint, nAccuracy
            CSimpleArtillary artillary3 = new CArtillary(2210, 5, .8872f, 200, (int)(ENUMForces.Air), 35);
            artillary3.SetLocation(this.CenterizeArtillaryInGrid(4, 9));
            artillary3.SetUID(3);
            FriendlyData[3] = artillary3;

            //fRange, nAmmunition, fDamage, nPriceForShot, ForceConstraint, nAccuracy
            CSimpleArtillary artillary2 = new CArtillary(2100, 4, .453f, 450, (int)(ENUMForces.Air), 35);
            artillary2.SetLocation(this.CenterizeArtillaryInGrid(5, 9));
            artillary2.SetUID(2);
            FriendlyData[2] = artillary2;

            //fRange, nAmmunition, fDamage, nPriceForShot, ForceConstraint, nAccuracy
            CSimpleArtillary artillary1 = new CArtillary(2000, 4, .4f, 200, (int)(ENUMForces.Air), 35);
            artillary1.SetLocation(this.CenterizeArtillaryInGrid(7, 9));
            artillary1.SetUID(1);
            FriendlyData[1] = artillary1;

            //fRange, nAmmunition, fDamage, nPriceForShot, ForceConstraint, nAccuracy
            CSimpleArtillary artillary10 = new CArtillary(2000, 4, .5f, 200, (int)(ENUMForces.Air), 35);
            artillary10.SetLocation(this.CenterizeArtillaryInGrid(5, 7));
            artillary10.SetUID(10);
            FriendlyData[10] = artillary10;
            #endregion

            #region RightSide - 30 - Sea
            //fRange, nAmmunition, fDamage, nPriceForShot, ForceConstraint, nAccuracy
            CSimpleArtillary artillary0 = new CArtillary(2500, 2, 1, 1000, (int)(ENUMForces.Sea), 30);
            artillary0.SetLocation(this.CenterizeArtillaryInGrid(9, 9));
            artillary0.SetUID(0);
            FriendlyData[0] = artillary0;

            //fRange, nAmmunition, fDamage, nPriceForShot, ForceConstraint, nAccuracy
            CSimpleArtillary artillary5 = new CArtillary(2400, 4, .457f, 222, (int)(ENUMForces.Sea), 30);
            artillary5.SetLocation(this.CenterizeArtillaryInGrid(9, 8));
            artillary5.SetUID(5);
            FriendlyData[5] = artillary5;

            //fRange, nAmmunition, fDamage, nPriceForShot, ForceConstraint, nAccuracy
            CSimpleArtillary artillary11 = new CArtillary(2400, 4, .5f, 202, (int)(ENUMForces.Sea), 30);
            artillary11.SetLocation(this.CenterizeArtillaryInGrid(9, 7));
            artillary11.SetUID(11);
            FriendlyData[11] = artillary11;
            #endregion

            GlobalConfiguration.GameSettings.FriendlyCount = FriendlyData.Length;
            foreach (CSimpleArtillary Cannon in FriendlyData)
            {
                GlobalConfiguration.GameData.TotalAttackAmmo += Cannon.Ammunition;
                GlobalConfiguration.GameData.MaxAttackPrice += Cannon.PriceForShot;
            }

            return FriendlyData;
        }

        private Point2D CenterizeArtillaryInGrid(double dX, double dY)
        {
            return new Point2D(dX * this.Terrain.CellSize + this.Terrain.CellSize / 2, dY * this.Terrain.CellSize + this.Terrain.CellSize / 2);
        }

    }
}
