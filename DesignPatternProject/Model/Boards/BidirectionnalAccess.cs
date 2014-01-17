using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHBesignPattern.Model.Boards
{
    class BidirectionnalAccess : IAccess
    {
        public IZone From { get; set; }

        public IZone Target { get; set; }

        public AccessRestriction AccessRestricted { get; set; }

        public BidirectionnalAccess(IZone From, IZone Target)
        {
            this.From = From;
            this.Target = Target;
        }
    }
}
