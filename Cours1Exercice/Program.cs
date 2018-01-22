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
        public static Random R = new Random(); //Reutilisable Random

        //Exercice 1    Taux et Taux en Reverse
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

        //Exercice 2    Table Moyenne Mediane Min Max Total Procedure
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

        // Exercice 2.5  Table Moyenne Mediane Min Max Total dans une Liste Fonction
        public static List<Values> RetourneValeurs10int(int[] MyTable)
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



        static void Main(string[] args)
        {
            // ex 1
            double CADtoUSD = Convertir(1, 0.6, true);
            Console.WriteLine(CADtoUSD);

            // ex 2
            int[] MyIntTable = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            RenderValueMoyMedSumMinMax(MyIntTable);

            // ex 2.5
            List<Values> My10Processsed = new List<Values>();
            My10Processsed = RetourneValeurs10int(MyIntTable);
            RenderListValues(My10Processsed);

            // ex 3
            int[] TableMixed = CreateTableMinMax(12, 55);
            foreach (int i in TableMixed)
            {
                Console.Write($"{i},");
            }

            // ex 4
            Console.WriteLine();
            SortedTableProcedure(TableMixed);

            //ex4.5
            string[] MyStringTable = new string[] { "a", "b", "c", "a", "a" };
            string a = "a";

            Console.WriteLine();
            int SameString = SameStringFunc(a, MyStringTable);
            Console.WriteLine($"il y {SameString} de {a} dans la table");

            //ex5 
            string[] FileExten = ExtensionsOut();
            foreach (string i in FileExten)
            {
                Console.Write($"{i},");
            }

            //ex6
            Console.WriteLine();
            double PrixPhotocopie = PhotocopieCalcPrix(31);
            Console.WriteLine($"Prix des PhotoCopies = {PrixPhotocopie}$");

            //ex7
            Console.WriteLine();
            double MonPrix = CinemaTarif();
            Console.WriteLine($"Votre Tarif est {MonPrix}$");

            //ex8
            string PalindromeToCheck = "oomoo";
            bool Palindrome = PalindromeCheck(PalindromeToCheck);
            // aurait pu le mettre direct dans ma fonction et retourner un string
            string OuiOuNon;
            if (Palindrome == true)
            { OuiOuNon = "Oui"; }
            else
            { OuiOuNon = "Non"; }

            Console.WriteLine($"le string {PalindromeToCheck} est il un palindrome ? {OuiOuNon}");
        }
    }
}
