using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHBesignPattern.Model.Items;

namespace MedievalWarfare.MedivalWarfare.Model.items
{
    class Apple : IItem
    {
        public Apple()
        {
            _name = "Apple";
        }

        private string _name;

        public string Name
        {
            get { return _name; }
        }
    }
}
