using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHBesignPattern.Model.Characters;

namespace GHBesignPattern.Model.Boards
{

    internal delegate bool AccessRestriction<T>(ICharacter<T> charater)
        where T : struct, IConvertible, IComparable, IFormattable;

    interface IAccess<T> where T : struct , IConvertible, IComparable, IFormattable
    {
        IZone<T> One { get; }
        IZone<T> Two { get; }
        /// <summary>
        /// Return the other zone
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        IZone<T> GetTarget(IZone<T> from);
        AccessRestriction<T> AccessRestricted { get; set; }
    }
}
