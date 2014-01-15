namespace GHBesignPattern.Model.Items
{
    interface IItem
    {
        bool Pickable { get; }
        bool Usable { get; }
        string Name { get; }
        //TODO pick(LivingThing) method ?
    }
}
