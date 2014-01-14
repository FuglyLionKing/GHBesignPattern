#region ---------------- Pattern Observer - C#.cs ----------------------

//     Namespaces      Console.Pattern.Observateur
//     Classes         Pattern Observer - C#.cs 
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
using System.Collections.Generic;

namespace DesignPattern.Observateur
{
    internal abstract class SujetAbstrait
    {
        private readonly List<ObservateurAbstrait> observateurList = new List<ObservateurAbstrait>();

        public void Attach(ObservateurAbstrait observer)
        {
            observateurList.Add(observer);
        }

        public void Detach(ObservateurAbstrait observer)
        {
            observateurList.Remove(observer);
        }

        public void Notify()
        {
            foreach (ObservateurAbstrait o in observateurList)
            {
                o.Update();
            }
        }
    }

    internal class SujetConcret : SujetAbstrait
    {
        public string SubjectState { get; set; }
    }

    internal abstract class ObservateurAbstrait
    {
        public abstract void Update();
    }

    internal class ObservateurConcret : ObservateurAbstrait
    {
        private readonly string nom;
        private string etatObservé;

        public ObservateurConcret(SujetConcret subject, string name)
        {
            Subjet = subject;
            nom = name;
        }

        public SujetConcret Subjet { get; set; }

        public override void Update()
        {
            etatObservé = Subjet.SubjectState;
            Console.WriteLine("Observer {0} : new state is {1}", nom, etatObservé);
        }
    }
}