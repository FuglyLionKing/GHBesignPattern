namespace GHBesignPattern.Model.Characters
{
    public interface IObservee
    {
        void Update();
        void Attach(IObservor obs);
        void Detach(IObservor obs);
    }
}