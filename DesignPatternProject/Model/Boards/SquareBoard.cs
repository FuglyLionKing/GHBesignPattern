using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHBesignPattern.Model.Boards
{
    public class SquareBoard : IBoard
    {
        public Zone[,] Zones;
        int length;
        int width;

        public SquareBoard(int length, int width)
        {
            this.length = length;
            this.width = width;

            this.Zones = new Zone[length, width];
        }

        public void Build()
        {
            for(int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i != 0) this.Zones[i, j].Accesses.Add(new BidirectionnalAccess(this.Zones[i, j], this.Zones[i - 1, j]));
                    if (i != (length - 1)) this.Zones[i, j].Accesses.Add(new BidirectionnalAccess(this.Zones[i, j], this.Zones[i + 1, j]));
                    if (j != 0) this.Zones[i, j].Accesses.Add(new BidirectionnalAccess(this.Zones[i, j], this.Zones[i, j - 1]));
                    if (j != (width - 1)) this.Zones[i, j].Accesses.Add(new BidirectionnalAccess(this.Zones[i, j], this.Zones[i, j + 1]));
                }
            }
        }
    }
}
