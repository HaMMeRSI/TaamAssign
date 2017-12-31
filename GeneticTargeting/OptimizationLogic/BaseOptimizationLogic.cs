using OptimizationLogics;
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
    public abstract class BaseOptimizationLogic<T>
    {
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
                DateTime NewYear = new DateTime(2018, 1, 1);
                CSingleAssignment[] Genes = this.GetBestFitness()?.GetGenes();
                if (Genes != null)
                {
                    int CounterY = 0;
                    int OffsetX = 0;
                    CSingleAssignment FirstAssignemnt;
                    CSingleAssignment CurrentAssignemnt;
                    CSimpleSector ActiveSector;

                    for (int i = 0; i < CStrategyPool.ActiveStrategy.GetSectorsCount(); i++)
                    {
                        FirstAssignemnt = Genes[i * TaamCalendar.ChunksCount];
                        int xPad = (int)(FirstAssignemnt.Start - NewYear).TotalDays * 4;
                        Point2D Location = new Point2D(xPad, CounterY);
                        ActiveSector = CStrategyPool.ActiveStrategy.SectorsData[i];
                        g.DrawString(ActiveSector.UID.ToString() + ":", f, b, (int)Location.X - 130, (int)Location.Y + 40);
                        g.DrawString(ActiveSector.MySectorialBrigade.ToString() + ":", f, b, (int)Location.X - 130, (int)Location.Y + 60);
                        g.DrawRectangle(p, (int)Location.X, (int)Location.Y, 800, 100);

                        for (int j = 0; j < TaamCalendar.ChunksCount; j++)
                        {
                            CurrentAssignemnt = Genes[i * TaamCalendar.ChunksCount + j];
                            CSimpleBattalion AssignedBattalion = CStrategyPool.ActiveStrategy.BattalionsData[CurrentAssignemnt.BattalionUID];
                            g.DrawLine(p, (int)Location.X + 200 * j, (int)Location.Y, (int)Location.X + 200 * j, (int)Location.Y + 100);
                            g.DrawString(CurrentAssignemnt.Start.ToShortDateString(), f,b, (int)Location.X + 200 * j, (int)Location.Y);

                            if(j == TaamCalendar.ChunksCount - 1)
                            {
                                g.DrawString(CurrentAssignemnt.End.ToShortDateString(), f,b, (int)Location.X + 200 * TaamCalendar.ChunksCount, (int)Location.Y);
                            }

                            if (AssignedBattalion != null)
                            {
                                SolidBrush bbb = new SolidBrush(CStrategyPool.ActiveStrategy.BattalionsData[AssignedBattalion.UID].ScoreAssignment(CurrentAssignemnt) > 0 ? Color.Red : Color.Black);

                                CSimpleBattalion Battalion = CStrategyPool.ActiveStrategy.BattalionsData[CurrentAssignemnt.BattalionUID];
                                CSimpleSector Sector = CStrategyPool.ActiveStrategy.SectorsData[CurrentAssignemnt.SectorUID];

                                if ((Battalion.Force & Sector.ForceConstraint) == 0)
                                {
                                    bbb.Color = Color.Yellow;
                                }

                                OffsetX = 90 + (200 * j);
                                g.DrawString(AssignedBattalion.UID.ToString(), f, bbb, (int)Location.X + OffsetX, (int)Location.Y + 40);
                            }
                        }


                        CounterY += 100;
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

        public abstract void InitPopulation(Func<DNA<T>> GetPopulationGenerator);

        public void Restrategize(Func<DNA<T>> GetPopulationGenerator)
        {
            CStrategyPool.CreateRandomStrategy();
            this.InitPopulation(GetPopulationGenerator);
        }

        public void InitOptimizer(Func<DNA<T>> GetPopulationGenerator)
        {
            this.InitPopulation(GetPopulationGenerator);
        }

        public abstract Task LaunchOptimizer(Progress<IDNA<T>> progress);
    }
}