using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHBesignPattern.Model.Boards
{
    interface IZone
    {
        List<IZone> InnerZones { get; }
        List<IAccess> Accesses { get; }
        List<IObject> Objects { get; }
        //TODO add LivingThings list 


    }
}
