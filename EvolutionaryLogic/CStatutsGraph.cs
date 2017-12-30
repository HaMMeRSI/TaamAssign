using Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryLogic
{
    public class CStatutsGraph : IDrawable
    {
        const int X_JUMP = 4;
        const int Y_JUMP = 1000;
        private List<float> BestFitnessHistory { get; set; }
        public float Average { get; set; }
        public Pen HistoryPen { get; set; }
        public Pen AveragePen { get; set; }
        public Pen BestPen { get; set; }
        public float BestFiteness { get; set; }

        public CStatutsGraph()
        {
            this.HistoryPen = new Pen(Color.Green, 4);
            this.AveragePen = new Pen(Color.Red, 1);
            this.BestPen = new Pen(Color.Blue, 1);
            this.BestFitnessHistory = new List<float>();
            this.BestFiteness = 0;
            this.Average = 0;
        }

        public void AddToHistory(float fValue)
        {
            this.BestFitnessHistory.Add(fValue);
            if(this.BestFiteness < fValue)
            {
                this.BestFiteness = fValue;
            }
        }

        public void ClearHistory()
        {
            this.BestFitnessHistory.Clear();
        }

        public int GetWidth()
        {
            return this.BestFitnessHistory.Count * X_JUMP;
        }

        public int GetHeight()
        {
            if (this.BestFitnessHistory.Count > 1)
            {
                return (int)(-(this.BestFitnessHistory[this.BestFitnessHistory.Count - 1] * Y_JUMP) + this.BestFitnessHistory[0] * Y_JUMP);
            }

            return 0;
        }

        public void Draw(Graphics g)
        {
            if (BestFitnessHistory.Count == 0)
            {
                return;
            }

            PointF[] points = new PointF[BestFitnessHistory.Count];

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new PointF(i * X_JUMP, this.GetYParsed(this.BestFitnessHistory[i]));
            }

            if (points.Length > 1)
            {
                g.DrawLines(this.HistoryPen, points);
            }

            g.DrawLine(this.BestPen, -1000, this.GetYParsed(this.BestFiteness)- this.HistoryPen.Width / 2, this.GetWidth() + 1000, this.GetYParsed(this.BestFiteness)- this.HistoryPen.Width / 2);
            g.DrawLine(this.AveragePen, -1000, this.GetYParsed(this.Average)- this.HistoryPen.Width / 2, this.GetWidth() + 1000, this.GetYParsed(this.Average) - this.HistoryPen.Width / 2);
        }

        private float GetYParsed(float fValue)
        {
            return -(fValue * Y_JUMP) + this.BestFitnessHistory[0] * Y_JUMP;
        }
    }
}