using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cours1Exercice
{
    public class Values
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int Moyennne { get; set; }
        public int Medianne { get; set; }
        public int Total { get; set; }

    }
    class Program
    {
        public static Random R = new Random();
        public static double Convertir(double Taux, double Montant, bool inverse)
        {
            double Converted = 0;
            if (inverse == true)
            {
                Converted = (Montant * Taux); //1/Taux
                return Converted;
            }
            if (inverse == false)
            {
                Converted = (Taux * Montant);
                return Converted;
            }

            return Converted;
        }

        public static void Afficher10EntiersMinMazMoyMedSum(int[] MyTable)
        {
            int Total = 0;
            int Minimum = 0;
            int Maximum = 0;
            int Median = 0;
            int[] TempArray = MyTable;
            int TempCount = TempArray.Length;
            if (TempCount % 2 == 0)// even
            {
                int Middle = TempArray[(TempCount / 2) - 1];


                int Middle2 = TempArray[(TempCount / 2)];


                Median = (Middle + Middle2) / 2;
            }
            else if (TempCount % 2 != 0) // odd
            {
                int Middle2 = TempArray[(TempCount / 2)];
            }


            foreach (int i in MyTable)
            {
                Total += i;

            }
            int Moyenne = Total / MyTable.Max();




            for (int i1 = 0; i1 < MyTable.Length; ++i1)
            {

                for (int i2 = 0; i2 < MyTable.Length; ++i2)
                {

                    if (MyTable[i2] > MyTable[i1])
                    {
                        Maximum = MyTable[i2];
                    }
                }
            }

            Minimum = MyTable.Min();

            Console.WriteLine($"Mediane = {Median}");
            Console.WriteLine($"Moyenne = {Moyenne}");
            Console.WriteLine($"Minimum = {Minimum}");
            Console.WriteLine($"Maximum = {Maximum}");
            Console.WriteLine($"Total = {Total}");
        }

        public static List<Values> RetourneValeurs10int(int[] MyTable)
        {
            int Total = 0;
            int Minimum = 0;
            int Maximum = 0;
            int Median = 0;
            int[] TempArray = MyTable;
            int TempCount = TempArray.Length;
            if (TempCount % 2 == 0)// even
            {
                int Middle = TempArray[(TempCount / 2) - 1];


                int Middle2 = TempArray[(TempCount / 2)];


                Median = (Middle + Middle2) / 2;
            }
            else if (TempCount % 2 != 0) // odd
            {
                int Middle2 = TempArray[(TempCount / 2)];
            }


            foreach (int i in MyTable)
            {
                Total += i;

            }
            int Moyenne = Total / MyTable.Max();




            for (int i1 = 0; i1 < MyTable.Length; ++i1)
            {

                for (int i2 = 0; i2 < MyTable.Length; ++i2)
                {

                    if (MyTable[i2] > MyTable[i1])
                    {
                        Maximum = MyTable[i2];
                    }
                }
            }

            Minimum = MyTable.Min();

            Console.WriteLine($"Mediane = {Median}");
            Console.WriteLine($"Moyenne = {Moyenne}");
            Console.WriteLine($"Minimum = {Minimum}");
            Console.WriteLine($"Maximum = {Maximum}");
            Console.WriteLine($"Total = {Total}");
            List<Values> MaxMinTotalMoyMed = new List<Values>();

            MaxMinTotalMoyMed.Add(new Values() { Medianne = Median, Moyennne = Moyenne, Max = Maximum, Min = Minimum, Total = Total });

            return MaxMinTotalMoyMed;

        }

        public static int[] CreateTableMinMax(int min, int max)
        {

            int[] TempTable = new int[max - min];
            for (int i = 0; i < TempTable.Length; i++)
            {
                TempTable[i] = i + min;
            }

            for (int i = 0; i < TempTable.Length; ++i)
            {
                int j = R.Next() % TempTable.Length;
                int TempV = TempTable[i];
                TempTable[i] = TempTable[j];
                TempTable[j] = TempV;

            }
            return TempTable;
        }

        public static void SortedTableProcedure(int[] TheTable)
        {
            int Temp;
            for (int p = 0; p <= TheTable.Length - 2; p++)
            {
                for (int i = 0; i <= TheTable.Length - 2; i++)
                {
                    if (TheTable[i] > TheTable[i + 1])
                    {
                        Temp = TheTable[i + 1];
                        TheTable[i + 1] = TheTable[i];
                        TheTable[i] = Temp;
                    }
                }
            }
            foreach (int x in TheTable)
            {
                Console.Write($"{x},");
            }
        }

        public static int fonctionnombresame(string Same, string[] MyStringTable)
        {
            int SameString = 0;
            foreach (string c in MyStringTable)
            {
                if (c == Same)
                {
                    SameString += 1;
                }
            }
            return SameString;
        }
        public static string[] Extensions()
        {
            string[] FilesNames = new string[] { "i.txt", "i.img", "i.cs" };
            string[] FilesExtentions = new string[FilesNames.Length];
            int x = 0;
            foreach (string i in FilesNames)
            {
                FilesExtentions[x] += Path.GetExtension(i);
                ++x;
            }
            return FilesExtentions;
        }

        static double PhotocopieCalcPrix(int nb)
        {
            double Prix = 0;
            for (int x = 1; x <= nb; x++)
            {
                if (x <= 10)
                {
                    Prix += 0.10;
                }

                else if (x > 10 & nb <= 30)
                {
                    Prix += 0.08;
                }

                else if (nb > 30)
                {
                    Prix += 0.07;
                }

            }
            return Prix;
        }

        public static void CinemaTarif(int Age, bool EtudApp, int Type2D3D)
        {
            double PrixSession = 0;

            int TempAwnser = 0;
            bool Matin = false;

            Console.WriteLine("Quelle taille de salle voulez-vous?  1- Grande");
            Console.WriteLine("                                     2- Petite");
            while (int.TryParse(Console.ReadLine(), out TempAwnser) == false)
            {

                if (TempAwnser < 1 | TempAwnser > 2)
                {
                    Console.WriteLine("Quelle taille de salle voulez-vous?  1- Grande");
                    Console.WriteLine("                                     2- Petite");
                }
            };
            if (TempAwnser == 1)
            {
                PrixSession = 10.60;
            }
            else
            {
                PrixSession = 9.60;
            }

            TempAwnser = 0;
            Console.WriteLine("Quelle Presentation voulez-Vous?     1- Matin");
            Console.WriteLine("                                     2- Soir");
            while (int.TryParse(Console.ReadLine(), out TempAwnser) == false)
            {

                if (TempAwnser < 1 | TempAwnser > 2)
                {
                    Console.WriteLine("Quelle Presentation voulez-Vous?     1- Matin");
                    Console.WriteLine("                                     2- Soir");
                }
            };
            if(TempAwnser == 1)
            {
                PrixSession = 6;
                Matin = true;
            }

            if(Matin==false)
            {
                TempAwnser = 0;
                Console.WriteLine("Quel age avez vous ?");
                while (int.TryParse(Console.ReadLine(), out TempAwnser) == false)
                {
                    if (TempAwnser < 1 | TempAwnser > 110)
                    {
                        Console.WriteLine("Quel age avez vous ?");
                    }
                }
                {
                    if (TempAwnser < 18)
                    {
                        PrixSession = 6.90;
                    }
                    else
                    {
                        //nochange
                    }
                    // question etudiant
                    // question 2d 3d
                }
                
            }
        }


        static void Main(string[] args)
        {
            double CADtoUSD = Convertir(1, 0.6, true);
            Console.WriteLine(CADtoUSD);

            // ex 2
            int[] MyIntTable = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Afficher10EntiersMinMazMoyMedSum(MyIntTable);
            // ex 2.5
            List<Values> My10Processsed = new List<Values>();
            My10Processsed = RetourneValeurs10int(MyIntTable);

            //ex3
            int[] TableMixed = CreateTableMinMax(12, 55);
            foreach (int i in TableMixed)
            {
                Console.Write($"{i},");
            }

            //ex4
            Console.WriteLine();
            SortedTableProcedure(TableMixed);

            //ex4.5
            string[] MyStringTable = new string[] { "a", "b", "c", "a", "a" };
            string a = "a";

            Console.WriteLine();
            int SameString = fonctionnombresame(a, MyStringTable);
            Console.WriteLine($"il y {SameString} de {a} dans la table");

            //ex5 
            string[] FileExten = Extensions();
            foreach (string i in FileExten)
            {
                Console.Write($"{i},");
            }

            //ex6
            Console.WriteLine();
            double PrixPhotocopie = PhotocopieCalcPrix(20);
            Console.WriteLine($"Prix des PhotoCopies = {PrixPhotocopie}$");
        }
    }
}
