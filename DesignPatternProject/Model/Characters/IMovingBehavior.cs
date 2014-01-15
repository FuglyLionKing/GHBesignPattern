using System;
using GHBesignPattern.Model.Boards;

namespace GHBesignPattern.Model.Characters
{
   public  interface IMovingBehavior 
    {
        void Move(ICharacter character, IZone objectif);
        bool IsReachable(ICharacter character, IZone objectif);
       
    }
}
