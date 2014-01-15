namespace GHBesignPattern.Model.Characters
{
    internal interface IObservee
    {
        void Update();
        void Attach(IObservor obs);
        void Detach(IObservor obs);
    }
}