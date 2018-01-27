using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours2Exercice
{
    class Program
    {



        // Exercice 21 Write 5 time recursive Procedure
        public static void HelloNB(int Nb)
        {
            if (Nb <= 1)
            {
                Console.WriteLine("Hewwo!");
            }
            else
            {
                Console.WriteLine("Hewwo!");
                HelloNB(--Nb);
            }
        }



        // Exercice 22 write 5 times a message string in procedure
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
                    ProcedureMessage(--Nb, Message);
                }
            }
        }



        // Exercice 23 Power recursively
        public static int Puissancefunc(int Nbinit, int Pow)
        {

            {
                if (Pow <= 1)
                {
                    return Nbinit;
                }
                else
                {
                    return Nbinit * Puissancefunc(Nbinit, --Pow);
                }
            }
        }



        // Exercice 24 Recursively write a string
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
                    RecusiveStringOneByOne(MyString.Remove(0, 1));
                  
                }
            }
        }



        // Exercice 25 Bool Check if a Palindrome
        public static bool PalindromeRecursive(string MyString)
        {
            if (MyString[MyString.Count() - 1] == MyString[0])
            {
                if (MyString.Count() >= 1)
                {
                    return true;
                }
                else
                {

                    MyString.Remove(MyString[0]);
                    MyString.Remove(MyString[MyString.Count() - 1]);
                    return PalindromeRecursive(MyString);

                }
            }
            else
                return false;
        }

        public static void S()
        {
            Console.WriteLine();
        }

        //Clean Question Interface
        static int SwitchExercices()
        {
            int x;
            do
            {

                Console.WriteLine($"Quel Exercice voulez vous essayer ?   1 - Exercice 21 : Recursive Hello ");
                Console.WriteLine($"                                      2 - Exercice 22 : Recursive string message ");
                Console.WriteLine($"                                      3 - Exercice 23 : Puissance Recursive");
                Console.WriteLine($"                                      4 - Exercice 24 : Decomposer une string recursivement por la reecrire");
                Console.WriteLine($"                                      5 - Exercice 25 : Palindrome Check");
                while (int.TryParse(Console.ReadLine(), out x) == false)
                {
                    Console.WriteLine("Un nombre gros epais");
                }
            } while (x < 1 | x > 5);
            return x;
        }


        //Clean Switch to choose Exercice
        static void Exercices()
        {
            int Choix = SwitchExercices();
            Console.Clear();
            switch (Choix)
            {
                case 1:
                    {
                        // Exercice 21
                        HelloNB(5);
                        S();
                        S();
                    }
                    break;
                case 2:
                    {
                        // Exercice 22
                        string Message = "Yay i love potatoes!";
                        ProcedureMessage(5, Message);
                        S();
                        S();

                    }
                    break;
                case 3:
                    {

                        // Exercice 23
                        int Resultat = Puissancefunc(2, 7);
                        Console.WriteLine(Resultat);
                        S();
                        S();

                    }
                    break;
                case 4:
                    {
                        // Exercice 24
                        string StringToDecomp = "J'aime les Patates";
                        RecusiveStringOneByOne(StringToDecomp);
                        S();
                        S();
                    }
                    break;
                case 5:
                    {

                        //Exercice 25
                        string PalindromeToCheck = "ommo";

                        bool PalincCHK = PalindromeRecursive(PalindromeToCheck);

                        // aurait pu le mettre direct dans ma fonction et retourner un string
                        string OuiOuNon;

                        if (PalincCHK == true)
                        { OuiOuNon = "Oui"; }
                        else
                        { OuiOuNon = "Non"; }

                        Console.WriteLine($"le string {PalindromeToCheck} est il un palindrome ? {OuiOuNon}");

                        Console.WriteLine(PalincCHK); // Simple Bool Result
                    }
                    break;

            }
            Exercices();
        }

        static void Main(string[] args)
        {
            Exercices();
        }
    }
}
