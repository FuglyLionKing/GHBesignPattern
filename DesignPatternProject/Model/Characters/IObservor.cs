namespace GHBesignPattern.Model.Characters
{
    public interface IObservor
    {
        IObservee Subject {get; set;}
        void Update();


    }
}
