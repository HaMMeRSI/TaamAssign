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
    public class CWorld: IDrawable
    {
        public CMap Terrain { get; set; }
        const int ArtilSize = 50;
        public List<CSimpleArtillary> Friendly { get; set; }
        public List<CSimpleArtillary> Enemy { get; set; }

        public CWorld()
        {
            this.Terrain = new CMap(10, 100);
            this.Friendly = new List<CSimpleArtillary>();
            this.Enemy = new List<CSimpleArtillary>();

            this.InitiallizeArmy();
        }

        public void InitiallizeArmy()
        {
            for (int i = 0; i < 15; i++)
            {
                CSimpleArtillary obj = new CSimpleArtillary();
                obj.InitiateGenome();
                obj.SetLocation(this.CenterizeArtillaryInGrid(Shared.Next(this.Terrain.GetColSize())), this.CenterizeArtillaryInGrid(this.Terrain.GetRowSize() - Shared.Next(this.Terrain.GetRowSize() / 3) - 1));
                this.Friendly.Add(obj);
            }

            for (int i = 0; i < 10; i++)
            {
                CSimpleArtillary obj = new CSimpleArtillary();
                obj.InitiateGenome();
                obj.SetLocation(this.CenterizeArtillaryInGrid(Shared.Next(this.Terrain.GetColSize())), this.CenterizeArtillaryInGrid(Shared.Next(this.Terrain.GetRowSize() / 3)));
                this.Enemy.Add(obj);
            }

            this.Execute();
        }

        public void Execute()
        {
            bool blnEndIndicator = false;
            while (!blnEndIndicator)
            {
                blnEndIndicator = true;
                foreach (CSimpleArtillary Cannon in this.Friendly)
                {
                    if (Cannon.Targets.Count != Cannon.ShotsToFire)
                    {
                        Cannon.Shoot(this.Enemy);
                    }

                    blnEndIndicator &= Cannon.Targets.Count == Cannon.ShotsToFire;
                }
            }
        }

        //private void AssessPopulation()
        //{
        //    IDNA BestDNA = new IDNA(this.Target.Length);
        //    float TotalFintess = 0;

        //    foreach (IDNA objDNA in this.Population)
        //    {
        //        objDNA.calcFitness(this.Target);

        //        TotalFintess += objDNA.Fitness;
        //        if (objDNA.Fitness > BestDNA.Fitness)
        //        {
        //            BestDNA = objDNA;
        //        }
        //    }

        //    this.BestFitness = BestDNA;
        //    this.AvreageFitness = TotalFintess / this.MyPopulationSize;
        //}

        #region Render

        Pen p = new Pen(Color.Green, 2);
        public void Draw(Graphics g)
        {
            this.Terrain.Draw(g);

            foreach (CSimpleArtillary MyCannon in this.Enemy)
            {
                g.FillEllipse(new SolidBrush(Color.Red), (float)MyCannon.Location.X, (float)MyCannon.Location.Y, ArtilSize, ArtilSize);
            }

            foreach (CSimpleArtillary MyCannon in this.Friendly)
            {
                g.FillEllipse(new SolidBrush(Color.Cyan), (float)MyCannon.Location.X, (float)MyCannon.Location.Y, ArtilSize, ArtilSize);

                foreach (CSimpleArtillary EnemyCannon in MyCannon.Targets)
                {
                    g.DrawLine(p, this.CentralizeShoot(MyCannon.Location), CentralizeShoot(EnemyCannon.Location));
                }
            }
        }

        private float CenterizeArtillaryInGrid(double nNum)
        {
            return (float)nNum * this.Terrain.CellSize + this.Terrain.CellSize / 2 - ArtilSize / 2;
        }

        private Point2D CentralizeShoot(Point2D Original)
        {
            return new Point2D(Original.X + ArtilSize / 2, Original.Y + ArtilSize / 2);
        } 

        #endregion
    }
}
