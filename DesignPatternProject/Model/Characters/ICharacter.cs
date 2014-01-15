using System;
using System.Collections.Generic;
using GHBesignPattern.Model.Boards;
using GHBesignPattern.Model.Items;

namespace GHBesignPattern.Model.Characters
{
    internal interface ICharacter<TEnumType> : IObservor  where TEnumType : struct, IConvertible, IComparable, IFormattable
    {
        int Health { get; set; }
        IMovingBehavior MovingBehavior { get; set; }
        IZone Position { get; set; }
        String Name { get; set; }
        Enum StateE { set; }
        List<Objectif<TEnumType>> Objectives { get; set; }
        List<IItem> Items { get; set; }
    }
}