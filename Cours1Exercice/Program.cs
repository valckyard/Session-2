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
        public double Min { get; set; }
        public double Max { get; set; }
        public double Moyennne { get; set; }
        public double Medianne { get; set; }
        public double Total { get; set; }

    }
    class Program
    {
        public static Random random = new Random(); //Reutilisable Random

        public static double NextDouble(double minimum, double maximum)
        {

            return random.NextDouble() * (maximum - minimum) + minimum;

        }

        //Exercice 11   Taux et Taux en Reverse
        public static double Convertir(double Taux, double Montant, bool inverse)
        {
            double Converted = 0;
            if (inverse == true)
            {
                Converted = (Montant * Taux);
                return Converted;
            }
            if (inverse == false)
            {
                Converted = (Taux * Montant);
                return Converted;
            }
            return Converted;
        }

        //Exercice 12    Table Moyenne Mediane Min Max Total Procedure
        public static void RenderValueMoyMedSumMinMax(int[] MyTable)
        {
            int Total = 0;
            int Minimum = 0;
            int Maximum = 0;
            int Median = 0;

            //Median
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

                Median = Middle2;
            }

            //Total
            foreach (int i in MyTable)
            {
                Total += i;

            }

            //Moyenne
            int Moyenne = Total / MyTable.Max();

            //Maximum
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

            //Minimum
            Minimum = MyTable.Min();

            //Render
            Console.WriteLine($"Mediane = {Median}");
            Console.WriteLine($"Moyenne = {Moyenne}");
            Console.WriteLine($"Minimum = {Minimum}");
            Console.WriteLine($"Maximum = {Maximum}");
            Console.WriteLine($"Total = {Total}");
        }

        // Exercice 13 Creation de table de notes doubles
        public static List<double> DoubleTableMinMax(double min, double max)
        {
            List<double> TempTable = new List<double>(); 
            for (int i = 0; i < 31; i++) // assuming there is 31 student
            {
               TempTable.Add(NextDouble(min, max));
            }
            TempTable.Sort();
            return TempTable;
        }

        // Exercice 13  Table Moyenne Mediane Min Max Total dans une Liste Fonction
        public static List<Values> DoubleNotesAnalyserMinMaxMedSumMoy(List<double> MyTable)
        {
            double Total = 0;
            double Minimum = 0;
            double Maximum = 0;
            double Median = 0;

            //Median
            int TempCount = MyTable.Count ;


            if (TempCount % 2 == 0)// even
            {
                double Middle = MyTable[(TempCount / 2) - 1];


                double Middle2 = MyTable[(TempCount / 2)];


                Median = (Middle + Middle2) / 2;
            }
            else if (TempCount % 2 != 0) // odd
            {
                double Middle2 = MyTable[(TempCount / 2)];

                Median = Middle2;
            }

            //Total
            foreach (double i in MyTable)
            {
                Total += i;

            }

            //Moyenne
            double Moyenne = Total / MyTable.Max();

            //Maximum
            for (int i1 = 0; i1 < MyTable.Count; ++i1)
            {

                for (int i2 = 0; i2 < MyTable.Count; ++i2)
                {

                    if (MyTable[i2] > MyTable[i1])
                    {
                        Maximum = MyTable[i2];
                    }
                }
            }

            //Minimum
            Minimum = MyTable.Min();

            List<Values> MaxMinTotalMoyMed = new List<Values>();

            MaxMinTotalMoyMed.Add(new Values() { Medianne = Median, Moyennne = Moyenne, Max = Maximum, Min = Minimum, Total = Total });

            return MaxMinTotalMoyMed;

        }

        //Render List Value Exercise 2.5 Procedure
        public static void RenderListValues(List<Values> MyList)
        {
            foreach (Values i in MyList)
            {
                Console.WriteLine($"Mediane = {i.Medianne}");
                Console.WriteLine($"Moyenne = {i.Moyennne}");
                Console.WriteLine($"Minimum = {i.Min}");
                Console.WriteLine($"Maximum = {i.Max}");
                Console.WriteLine($"Total = {i.Total}");
            }
        }

        // Exercice 3   Creer table avec un Min Max en Fonction
        public static int[] intTableMinMax(int min, int max)
        {

            //int[] TempTable = new int[max - min]; // table from to 
            int[] TempTable = new int[10];
            for (int i = 0; i < TempTable.Length; i++)
            {
                TempTable[i] = random.Next(min, max + 1);
                //TempTable[i] = i + min; // x+min = min allowed by table
            }
            // already random 
            /* 
            for (int i = 0; i < TempTable.Length; ++i)
            {
                int j = R.Next() % TempTable.Length;
                int TempV = TempTable[i];
                TempTable[i] = TempTable[j];
                TempTable[j] = TempV;

            }*/
            return TempTable;
        }

        // Exercice 4     Prendre Une table et la mettre en ordre Procedure
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

        // Exercice 4.5 Same string in a string Table Function 
        public static int SameStringFunc(string Same, string[] MyStringTable)
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

        // Exercice 5  Sortir les extension dune liste de fichiers function
        public static string[] ExtensionsOut()
        {
            string[] FilesNames = new string[] { "i.txt", "i.img", "i.cs" };
            foreach(string s in FilesNames)
            {
                Console.Write($"{s},");
            }
            Console.Write("       <------ Files");
            Space();
            string[] FilesExtentions = new string[FilesNames.Length];
            int x = 0;
            foreach (string i in FilesNames)
            {
                FilesExtentions[x] += Path.GetExtension(i);
                ++x;
            }
            return FilesExtentions;
        }


        // Exercice 6  // photocopie prix selon le nombre de copie
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

        // Exercice 7 Tarif selon critères de choix
        public static double CinemaTarif()
        {
            double PrixSession = 0; // tarif sans modif
            int TempAwnser = 0; // reutilisable awnser
            bool Matin = false; // Matin vrai faux
            bool Under18 = false; // UnderAge or not


            do // Matin ou soir
            {
                Console.WriteLine("Quelle Presentation voulez-Vous?     1- Matin");
                Console.WriteLine("                                     2- Soir");
                while (int.TryParse(Console.ReadLine(), out TempAwnser) == false)
                {
                    Console.WriteLine("Quelle Presentation voulez-Vous?     1- Matin");
                    Console.WriteLine("                                     2- Soir");
                };
            } while (TempAwnser < 1 | TempAwnser > 2);

            if (TempAwnser == 1)
            {
                PrixSession = 6;
                Matin = true;
            }


            TempAwnser = 0;
            if (Matin == false) // Toutes les autres Questions on seulement de l'importance le soir a part le 2d 3d
            {
                do
                {
                    Console.WriteLine("Quelle taille de salle voulez-vous?  1- Grande");
                    Console.WriteLine("                                     2- Petite");
                    while (int.TryParse(Console.ReadLine(), out TempAwnser) == false)
                    {
                        Console.WriteLine("Quelle taille de salle voulez-vous?  1- Grande");
                        Console.WriteLine("                                     2- Petite");
                    };

                } while (TempAwnser < 1 | TempAwnser > 2);

                if (TempAwnser == 1)
                {
                    PrixSession = 10.60;
                }
                else
                {
                    PrixSession = 9.60;
                }


                TempAwnser = 0;
                do
                {
                    Console.WriteLine("Quel age avez vous ?");
                    while (int.TryParse(Console.ReadLine(), out TempAwnser) == false)
                    {
                        Console.WriteLine("Quel age avez vous ?");
                    };
                } while (TempAwnser < 1 | TempAwnser > 110);
                {
                    if (TempAwnser < 18)
                    {
                        PrixSession = 6.90;
                        Under18 = true;
                    }
                }


                string EtudiantON;
                if (Under18 == false) // ignoré si en dessous de 18 a cause du meme tarif 
                {
                    do
                    {

                        Console.WriteLine("Etes Vous Etudiant ? Oui ou Non?");

                        EtudiantON = Console.ReadLine();


                    } while (EtudiantON.ToUpper() != "OUI" && EtudiantON.ToUpper() != "NON");

                    switch (EtudiantON)
                    {
                        case "OUI":
                            PrixSession = 6.90;
                            break;
                        case "NON":
                            break;
                    }

                }

            }

            TempAwnser = 0;
            do // majoration de 2$ si 3d
            {
                Console.WriteLine("Quelle Type dePresentation voulez-Vous?     1- 2D");
                Console.WriteLine("                                            2- 3D");
                while (int.TryParse(Console.ReadLine(), out TempAwnser) == false)
                {
                    Console.WriteLine("Quelle Type dePresentation voulez-Vous?     1- 2D");
                    Console.WriteLine("                                            2- 3D");
                };
            } while (TempAwnser < 1 | TempAwnser > 2);
            if (TempAwnser == 2)
            {
                PrixSession += 2;
            }

            return PrixSession;
        }

        // Exercice 8 Palindrome bool function
        public static bool PalindromeCheck(string MyString)
        {
            string Reversed = new string(MyString.Reverse().ToArray());
            Console.WriteLine($"Original : {MyString}");
            Console.WriteLine($"Reversed : {Reversed}");

            if (Reversed == MyString)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void Space()
        {
            Console.WriteLine();
        }



        static void Main(string[] args)
        {
                                                         // ex 11
            double CADtoUSD = Convertir(1, 0.6, true);
            Console.WriteLine(CADtoUSD);
            Space();

            // Ex 14 Create a Table of 10 int Random Between 12 and 55
            int[] MyIntTable  = intTableMinMax(12, 55);
            
            //Show Unsorted Table
            foreach (int i in MyIntTable)
            {
                Console.Write($"{i},");
            }
            Console.Write("           UNSORTED");

            // ex 15   Made the sort here since it made sense
            Space();
            SortedTableProcedure(MyIntTable);
            Console.Write("             SORTED");

            // ex 12 render the Values Moy Med Sum Min Max of the 10 random int table
            Space();
            Space();
            RenderValueMoyMedSumMinMax(MyIntTable);

            // ex 13 create a 31 List of double beween 0 and 100
            List<double> MyDoubleListClassNotes = DoubleTableMinMax(0, 100);

            //Show 31 double sorted
            Space();
            Console.WriteLine("Sorted 31 Doubles --->");
            foreach (double d in MyDoubleListClassNotes)
            {
                Console.Write($"{d},");
            }

            //Process and show Values of Moy Med Sum Min Max of the 31 doubles
            Space();
            Space();
            List<Values> MyNotesProcessed = new List<Values>(); //New class with all processed values
            MyNotesProcessed = DoubleNotesAnalyserMinMaxMedSumMoy(MyDoubleListClassNotes); //transfer value to new class list
            RenderListValues(MyNotesProcessed); // render my value visually

            // Ex 16 calculate multiple of same string in a string[]
            Space();
            string[] MyStringTable = new string[] { "a", "b", "c", "a", "a" };
            string a = "a";   // String to check for repetition
            foreach(string s in MyStringTable)
            {
                Console.Write($"{s},");
            }
            Console.Write("            <------String Table");

            Space();
            int SameString = SameStringFunc(a, MyStringTable); // calculate number of a in the string table
            Console.WriteLine($"il y {SameString} de {a} dans la table");

            // Ex 17 return extensions of files
            Space();
            string[] FileExten = ExtensionsOut();
            foreach (string i in FileExten)
            {
                Console.Write($"{i},");
            }
            Console.Write("        <----- Processed Extensions");

            // Ex 18 Calculate price of a number of copies
            Space();
            Space();
            int CopyNumbers = 31;
            Console.WriteLine($"Number of copies =  {CopyNumbers}");
            double PrixPhotocopie = PhotocopieCalcPrix(CopyNumbers);
            Console.WriteLine($"Prix des PhotoCopies = {PrixPhotocopie}$");

            // Ex 19 // end

            // Ex 20 Palindrome Checker
            Space();
            string PalindromeToCheck = "oomoo";
            bool Palindrome = PalindromeCheck(PalindromeToCheck);
            // aurait pu le mettre direct dans ma fonction et retourner un string
            string OuiOuNon;
            if (Palindrome == true)
            { OuiOuNon = "Oui"; }
            else
            { OuiOuNon = "Non"; }

            Console.WriteLine($"le string {PalindromeToCheck} est il un palindrome ? {OuiOuNon}");

            // Ex 19 Calculate Price of movie theater with questions
            Space();
            double MonPrix = CinemaTarif();
            Console.WriteLine($"Votre Tarif est {MonPrix}$");
        }
    }
}
