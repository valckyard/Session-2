using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours2Exercice
{
    class Program
    {

        // Exercice 21
        public static void HelloNB(int Nb)
        {
            if (Nb <= 1)
            {
                Console.WriteLine("Hewwo!");
            }
            else
            {
                Console.WriteLine("Hewwo!");
                --Nb;
                HelloNB(Nb);
            }
        }

        // Exercice 22
        public static void ProcedureMessage(int Nb, string Message)
        {
            {
                if (Nb <= 1)
                {
                    Console.WriteLine(Message);
                }
                else
                {
                    Console.WriteLine(Message);
                    --Nb;
                    ProcedureMessage(Nb, Message);
                }
            }
        }

        // Exercice 23
        public static int Puissancefunc(int Nbinit, int Pow)
        {

            {
                if (Pow <= 1)
                {
                    return Nbinit;
                }
                else
                {
                    --Pow;
                    return Nbinit * Puissancefunc(Nbinit, Pow);
                }
            }
        }
        //Ex24*: Réaliser une procédure récursive qui, à partir d’une chaine de caractère, va afficher dans la
        //console chaque caractère de la chaine.
        //Indice : vous aurez besoin de la méthode Substring des chaines de caractères :
        //aaaaabbbcccccccdd.Substring(5, 3) = bbb

        // Exercice 24 Methode 1
        public static void RecusiveStringOneByOne(string MyString)
        {
          
            {
                if (MyString.Count() <= 1)
                {
                    Console.Write(MyString[0]);
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(MyString.Substring(0, 1));
                    RecusiveStringOneByOne(MyString.Remove(MyString[0]));
                  
                }
            }
        }
        static void Main(string[] args)
        {
            // Exercice 21
            HelloNB(5);

            // Exercice 22
            string Message = "Yay i love potatoes!";
            ProcedureMessage(5, Message);

            // Exercice 23
            int Resultat = Puissancefunc(2, 7);
            Console.WriteLine(Resultat);

            // Exercice 24
            string StringToDecomp = "J'aime les Patates";
            RecusiveStringOneByOne(StringToDecomp);
        }
    }
}
