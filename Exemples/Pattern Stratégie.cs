#region ---------------- Pattern Stratégie - C# .cs ----------------------

//     Namespaces      Console.Pattern.Strategie
//     Classes         Pattern Stratégie - C# .cs 
//  
//     Date            2013 12 02
//     Modif           2013 12 05
//                      
//     Auteur          Vincent LE CERF 
//     Copyright       METAGENIA, 1999 - 2013
//     URL             http://www.metagenia.net
//     Email           codesource@metagenia.net
// 
// -----------------------------------------------------

#endregion

using System;

namespace DesignPattern.Strategie
{
    internal abstract class StrategieAbstraite
    {
        public abstract void Operation();
    }

    internal class StrategieConcreteA : StrategieAbstraite
    {
        public override void Operation()
        {
            Console.WriteLine("Appel StrategieConcreteA.Operation()");
        }
    }

    internal class StrategieConcreteB : StrategieAbstraite
    {
        public override void Operation()
        {
            Console.WriteLine("Appel StrategieConcreteB.Operation()");
        }
    }

    internal class StrategieConcreteC : StrategieAbstraite
    {
        public override void Operation()
        {
            Console.WriteLine("Appel StrategieConcreteC.Operation()");
        }
    }

    internal class Contexte
    {
        private StrategieAbstraite stategieCourante;

        public Contexte(StrategieAbstraite uneStrategie)
        {
            stategieCourante = uneStrategie;
        }


        internal void ModifieStrategie(StrategieAbstraite uneStrategie)
        {
            stategieCourante = uneStrategie;
        }

        internal void Execute()
        {
            stategieCourante.Operation();
        }
    }
}