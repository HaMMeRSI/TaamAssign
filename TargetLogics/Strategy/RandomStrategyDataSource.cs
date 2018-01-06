using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaamLogics
{
    public class RandomStrategyDataSource : IStrategyDataSource
    {
        public CMap Terrain { get; set; }

        public RandomStrategyDataSource(CMap Terrain)
        {
            this.Terrain = Terrain;
        }

        private float CenterizeArtillaryInGrid(double nNum)
        {
            return (float)nNum * this.Terrain.CellSize + this.Terrain.CellSize / 2;
        }
        private bool Contains(CSimpleBattalion[] collection, Point2D Target)
        {
            return collection.FirstOrDefault(x => x != null && x.Location.Equals(Target)) != null;
        }

        public CSimpleBattalion[] GetBatalionData()
        {
            throw new NotImplementedException();
        }

        public CSimpleSector[] GetSectorData()
        {
            throw new NotImplementedException();
        }

        public CSimpleBattalion[] GetReservedData()
        {
            throw new NotImplementedException();
        }
    }
}
