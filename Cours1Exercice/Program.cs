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

        public static double NextDouble(double minimum, double maximum) // Double Random Min,Max
        {

            return random.NextDouble() * (maximum - minimum) + minimum;

        }

        //Exercice 11   Taux et Taux en Reverse
        public static double Convertir(double Montant, bool inverse)
        {

            Dictionary<string, double> rates = new Dictionary<string, double>();
            rates.Add("CAD", 0.81);
            rates.Add("USD", 1.0);


            double Converted = 0;
            if (inverse == true)
            {
                Converted = (Montant * (rates["CAD"] / rates["USD"]));
                Console.Write($"CAD To USD : {Converted} ");
                return Converted;
            }
            if (inverse == false)
            {
                Converted = (Montant * (rates["USD"] / rates["CAD"]));
                Console.Write($"USD To CAD : {Converted} ");
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


            if (TempCount % 2 == 0)         // even
            {
                int Middle = TempArray[(TempCount / 2) - 1];


                int Middle2 = TempArray[(TempCount / 2)];


                Median = (Middle + Middle2) / 2;
            }
            else if (TempCount % 2 != 0)    // odd
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
            int Students = 31;
            for (int i = 0; i < Students; i++) // assuming there is 31 student
            {
                TempTable.Add(NextDouble(min, max));
            }
            TempTable.Sort();
            return TempTable;
        }

        // Exercice 13  Table Moyenne Mediane Min Max Total dans une Liste Fonction
        public static List<double> ReturnDoubleOverAverage(List<double> MyTable)
        {

            double Total = 0;
            double Minimum = 0;
            double Maximum = 0;
            double Median = 0;

            //Median
            int TempCount = MyTable.Count;


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
            double Moyenne = Total / MyTable.Count();

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
            List<double> OverAverage = new List<double>();


            MaxMinTotalMoyMed.Add(new Values() { Medianne = Median, Moyennne = Moyenne, Max = Maximum, Min = Minimum, Total = Total });
            RenderListValues(MaxMinTotalMoyMed); //Add value to my Class to show them (unnessasary but fun)

            foreach (double d in MyTable) // Add >Averages grades to double list
            {
                if (d > Moyenne)
                {
                    OverAverage.Add(d);
                }
            }


            return OverAverage;

        }

        //Render List Value Exercise 13.5 Procedure
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

        // Exercice 14   Creer table avec un Min Max en Fonction
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

        // Exercice 15    Prendre Une table et la mettre en ordre Procedure #MyBubleSort
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

        // Exercice 16 Same string in a string Table Function 
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

        // Exercice 17  Sortir les extension dune liste de fichiers function
        public static string[] ExtensionsOut(string[] FilesNames)
        {

            foreach (string s in FilesNames)
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


        // Exercice 18  // photocopie prix selon le nombre de copie
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

        // Exercice 19 Tarif selon critères de choix
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



        public static void Space()
        {
            Console.WriteLine();
        }

        //Clean Question Interface
        static int SwitchExercices()
        {
            int x;
            do
            {

                Console.WriteLine($"Quel Exercice voulez vous essayer ?   1 - Exercice 11 : Taux de Change  ");
                Console.WriteLine("                                     {2 - Exercice 14 : Creer table 10 elements random Min/Max ");
                Console.WriteLine("                              Block  {    Exercice 15 : Trier la table en ordre croissant ");
                Console.WriteLine("                                     {____Exercice 12 : Procedure qui affiche Moy/Med/Min/Max/Total des 10 elements ");
                Console.WriteLine($"                                      3 - Exercice 13 : Creer ListeDouble /Trier/Min/Moy...etc Et sortir valeurs > Moy");
                Console.WriteLine($"                                      4 - Exercice 16 : Fonction qui dit combien du meme String est dans la chaine");
                Console.WriteLine($"                                      5 - Exercice 17 : Retourner les extentions d'une liste de fichiers");
                Console.WriteLine($"                                      6 - Exercice 18 : Prix de photocopies");
                Console.WriteLine($"                                      7 - Exercice 19 : Tarif de Cinema");
                while (int.TryParse(Console.ReadLine(), out x) == false)
                {
                    Console.WriteLine("Un nombre gros epais");
                }
            } while (x < 1 | x > 7);
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
                        // ex 11
                        double CADtoUSD = Convertir(50, true);
                        double USDtoCAD = Convertir(50, false);
                        Space();
                        Space();
                    }
                    break;
                case 2:
                    {
                        // Ex 14 Create a Table of 10 int Random Between 12 and 55
                        int[] MyIntTable = intTableMinMax(12, 55);
                        
                        


                        //Show Unsorted Table
                        Console.Write("UNSORTED : ");
                        foreach (int i in MyIntTable)
                        {
                            Console.Write($"{i},");
                        }
                        Space();
                        Space();
                        Space();



                        // ex 15   Made the sort here since it made sense
                        Console.Write("SORTED   : ");
                        SortedTableProcedure(MyIntTable);
                        Space();
                        Space();
                        Space();


                        // ex 12 render the Values Moy Med Sum Min Max of the 10 random int table
                        RenderValueMoyMedSumMinMax(MyIntTable);
                        Space();
                        Space();
                    }
                    break;


                case 3:
                    {
                        
                        
                        // ex 13 create a 31 List of double beween 0 and 100
                        List<double> MyDoubleListClassNotes = DoubleTableMinMax(0, 100);




                        //Show 31 double sorted
                        Console.WriteLine("Sorted 31 Doubles --->");
                        foreach (double d in MyDoubleListClassNotes)
                        {
                            Console.Write($"{d},");
                        }
                        Space();
                        Space();
                        Space();



                        //Process and show Values of Moy Med Sum Min Max of the 31 doubles // And Create a list of over average results!
                        List<double> OverAverageReturn = new List<double>(); // Over average list double creation
                        OverAverageReturn = ReturnDoubleOverAverage(MyDoubleListClassNotes); //transfer values  > Average to new double list and show Stats Values
                        Space();
                        Space();



                        // Render over averages grades
                        Console.WriteLine("Over Average of my 31 Doubles --->");
                        foreach (double d in OverAverageReturn) // render my value visually
                        {
                            Console.Write($"{d},");
                        }
                        Space();
                        Space();
                        Space();
                    }
                    break;


                case 4:
                    {

                        // Ex 16 calculate multiple of same string in a string[]
                        string[] MyStringTable = new string[] { "a", "b", "c", "a", "a" };
                        string a = "a";   // String to check for repetition
                        foreach (string s in MyStringTable)
                        {
                            Console.Write($"{s},");
                        }
                        Console.Write("            <------String Table");

                        Space();

                        int SameString = SameStringFunc(a, MyStringTable); // calculate number of a in the string table
                        Console.WriteLine($"il y {SameString} de {a} dans la table");
                        Space();
                        Space();
                    }
                    break;


                case 5:
                    {

                        // Ex 17 return extensions of files
                        string[] FilesNames = new string[] { "i.txt", "i.img", "i.cs" };
                        string[] FileExten = ExtensionsOut(FilesNames);
                        foreach (string i in FileExten)
                        {
                            Console.Write($"{i},");
                        }
                        Console.WriteLine("        <----- Processed Extensions");
                        Space();
                        Space();


                    }
                    break;


                case 6:
                    {

                        // Ex 18 Calculate price of a number of copies
                        int CopyNumbers = 31;


                        Console.WriteLine($"Number of copies =  {CopyNumbers}");
                        double PrixPhotocopie = PhotocopieCalcPrix(CopyNumbers);
                        Console.WriteLine($"Prix des PhotoCopies = {PrixPhotocopie}$");
                        Space();

                    }
                    break;


                case 7:
                    {

                        // Ex 19 Calculate Price of movie theater with questions
                        double MonPrix = CinemaTarif();
                        Console.WriteLine($"Votre Tarif est {MonPrix}$");

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
