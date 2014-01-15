namespace GHBesignPattern.Model.Characters
{
    interface IObservor
    {
        IObserverSubject Subject {get; set;}
        void Update();


    }
}
