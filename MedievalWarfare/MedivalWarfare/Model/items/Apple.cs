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

        protected bool Equals(Apple other)
        {
            return string.Equals(_name, other._name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Apple) obj);
        }

        public override int GetHashCode()
        {
            return (_name != null ? _name.GetHashCode() : 0);
        }
    }
}
