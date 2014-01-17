using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHBesignPattern.Model.Boards
{
    class SquareBoard : IBoard
    {
        Zone[,] zones;
        int length;
        int width;

        public SquareBoard(int length, int width)
        {
            this.length = length;
            this.width = width;

            zones = new Zone[length, width];
        }

        public void Build()
        {
            for(int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if(i != 0) zones[i,j].Accesses.Add(new BidirectionnalAccess(zones[i,j],zones[i-1,j]));
                    if (i != (length - 1)) zones[i, j].Accesses.Add(new BidirectionnalAccess(zones[i, j], zones[i + 1, j]));
                    if (j != 0) zones[i, j].Accesses.Add(new BidirectionnalAccess(zones[i, j], zones[i, j - 1]));
                    if (j != (width - 1)) zones[i, j].Accesses.Add(new BidirectionnalAccess(zones[i, j], zones[i, j + 1]));
                }
            }
        }
    }
}
