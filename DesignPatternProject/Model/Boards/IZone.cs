using System;
using System.Collections.Generic;
using GHBesignPattern.Model.Characters;
using GHBesignPattern.Model.Items;

namespace GHBesignPattern.Model.Boards
{
    public interface IZone 
    {
        List<IZone> InnerZones { get; }
        List<IAccess> Accesses { get; }
        List<IItem> Items { get; }
        List<ICharacter> Characters { get; }
    }
}