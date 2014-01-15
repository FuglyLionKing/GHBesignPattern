namespace GHBesignPattern.Model.Items
{
    public interface IItem
    {
        bool Pickable { get; }
        bool Usable { get; }
        string Name { get; }
 
    }
}
