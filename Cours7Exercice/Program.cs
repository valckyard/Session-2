using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cours7Exercice
{
    class Program
    {

        // Exercice 71 sort a dynamic list of int or double
        private static List<T> SortMyList<T>(List<T> TheList1)
        {

            if ((TheList1.GetType() == typeof(List<int>)) | (TheList1.GetType() == typeof(List<double>)))
            {

                dynamic count = TheList1.Count();
                bool trie = false;

                while (!trie)
                {
                    trie = true;
                    for (dynamic i = TheList1.Count - 1; i > 0; i--)
                    {
                        for (dynamic j = 0; j <= i - 1; j++)
                        {
                            if (TheList1[j] > TheList1[j + 1])
                            {
                                dynamic highValue = TheList1[j];
                                TheList1[j] = TheList1[j + 1];

                                TheList1[j + 1] = highValue;
                                trie = false;
                            }
                        }
                    }
                }
                return TheList1;
            }
            else
            {
                Console.WriteLine("FU c est pas un int ou un double");
                return TheList1;
            }
        }

        private static void InitializeDyna()
        {
            Console.WriteLine("Sortie double trie :");
            List<double> test1 = new List<double> { 1.2222, 2.11111, 54.1, 3.6, 6.2, 3.2, 1.111, 3.2 };
            List<double> SortieTest1 = SortMyList(test1);
            foreach (var d in SortieTest1)
            {
                Console.Write($"{d},");
            }
            s();
            s();
            Console.WriteLine("Sortie Int trie :");
            List<int> test2 = new List<int> { 55, 2, 12, 111, 2234, 11, 1, 23, 77, 23, 19, 7, 2, 1222 };
            List<int> SortieTest2 = SortMyList(test2);
            foreach (var i in SortieTest2)
            {
                Console.Write($"{i},");
            }
            s();
        }

        //Exercice 72
        private static List<string> ListNomsLongue()
        {
            string OneLine;
            List<string> Noms = new List<string>();
            StreamReader SanchoBobReadsText = new StreamReader("names.txt"); //32868 names that 5 or more baby had been given in USA in 2016
            while ((OneLine = SanchoBobReadsText.ReadLine()) != null)
            {
                string[] SplittedLine = OneLine.Split(',');             //splitting at , i dont want the rest
                Noms.Add(SplittedLine[0]);
            }
            return Noms;
        }

        private static List<string> FiltrerNoms(List<string> Noms)
        {
            List<string> Copynoms = Noms;
            foreach (string s in Copynoms.ToList())
            {
                if (s.Count() < 8)
                {
                    Copynoms.Remove(s);
                }

            }
            return Copynoms;
        }

        private static void InitializeFiltrerNoms()
        {
            List<string> noms = ListNomsLongue();
            List<string> nomsfiltre = FiltrerNoms(noms);
            foreach (var s in nomsfiltre)
            {
                Console.WriteLine(s);
            }
        }

        private static void SwitchExercices()
        {
            Console.WriteLine("1 - Dynamic list of int and double");
            Console.WriteLine("2 - Name Filtered");
            Console.WriteLine("Choice : ");
            int x;
            while (int.TryParse(Console.ReadLine(), out x) == false)
            {
                if (x < 1 | x > 2)
                {
                    SwitchExercices();
                }
                Console.Clear();
            }



            switch (x)
            {
                case 1:
                    {
                        InitializeDyna();
                        s();
                        s();
                    }
                    break;
                case 2:
                    {
                        InitializeFiltrerNoms();
                        s();
                        s();
                    }
                    break;
            }
            SwitchExercices();
        }

        private static void s()
        {
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            SwitchExercices();

        }
    }
}
