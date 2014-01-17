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

        public void Move()
        {
            if (null == Objectives || 0 >= Objectives.Count)
            {
                if (null != MovingBehavior)
                {
                    MovingBehavior.Move(this, null);

                }
                return;
            }

            if (SightCapabilities != null)
            {
                var itemToFind = new List<IItem>();
                var characToFind = new List<ICharacter>();
                var zoneToFind = new List<IZone>();
                
                
                foreach(var objo in Objectives)
                {
                    if (objo.target is ICharacter)
                    {
                        characToFind.Add((ICharacter) objo.target);
                    }
                    else if (objo.target is IItem)
                    {
                        itemToFind.Add((IItem) objo.target);
                    }
                    else if (objo.target is IZone)
                    {
                        zoneToFind.Add((IZone) objo.target);
                    }
                }

                var found = SightCapabilities.Find(this, itemToFind, characToFind, zoneToFind);

                //TODO less arbitrary pickup

                MovingBehavior.Move(this, (null != found && 0 < found.Count ? found[0] : null));
            }

        }

        public void Examine()
        {
            foreach (var item in this.Position.Items)
            {
                Items.Add(item);
            }
            Position.Items.Clear();
           
        }

        public void ResolveObjectives()
        {
            if (null != Objectives)
            {

                for (var i =0; Objectives != null && i < Objectives.Count; ++i)
                {
                    var objective = Objectives[i];
                    objective.Done = objective.ObjectiveComplete(this);

                    if (objective.Done)
                    {
                        --i;
                        Objectives.Remove(objective);
                        if (null != objective.next)
                            Objectives.Add(objective.next);
                    }
                }

//                foreach (var objective in Objectives)
//                {
//                    objective.Done = objective.ObjectiveComplete(this);
//
//                    if (objective.Done)
//                    {
//                        Objectives.Remove(objective);
//                        if(null != objective.next)
//                            Objectives.Add(objective.next);
//                    }
//                }
            }
        }
    }
}
