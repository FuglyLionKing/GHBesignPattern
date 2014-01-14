#region ---------------- Pattern Fabrique Abstraite - C#.cs ----------------------

//     Namespaces      Console.Pattern.FabriqueAbstraite
//     Classes         Pattern Fabrique Abstraite - C#.cs 
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

namespace DesignPattern.FabriqueAbstraite
{
    internal abstract class FabriqueAbstraite
    {
        public abstract ProduitAbstraitA CreerProduitA();
        public abstract ProduitAbstraitB CreerProduitB();
    }

    internal class FabriqueConcrete1 : FabriqueAbstraite
    {
        public override ProduitAbstraitA CreerProduitA()
        {
            return new ProduitA1();
        }

        public override ProduitAbstraitB CreerProduitB()
        {
            return new ProduitB1();
        }
    }

    internal class FabriqueConcrete2 : FabriqueAbstraite
    {
        public override ProduitAbstraitA CreerProduitA()
        {
            return new ProduitA2();
        }

        public override ProduitAbstraitB CreerProduitB()
        {
            return new ProduitB2();
        }
    }

    internal abstract class ProduitAbstraitA
    {
    }

    internal abstract class ProduitAbstraitB
    {
        public abstract void Interagit(ProduitAbstraitA a);
    }

    internal class ProduitA1 : ProduitAbstraitA
    {
    }

    internal class ProduitB1 : ProduitAbstraitB
    {
        public override void Interagit(ProduitAbstraitA a)
        {
            Console.WriteLine(GetType().Name + " interagit avec " + a.GetType().Name);
        }
    }

    internal class ProduitA2 : ProduitAbstraitA
    {
    }

    internal class ProduitB2 : ProduitAbstraitB
    {
        public override void Interagit(ProduitAbstraitA a)
        {
            Console.WriteLine(GetType().Name + " interagit avec " + a.GetType().Name);
        }
    }


    internal class Client
    {
        private readonly ProduitAbstraitA produitAbstraitA;
        private readonly ProduitAbstraitB produitAbstraitB;

        public Client(FabriqueAbstraite factory)
        {
            produitAbstraitA = factory.CreerProduitA();
            produitAbstraitB = factory.CreerProduitB();
        }

        public void Run()
        {
            produitAbstraitB.Interagit(produitAbstraitA);
        }
    }
}