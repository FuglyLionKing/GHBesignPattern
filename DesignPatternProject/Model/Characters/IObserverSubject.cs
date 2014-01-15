using SimulationV1.Model.Characters;

namespace GHBesignPattern.Model.Characters
{
    interface IObserverSubject
    {
        void Update();
        void Attach(IObservor obs);
        void Detach(IObservor obs);
    }
}
