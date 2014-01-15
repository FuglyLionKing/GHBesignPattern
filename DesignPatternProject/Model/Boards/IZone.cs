using System;
using System.Collections.Generic;
using GHBesignPattern.Model.Characters;
using GHBesignPattern.Model.Items;

namespace GHBesignPattern.Model.Boards
{
    public interface IZone<T> where T : struct , IConvertible, IComparable, IFormattable
    {
        List<IZone<T>> InnerZones { get; }
        List<IAccess<T>> Accesses { get; }
        List<IItem> Objects { get; }
//        List<ICharacter<T>> Characters { get; }
    }
}