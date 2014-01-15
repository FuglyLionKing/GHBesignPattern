using System;
using System.Collections.Generic;
using GHBesignPattern.Model.Boards;
using GHBesignPattern.Model.Items;
using SimulationV1.Model.Characters;

namespace GHBesignPattern.Model.Characters
{
    interface ICharacter : IObservor
    {
        int Health { get; set; }
        IMovingBehavior MovingBehavior { get; set; }
        IZone Position { get; set; }
        String Name { get; set; }
        State State { get; set; }
        List<Objectif> objectives {get; set;}
        List<IItem> Items { get; set; }


    }
}
