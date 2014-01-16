using GHBesignPattern.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GHBesignPattern.Model.Organisation;

namespace MedievalWarfare.MedivalWarfare.Model.Character
{
    class MedievalCharacter : ICharacter, IObserver
    {

        public int Health { get; set; }

        public IMovingBehavior MovingBehavior { get; set; }

        public GHBesignPattern.Model.Boards.IZone Position { get; set; }

        public string Name { get; set; }

        public List<Objectif> Objectives { get; set; }
        public List<GHBesignPattern.Model.Items.IItem> Items { get; set; }

        public Enum State { get; set; }

        public ISightCapabilities SightCapabilities { get; set; }

        public TywinLannister Subject { get; set; }


        public void Update()
        {
            this.State = Subject.State;
        }
    }
}
