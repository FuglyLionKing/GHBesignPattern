using System.Collections.Generic;
namespace GHBesignPattern.Model.Characters
{
    public interface IObservee
    {
        void Update();
        void Attach(IObserver obs);
        void Detach(IObserver obs);
    }
}