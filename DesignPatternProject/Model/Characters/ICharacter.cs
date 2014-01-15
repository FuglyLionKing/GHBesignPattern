using System;
using System.Collections.Generic;
using GHBesignPattern.Model.Boards;
using GHBesignPattern.Model.Items;

namespace GHBesignPattern.Model.Characters
{
    public interface ICharacter<TEnumType> : IObservor  where TEnumType : struct, IConvertible, IComparable, IFormattable
    {
        int Health { get; set; }
        IMovingBehavior<TEnumType> MovingBehavior { get; set; }
        IZone<TEnumType> Position { get; set; }
        String Name { get; set; }
        List<Objectif<TEnumType>> Objectives { get; set; }
        List<IItem> Items { get; set; }
    }
}