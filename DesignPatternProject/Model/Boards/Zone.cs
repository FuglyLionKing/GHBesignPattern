using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHBesignPattern.Model.Characters;
using GHBesignPattern.Model.Items;

namespace GHBesignPattern.Model.Boards
{
    public class Zone : IZone
    {
        public Zone()
        {
            InnerZones = new List<IZone>();
            Accesses = new List<IAccess>();
            Items = new List<IItem>();
            Characters = new List<ICharacter>();
        }

        public List<IZone> InnerZones { get; set; }
        public List<IAccess> Accesses { get; set; }
        public List<Items.IItem> Items { get; set; }
        public List<Characters.ICharacter> Characters { get; set; }

        public int I, J;

        public override string ToString()
        {
            return "zone : " + I + ", " + J;
        }
    }
}
