using Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetLogics
{
    public class CWorld: ILive
    {
        public CMap MyWorld { get; set; }
        public Point2D Location{ get; set; }


        public CWorld()
        {
            this.MyWorld = new CMap(50, 25);
            this.Location = new Point2D(-this.MyWorld.GetWidth() / 2, -this.MyWorld.GetHeight() / 2);
        }

        public void Update()
        {

        }

        public void Draw(Graphics g)
        {
            this.MyWorld.Draw(g);
        }
    }
}
