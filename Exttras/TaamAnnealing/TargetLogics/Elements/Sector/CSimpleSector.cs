using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TaamLogics
{
    public class CSimpleSector
    {
        public const int RenderSize = 50;

        public int UID { get; set; }
        public EConstraints ForceConstraint { get; set; }
        public ESectorialBrigade MySectorialBrigade { get; set; }
        public DateTime StartOfYear { get; set; }

        #region Builder

        public CSimpleSector SetUID(int UID)
        {
            this.UID = UID;
            return this;
        }

        #endregion

        public CSimpleSector(EConstraints ForceConstraint, ESectorialBrigade MySectorialBrigade, DateTime StartOfYear)
        {
            this.ForceConstraint = ForceConstraint;
            this.MySectorialBrigade = MySectorialBrigade;
            AssignmentStrategy.BrigadesData[MySectorialBrigade].RegisterSector(this);
            this.StartOfYear = StartOfYear.AddDays((AssignmentStrategy.BrigadesData[MySectorialBrigade].MySectors.Count - 1) * 7);
        }
    }
}
