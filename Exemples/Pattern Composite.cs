#region ---------------- Pattern Composite - C#.cs ----------------------

//     Namespaces      Console.Pattern.Composite
//     Classes         Pattern Composite - C#.cs 
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

namespace DesignPattern.Composite
{
    internal abstract class ComposantAbstrait
    {
        protected string nom;

        public ComposantAbstrait(string unNom)
        {
            nom = unNom;
        }

        public abstract void Add(ComposantAbstrait c);
        public abstract void Remove(ComposantAbstrait c);
        public abstract void AffichageRecursif(int profondeur);
    }


    internal class Composite : ComposantAbstrait
    {
        private readonly List<ComposantAbstrait> enfants = new List<ComposantAbstrait>();

        public Composite(string name)
            : base(name)
        {
        }

        public override void Add(ComposantAbstrait component)
        {
            enfants.Add(component);
        }

        public override void Remove(ComposantAbstrait component)
        {
            enfants.Remove(component);
        }

        public override void AffichageRecursif(int profondeur)
        {
            Console.WriteLine(new String('-', profondeur) + nom);

            // Recursively display child nodes
            foreach (ComposantAbstrait component in enfants)
            {
                component.AffichageRecursif(profondeur + 2);
            }
        }
    }


    internal class Feuille : ComposantAbstrait
    {
        public Feuille(string name)
            : base(name)
        {
        }

        public override void Add(ComposantAbstrait c)
        {
            Console.WriteLine("Impossible d'ajouter à une feuille");
        }

        public override void Remove(ComposantAbstrait c)
        {
            Console.WriteLine("Impossible de retirer à une feuille");
        }

        public override void AffichageRecursif(int profondeur)
        {
            Console.WriteLine(new String('-', profondeur) + nom);
        }
    }
}