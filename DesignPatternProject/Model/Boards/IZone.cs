using System;
using System.Collections.Generic;
using GHBesignPattern.Model.Characters;
using GHBesignPattern.Model.Items;

namespace GHBesignPattern.Model.Boards
{
    public interface IZone 
    {
        List<IZone> InnerZones { get; set; }
        List<IAccess> Accesses { get; set; }
        List<IItem> Items { get; set; }
        List<ICharacter> Characters { get; set; }
    }
}