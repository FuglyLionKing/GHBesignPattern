namespace GHBesignPattern.Model.Characters
{
    interface IObservor
    {
        IObservee Subject {get; set;}
        void Update();


    }
}
