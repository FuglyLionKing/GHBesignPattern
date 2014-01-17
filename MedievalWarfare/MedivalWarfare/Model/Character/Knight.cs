using System;
using System.Collections.Generic;
using GHBesignPattern.Model.Boards;
using GHBesignPattern.Model.Characters;
using GHBesignPattern.Model.Items;

namespace MedievalWarfare.MedivalWarfare.Model.Character
{
    class Knight : MedievalCharacter
    {
        public Knight(TywinLannister subject, int health, IMovingBehavior movingBehavior, IZone position, string name, List<Objectif> objectives, List<IItem> items, Enum state, ISightCapabilities sightCapabilities) : base(subject, health, movingBehavior, position, name, objectives, items, state, sightCapabilities)
        {

        }
    }
}
