using MedievalWarfare.MedivalWarfare.Model.Organisation;

namespace GHBesignPattern.Model.Characters
{
    public interface IObserver
    {
        TywinLannister Subject {get; set;}
        void Update();


    }
}
