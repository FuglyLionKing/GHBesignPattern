using System;
using System.Collections.Generic;
using GHBesignPattern.Model.Boards;
using GHBesignPattern.Model.Items;

namespace GHBesignPattern.Model.Characters
{
    public interface ICharacter :  IObservor  
    {
        int Health { get; set; }
        IMovingBehavior MovingBehavior { get; set; } 
        IZone Position { get; set; }
        String Name { get; set; }
        List<Objectif> Objectives { get; set; }
        List<IItem> Items { get; set; }
        Enum State { get; set; }


    }

}