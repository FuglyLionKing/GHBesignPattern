namespace GHBesignPattern.Model.Characters
{
    public interface IObserver
    {
        IObservee Subject {get; set;}
        void Update();


    }
}
