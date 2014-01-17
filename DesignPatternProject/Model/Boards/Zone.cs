using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHBesignPattern.Model.Boards
{
    public class Zone : IZone
    {
        public List<IZone> InnerZones { get; set; }
        public List<IAccess> Accesses { get; set; }
        public List<Items.IItem> Items { get; set; }
        public List<Characters.ICharacter> Characters { get; set; }
    }
}
