using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHBesignPattern.Model.Boards;
using GHBesignPattern.Model.Items;

namespace GHBesignPattern.Model.Characters
{
    public interface ISightCapabilities
    {
        List<IZone> Find(ICharacter character, List<IItem> items, List<ICharacter> characters);
    }
}
