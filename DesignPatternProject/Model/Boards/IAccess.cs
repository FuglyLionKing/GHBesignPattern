using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHBesignPattern.Model.Boards
{
    interface IAccess
    {
        IZone One { get; }
        IZone Two { get; }
        /// <summary>
        /// Return the other zone
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        IZone GetTarget(IZone from);
        //TODO delegate returning boolean telling if a living thing can pass or not

    }
}
