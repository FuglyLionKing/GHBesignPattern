using System;
using GHBesignPattern.Model.Boards;

namespace GHBesignPattern.Model.Characters
{
    interface IMovingBehavior<T> where T : struct, IConvertible, IComparable, IFormattable
    {
        void Move(ICharacter<T> character, IZone<T> objectif);
        bool IsReachable(ICharacter<T> character, IZone<T> objectif);
       
    }
}
