using EvolutionaryLogic;
using Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaamLogics;

namespace TaamAssign
{
    public abstract class BaseOptimizationLogic
    {
        public bool IsStarted { get; set; }
        public Font f = new Font(FontFamily.GenericMonospace, 15);
        public SolidBrush b = new SolidBrush(Color.Black);
        public Pen p = new Pen(new SolidBrush(Color.Black), 3);

        public abstract CTaamAssignment GetBestFitness();

        #region Drawers

        public abstract CStatutsGraph GetStatusGraph();
        public Action<Graphics> GetStrategyDrawer()
        {
            return (g) =>
            {
                CTaamAssignment BestFitness = this.GetBestFitness();
                if (BestFitness != null)
                {
                    int CounterY = 0;
                    var Genes = BestFitness.GetGenes();
                    for (int i = 0; i < CStrategyPool.ActiveStrategy.GetSectorsCount(); i++)
                    {
                        var ActiveSector = CStrategyPool.ActiveStrategy.SectorsData[i];
                        CSimpleBattalion[] AssignedBattalions = new CSimpleBattalion[TaamCalendar.ChunksCount];
                        Point2D Location = new Point2D();

                        for (int j = 0; j < TaamCalendar.ChunksCount; j++)
                        {
                            CSingleAssignment SectorAssignment = Genes[i * TaamCalendar.ChunksCount + j];
                            AssignedBattalions[j] = CStrategyPool.ActiveStrategy.BattalionsData[SectorAssignment.BattalionUID];
                        }

                        Location.Y = CounterY;
                        g.DrawString(ActiveSector.UID.ToString() + ":", f, b, (int)Location.X - 130, (int)Location.Y + 40);
                        g.DrawString(ActiveSector.MySectorialBrigade.ToString() + ":", f, b, (int)Location.X - 130, (int)Location.Y + 60);
                        g.DrawRectangle(p, (int)Location.X, (int)Location.Y, 800, 100);

                        for (int j = 0; j < TaamCalendar.ChunksCount; j++)
                        {
                            g.DrawLine(p, (int)Location.X + 200 * j, (int)Location.Y, (int)Location.X + 200 * j, (int)Location.Y + 100);
                            if (AssignedBattalions[j] != null)
                            {
                                SolidBrush bbb = new SolidBrush(CStrategyPool.ActiveStrategy.BattalionsData[AssignedBattalions[j].UID].ScoreAssignment(Genes[i * TaamCalendar.ChunksCount + j]) > 0 ? Color.Red : Color.Black);

                                CSimpleBattalion Battalion = CStrategyPool.ActiveStrategy.BattalionsData[Genes[i * TaamCalendar.ChunksCount + j].BattalionUID];
                                CSimpleSector Sector = CStrategyPool.ActiveStrategy.SectorsData[Genes[i * TaamCalendar.ChunksCount + j].SectorUID];

                                if ((Battalion.Force & Sector.ForceConstraint) == 0)
                                {
                                    bbb.Color = Color.Yellow;
                                }

                                int OffsetX = 90 + (200 * j);
                                g.DrawString(AssignedBattalions[j].UID.ToString(), f, bbb, (int)Location.X + OffsetX, (int)Location.Y + 40);
                            }
                        }


                        CounterY += 120;
                    }
                }
            };
        }
        public Action<Graphics> GetBattalionToSectorSumDrawer()
        {
            return g =>
            {
                CTaamAssignment BestFitness = this.GetBestFitness();
                if (BestFitness != null)
                {
                    int yCounter = 0;
                    var Assignments = BestFitness.GetGenes();

                    // [] Battalion, [] 4 Rotations
                    DrawFollower[] BattalionToSectorRotation = Shared.SafeArray(CStrategyPool.ActiveStrategy.GetBattalionsCount(), () => new DrawFollower());
                    for (int i = 0; i < Assignments.Length; i++)
                    {
                        BattalionToSectorRotation[Assignments[i].BattalionUID][i % TaamCalendar.ChunksCount]++;
                    }

                    for (int i = 0; i < BattalionToSectorRotation.Length; i++)
                    {
                        SolidBrush bb = new SolidBrush(Color.Black);
                        string strRow = string.Format("b" + (i < 10 ? "0" + i : i + ""));
                        string strRotations = "";

                        int nMoreThenOne = 0;
                        for (int j = 0; j < BattalionToSectorRotation[i].RotationsCount.Length; j++)
                        {
                            if (BattalionToSectorRotation[i][j] != 0)
                            {
                                strRotations += "r" + j + ": " + BattalionToSectorRotation[i][j] + ", ";
                                nMoreThenOne++;
                            }
                            if (BattalionToSectorRotation[i][j] > 1 || nMoreThenOne > 2)
                            {
                                bb.Color = Color.Red;
                            }
                        }

                        strRow += ";   " + strRotations;
                        g.DrawString(strRow, f, bb, 0, yCounter);
                        yCounter += 20;
                    }
                }
            };
        }
        public Action<Graphics> GetStatusGraphDrawer()
        {
            return g => GetStatusGraph()?.Draw(g);
        }
        public abstract Action<Graphics> GetLoggerDrawer();

        #endregion

        public abstract void InitPopulation();
        public Func<IDNA> GetPopulationGenerator()
        {
            return () => new CTaamAssignment();
        }

        public void Restrategize()
        {
            CStrategyPool.CreateRandomStrategy();
            this.InitPopulation();
        }

        public void InitOptimizer()
        {
            if (this.IsStarted)
            {
                this.InitPopulation();
            }
            else
            {
                this.Restrategize();
            }

            this.IsStarted = true;
        }

        public abstract Task LaunchOptimizer(Progress<IDNA> progress);
    }
}