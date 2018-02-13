using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Cours7Exercice
{
    class Program
    {



        //############################################ DYNAMIC SORT #############################################################//
        //############################################ DYNAMIC SORT #############################################################//
        //############################################ DYNAMIC SORT #############################################################//




        // Exercice 71 sort a dynamic list of int or double
        private static List<T> SortMyList<T>(List<T> theList1)
        {

            if ((theList1.GetType() == typeof(List<int>)) | (theList1.GetType() == typeof(List<double>)))
            {

              //  dynamic count = theList1.Count();
                bool trie = false;

                while (!trie)
                {
                    trie = true;
                    for (dynamic i = theList1.Count - 1; i > 0; i--)
                    {
                        for (dynamic j = 0; j <= i - 1; j++)
                        {
                            if (theList1[j] > theList1[j + 1])
                            {
                                dynamic highValue = theList1[j];
                                theList1[j] = theList1[j + 1];

                                theList1[j + 1] = highValue;
                                trie = false;
                            }
                        }
                    }
                }
                return theList1;
            }

            Console.WriteLine("FU c est pas un int ou un double");
            return theList1;
        }




        //init dynamuc 
        private static void InitializeDyna()
        {
            Console.WriteLine("Sortie double trie :");
            List<double> test1 = new List<double> { 1.2222, 2.11111, 54.1, 3.6, 6.2, 3.2, 1.111, 3.2 };
            List<double> sortieTest1 = SortMyList(test1);
            foreach (var d in sortieTest1)
            {
                Console.Write($"{d},");
            }
            S();
            S();
            Console.WriteLine("Sortie Int trie :");
            List<int> test2 = new List<int> { 55, 2, 12, 111, 2234, 11, 1, 23, 77, 23, 19, 7, 2, 1222 };
            List<int> sortieTest2 = SortMyList(test2);
            foreach (var i in sortieTest2)
            {
                Console.Write($"{i},");
            }
            S();
        }




        //Exercice 72
        //Create name List
        private static List<string> ListNomsLongue()
        {
            string oneLine;
            List<string> noms = new List<string>();
            StreamReader sanchoBobReadsText = new StreamReader("names.txt"); //32868 names that 5 or more baby had been given in USA in 2016
            while ((oneLine = sanchoBobReadsText.ReadLine()) != null)
            {
                string[] splittedLine = oneLine.Split(',');             //splitting at , i dont want the rest
                noms.Add(splittedLine[0]);
            }
            return noms;
        }




        //############################################ NAME FILTER #############################################################//
        //############################################ NAME FILTER #############################################################//
        //############################################ NAME FILTER #############################################################//




        //name Filter
        private static List<string> FiltrerNoms(List<string> noms)
        {
            List<string> copynoms = noms;
            foreach (string s in copynoms.ToList())
            {
                if (s.Count() < 8)
                {
                    copynoms.Remove(s);
                }

            }
            return copynoms;
        }



        //Init name filters
        private static void InitializeFiltrerNoms()
        {
            List<string> noms = ListNomsLongue();
            List<string> nomsfiltre = FiltrerNoms(noms);
            foreach (var s in nomsfiltre)
            {
                Console.WriteLine(s);
            }
        }




        //############################################ Exercise Switch #############################################################//
        //############################################ Exercise Switch #############################################################//
        //############################################ Exercise Switch #############################################################//



        private static void Switch()
        {
            Console.WriteLine("1 - Dynamic list of int and double");
            Console.WriteLine("2 - Name Filtered");
            Console.WriteLine("Choice : ");
            int x;
            while (int.TryParse(Console.ReadLine(), out x) == false)
            {
                if (x < 1 | x > 2)
                {
                    Switch();
                }
                Console.Clear();
            }



            switch (x)
            {
                case 1:
                    {
                        InitializeDyna();
                        S();
                        S();
                    }
                    break;
                case 2:
                    {
                        InitializeFiltrerNoms();
                        S();
                        S();
                    }
                    break;
            }
            Switch();
        }



        private static void S()
        {
            Console.WriteLine();
        }



        static void Main()
        {
            Switch();

        }
    }
}
