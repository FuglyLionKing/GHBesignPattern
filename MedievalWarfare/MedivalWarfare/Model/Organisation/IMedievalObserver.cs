using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHBesignPattern.Model.Characters;

namespace MedievalWarfare.MedivalWarfare.Model.Organisation
{
    public interface IMedievalObserver : IObserver
    {
        new TywinLannister Subject {get; set;}
    }
}
