using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHBesignPattern.Model.Boards;
using GHBesignPattern.Model.Characters;

namespace MedievalWarfare.MedivalWarfare.Model.Character
{
    class PedestrianBehavior : IMovingBehavior 
    {
        public void Move(ICharacter character, IZone objectif)
        {
            throw new NotImplementedException();
        }

        public bool IsReachable(ICharacter character, IZone objectif)
        {
            throw new NotImplementedException();
        }
    }
}
