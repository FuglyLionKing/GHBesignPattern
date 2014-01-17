using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHBesignPattern.Model.Characters;

namespace MedievalWarfare.Model.Characters 
{
    class Knight : ICharacter<TEnumType> where TEnumType : struct, IConvertible, IComparable, IFormattable
    {
        public Knight()
        {
            
        }
    }
}
