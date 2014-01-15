using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHBesignPattern.Model.Characters;

namespace GHBesignPattern.Model.Boards
{

    public delegate bool AccessRestriction(ICharacter charater);

    public interface IAccess 
    {
        IZone One { get; }
        IZone Two { get; }
        /// <summary>
        /// Return the other zone
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        IZone GetTarget(IZone from);
        AccessRestriction AccessRestricted { get; set; }
    }
}
