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
        IZone From { get; }
        IZone Target { get; }

        AccessRestriction AccessRestricted { get; set; }
    }
}
