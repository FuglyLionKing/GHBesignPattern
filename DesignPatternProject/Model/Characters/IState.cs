namespace GHBesignPattern.Model.Characters
{
    abstract class State
    {
        public int Ordinal { get; set;}
        public string Value { get; set; } 

        public static bool operator ==(State local, State external)
        {
            if (local == null) return external == null;

            return ((local == external) || (external != null && (local.GetType() == external.GetType()) && local.Ordinal ==external.Ordinal));
        }

        public static bool operator !=(State local, State external)
        {
            return !(local == external);
        }


    }
}
