#region ---------------- Pattern Singleton - C#.cs ----------------------

//     Namespaces      Console.Pattern.Singleton
//     Classes         Pattern Singleton - C#.cs 
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

namespace DesignPattern.Singleton
{
    internal class Singleton
    {
        private static Singleton instance;

        protected Singleton()
        {
        }

        public static Singleton Instance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }

            return instance;
        }
    }
}