using System;
using System.Runtime.InteropServices.ComTypes;

namespace GHBesignPattern.Model.Characters
{

    public delegate bool ObjectiveTester(ICharacter character); 

    public class Objectif 
    {
        public bool Done;
        public ObjectiveTester ObjectiveComplete ;
//        List<Objectif> Objectives;

        public Object target;

        public Objectif next;

        public Objectif(ObjectiveTester objo)
        {
            Done = null == objo ? true : false;
            ObjectiveComplete = objo;
        }
    }
}
