using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours4Exercice
{
    class Program
    {
        static Random Random = new Random();

        //################################################## Jeu Trouver le nombre ##################################################

        public static int[] DemanderIntervalle()
        {
            // Table Min Max 
            int[] MaxMin = new int[2];

            //Simple Variables could have used MaxMin[0] and [1]
            int Max;
            int Min;

            //Min Request
            do
            {
                Min = 0; // Reinitialise for loops
                Console.WriteLine("Entrez votre Minimum! :");
                while (int.TryParse(Console.ReadLine(), out Min) == false) { }

                //Too Low
                if (Min < 1)
                {
                    Console.WriteLine("Trop Bas");
                }

                //Too High
                if (Min > 10000)
                {
                    Console.WriteLine("Trop Haut");
                }

                //As long its Too High or Low will repeat
            } while (Min < 1 | Min > 10000);


            //Max Request
            do
            {
                Max = 0; // Reinitialise for loops
                Console.WriteLine($"Entrez votre Maximum il doit etre plus haut que {Min + 5}");
                while (int.TryParse(Console.ReadLine(), out Max) == false) { }

                //Too Low
                if (Max < Min)
                {
                    Console.WriteLine($"Vous etes plus bas que votre Minimum {Min} ...");
                }

                //Min of Max is +5 of Min
                if (Max >= Min + 5 & Max <= Min + 5)
                {
                    Console.WriteLine($"S il vous plait laissez un intervale d'au moins 5 entre votre Maximum et Minimum : {Min}....");
                }

                //Too High
                if (Max > 20000)
                {
                    Console.WriteLine("Abuse pas Esti.... plus de 20000 La La");
                }


                //As long its Too High /Low or too close to Min  will repeat
            } while (Min < 1 | Min > Max - 5 | Max > 20000);

            //Insert in table
            MaxMin[0] = Min;
            MaxMin[1] = Max;

            // Return the table for further use
            return MaxMin;
        }




        public static int DemanderNombreEssais(int[] MinMax)
        {
            int NombreTryMaxChoose = (MinMax[1] - MinMax[0]) / 2;
            if (NombreTryMaxChoose > 20)
                NombreTryMaxChoose = 20;

            int MaxTry;

            //Request the number of tries the user want
            Console.Write($"Nombre d'essais dont vous voulez disposer ? Maximum d'essais : {NombreTryMaxChoose}");
            do
            {

                //Make sure its an int
                while (int.TryParse(Console.ReadLine(), out MaxTry) == false)
                {
                    Console.WriteLine("Un nombre gros epais");
                }


                //Make sure user is not an idiot and actually gives himself a try
                if (MaxTry < 1)
                {
                    Console.WriteLine($"Serieux ? {MaxTry}.... retourne au primaire.");
                }

                //Gateway to verify b4 stopping the loop
            } while (MaxTry < 1 | MaxTry > NombreTryMaxChoose);


            // Return user MaxTry for further use
            return MaxTry;
        }




        // Create an int between Min and Max choosen by the user
        public static int GenererAleatoire(int[] intervalle)
        {
            int NumberToFind = Random.Next(intervalle[0], intervalle[1] + 1);
            return NumberToFind;
        }




        // Core of the game
        public static bool DemanderNombreADeviner(int MaxTry, int[] MinMax, int TheRandomNumber, out int TryAttempts)
        {
            TryAttempts = 0;        //Number Of Tries elapsed
            int Min = MinMax[0];    //Redefined for ease of use
            int Max = MinMax[1];
            bool Win = false;       //Win true or False
            do
            {
                //temp question value reinitialized on loop
                int x = 0;

                //Add a try
                TryAttempts++;

                //ask the user for the number to try
                Console.Write($"Essai #{TryAttempts} : ");
                while (int.TryParse(Console.ReadLine(), out x) == false)
                {


                    Console.WriteLine("Un nombre gros epais");
                }

                //Write a number > Max
                if (x > Max)
                {
                    Console.WriteLine("Ton nombre est trop grand!");
                    --TryAttempts; //remove attempt after invalid try
                }

                //Write a number < Min
                if (x < Min)
                {
                    Console.WriteLine("Ton nombre est trop petit!");
                    --TryAttempts; //remove attempt after invalid try
                }

                //Number entered > Number to Find
                if (x > TheRandomNumber)
                {
                    Console.WriteLine("Le nombre choisi est plus grand que le nombre recherché!");
                }

                //Number entered < Number to Find
                if (x < TheRandomNumber)
                {
                    Console.WriteLine("Le nombre choisi est plus petit que le nombre recherché!");
                }

                //Exhausted All Try Attempts // LOSE
                if (TryAttempts == MaxTry)
                {
                    return false;
                }


                //Win will be true if Number Entered is == Number To Find
                Win = (x == TheRandomNumber);
            }
            while (!Win); // While its not found LOOP
                          //When Found //WIN
            return Win;

        }

        //Win method using a bool
        public static void FeliciterOuPas(bool Win, int NumberToFind, int TryUsed)
        {
            if (Win == true)
                Console.WriteLine($"Gagne ! Cela ta pris {TryUsed} essais! #### ~~~ {NumberToFind} ~~~~ Bravo !");

            if (Win == false)
                Console.WriteLine($"Perdu ! Tu as utilise tout tes {TryUsed} essais !  #### Le Nombre Etait : ~~~ {NumberToFind} ~~~~");

        }


        //Game consolidated
        static void GameConsolidated()
        {
            int[] MinMax = DemanderIntervalle();
            int TryAttemptMax = DemanderNombreEssais(MinMax);
            int RandomNumber = GenererAleatoire(MinMax);
            bool WinLose = DemanderNombreADeviner(TryAttemptMax, MinMax, RandomNumber, out int TryUsed);
            FeliciterOuPas(WinLose, RandomNumber, TryUsed);
        }



        //#####################################################################################################################################


        //Exercice 42 // Add Premiers Number Square recusively

        // function complete using the Square function
        static int SquareNumberToUse()
        {
            int x;
            do
            {
                Console.WriteLine($"Quel Nombre Voulez Vous Utiliser ? :");
                while (int.TryParse(Console.ReadLine(), out x) == false)
                {
                    Console.WriteLine("Un nombre gros epais");
                }

            } while (x < 1);

            int Resultat = Square(x);

            return Resultat;
        }


        //Takes the 1,2 and premiers numbers and multiply them by themselves and add them to the next operation
        static int Square(int N)
        {
            if (N <= 1)         
                return N;

            if (N % 2 != 0 | N == 2) //if its not dividable by 2 or is 2 
                return N * N + Square(--N); // Calc and -1 to N

             // (N % 2 == 0)          //Everything that is divisible by 2
                return Square(--N);         // -1 to N No Calc

        }






        //Exercice 43 




        //Create a table of 10 int between -10 and 10
        static int[] RandomTableTen()
        {
            int[] TenValueTab = new int[10];
            for (int x = 0; x < 10; ++x)
            {
                TenValueTab[x] = Random.Next(-10, 11);
            }
            return TenValueTab;
        }




        //Static Variable to keep the tab of sum
        static int ST;


        //Take positive integers of the table and sum them recursively
        static int SommeTab(int[] TheTable)
        {
            //Create a Table to copy the changed initial one minus a value
            int[] TableCopy;

            //if table only have one integer left
            if (TheTable.Length <= 1)
            {
                ST += TheTable[0];
                return ST;
            }

            //if table still have more than one integer
            else
            {

                //Check if it is a positive integer
                if (TheTable[0] >= 0)
                {
                    ST += TheTable[0];

                    //Copy the table minus one 
                    TableCopy = CopyMinus1Length(TheTable);

                    //do the same operation without the 1st value of the last table
                    return SommeTab(TableCopy);
                }

                //Is a negative integer
                else
                {
                    //Copy the table minus one
                    TableCopy = CopyMinus1Length(TheTable);

                    //do the same operation ithout the 1st value of the last table
                    return SommeTab(TableCopy);
                }
            }
        }





        // Recusive operation of removing the table 1st block
        static int[] CopyMinus1Length(int[] TableToCopy)
        {
            //Create a new table with 1 less length
            int[] TableCopy = new int[TableToCopy.Length - 1];

            //copy the values to new table removing the 1st variable of table to copy
            for (int x = 0; x < TableCopy.Length; x++) 
            {

                // new table 0 = old table 0+1
                TableCopy[x] = TableToCopy[(x + 1)];
            }

            //Return table to operation with one less length // Removed the old [0] value
            return TableCopy;
        }




        // Exercice 44 a) Iterative

       //Used Int64 to get a bigger number Pool
        static void FiboIteratif()
        {
            Int64 MaxFibo = FiboIteratifMaxInt(); //Ask the Max number Fibo can be
            Int64 Fibo = 1;         //All integers start as 1
            Int64 FiboLast = 1;
            Int64 FiboRes = 1;
            do
            {

                Console.Write($"{Fibo},");
                Fibo = FiboRes;                // 1 > 2     // 3
                FiboRes = Fibo + FiboLast;      // 2 + 1    // 5
                FiboLast = Fibo;                // 1 > 2    // 5

            } while (Fibo < MaxFibo);
        }

        //Ask for highest number fibo can reach
        static Int64 FiboIteratifMaxInt()
        {
            Int64 x;
            do
            {
                Console.WriteLine("Quel est le nombre maximum que la suite de Fibonacci peut atteindre ?");
                while (Int64.TryParse(Console.ReadLine(), out x) == false)
                {
                    Console.WriteLine("Un nombre gros epais");
                }
            } while (x < 1);
            return x;
        }




        // Exercice 44 b) Recursive Fibonacci


        static Int64 FiboRecur(Int64 NombreFibo)
        {
            if (NombreFibo <= 2)
                return 1;           //if number is 2 or 1 will return 1

            else
                return FiboRecur(--NombreFibo) + FiboRecur((NombreFibo) - 2); // Add (Fibo -1) to (Fibo -2) Expotentially
        }


        //Question the number of time you want Fibonacci Recusive to run
        static Int64 FiboMaxTimesRecursuif()
        {
            Int64 x;
            do
            {
                Console.WriteLine("Combien de fois doit on faire Fibonacci recusivement?");
                while (Int64.TryParse(Console.ReadLine(), out x) == false)
                {
                    Console.WriteLine("Un nombre gros epais");
                }
            } while (x < 1);

            //Run The Function
            Int64 Resultat = FiboRecur(x);
            return Resultat;
        }



        //Clean Question Interface
        static int SwitchExercices()
        {
            int x;
            do
            {

                Console.WriteLine($"Quel Exercice voulez vous essayer ?   1 - Exercice 41 : Jeu Plus Ou Moins ");
                Console.WriteLine($"                                      2 - Exercice 42 : N Carre Premier Sum ");
                Console.WriteLine($"                                      3 - Exercice 43 : Sum Valeurs Positive en Tableau Recusif");
                Console.WriteLine($"                                      4 - Exercice 44 : a) Fibbonaci Iteratif");
                Console.WriteLine($"                                      5 - Exercice 44 : b) Fibbonaci Recursif");
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
                        GameConsolidated();
                        Console.WriteLine();
                    }
                    break;
                case 2:
                    {
                        int Result = SquareNumberToUse();
                        Console.WriteLine($"Resultat du Calcul : {Result}");
                        Console.WriteLine();
                    }
                    break;
                case 3:
                    {
                        ST = 0;
                        Console.WriteLine("Nouvelle Table de 10 Valeurs entre -10 et 10 :");
                        Console.WriteLine();

                        // Table Render
                        Console.Write("[");
                        int[] MinusTenPlusTenTenTableRand = RandomTableTen();
                        foreach (int i in MinusTenPlusTenTenTableRand)
                        {
                            Console.Write($"{i},");
                        }
                        Console.Write("]");

                        Console.WriteLine();
                        Console.WriteLine();

                        int SommeIntPosTab = SommeTab(MinusTenPlusTenTenTableRand);
                        Console.WriteLine($"Resultat : {SommeIntPosTab}");
                        Console.WriteLine();
                    }
                    break;
                case 4:
                    {
                        FiboIteratif();
                        Console.WriteLine();
                    }
                    break;
                case 5:
                    {

                        Int64 Resultat = FiboMaxTimesRecursuif();
                        Console.WriteLine(Resultat);
                    }
                    break;

            }
            Exercices();
        }

        static void Main(string[] args)
        {

            //Run Exercice Interface
            Exercices();
        }
    }
}

