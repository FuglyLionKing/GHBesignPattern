using System;
using System.Runtime.InteropServices.ComTypes;

namespace GHBesignPattern.Model.Characters
{

    public delegate bool ObjectiveTester<T>(ICharacter<T> character) where T : struct , IConvertible, IComparable, IFormattable;

    public class Objectif<T> where T : struct , IConvertible, IComparable, IFormattable
    {
        public bool Done;
        public ObjectiveTester<T> ObjectiveComplete ;
//        List<Objectif> Objectives;

        public Objectif(ObjectiveTester<T> objo)
        {
            Done = null == objo ? true : false;
            ObjectiveComplete = objo;
        }
    }
}
