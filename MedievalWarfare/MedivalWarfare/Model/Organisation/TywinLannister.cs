using GHBesignPattern.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHBesignPattern.Model.Organisation;

namespace MedievalWarfare.MedivalWarfare.Model
{
    class TywinLannister : StandardOrganisation
    {
        enum warStates {War,Peace};
        public Enum State;

        public TywinLannister()
        {
            this.State = warStates.War;
        }
    }
}
