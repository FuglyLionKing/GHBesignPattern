using GHBesignPattern.Model.Boards;
using GHBesignPattern.Model.Characters;
using System;
using System.Collections.Generic;
using GHBesignPattern.Model.Items;
using MedievalWarfare.MedivalWarfare.Model.Organisation;

namespace MedievalWarfare.MedivalWarfare.Model.Character
{
    class MedievalCharacter : ICharacter, IMedievalObserver
    {
        IObservee IObserver.Subject
        {
            get { return Subject; }
            set { Subject = (TywinLannister)value; }
        }

        public TywinLannister Subject { get; set; }

        public void Update()
        {
            State = Subject.State;
        }

        public int Health { get; set; }
        public IMovingBehavior MovingBehavior { get; set; }
        public IZone Position { get; set; }
        public string Name { get; set; }
        public List<Objectif> Objectives { get; set; }
        public List<IItem> Items { get; set; }
        public Enum State { get; set; }
        public ISightCapabilities SightCapabilities { get; set; }

        protected MedievalCharacter(TywinLannister subject, int health, IMovingBehavior movingBehavior, IZone position, string name, List<Objectif> objectives, List<IItem> items, Enum state, ISightCapabilities sightCapabilities)
        {
            Subject = subject;
            Health = health;
            MovingBehavior = movingBehavior;
            Position = position;
            Name = name;
            Objectives = objectives;
            Items = items;
            State = state;
            SightCapabilities = sightCapabilities;
        }
    }
}
