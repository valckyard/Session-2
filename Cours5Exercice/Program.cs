using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Cours5Exercice
{
    class Program
    {
        private static readonly string BaseAdress =
            "https://eutils.ncbi.nlm.nih.gov/entrez/eu{0}tils/efetch.fcgi?db=pubmed&retmode=xml&id=";

        private static readonly string[] Ids =
        {
            "29374430", "29374429", "29374424", "29374415", "29374414", "29374413", "29374412", "29374411", "29374410",
            "29374409", "29374408", "29374407", "29374406", "29374394", "29374392", "29374391", "29374384", "29374370",
            "29374363", "29374362"
        };

        private static readonly string[] Names = { "Alex", "Nicolas", "Pedro", "Jean-Guy", "Pablo" };
        private static readonly string[] FamilyNames = { "Caron", "Baril", "LePetit", "Tremblay", "Picasso" };
        //######################################### Exercice 51  #############################################
        private static void InitializeRenderNames()
        {
            RenderStringTab(Names); // same method as Ex 53
        }

        //######################################### Exercice 52  #############################################

        private static void RenderUsers()
        {
            for (var x = 0; x < Names.Length; ++x)
            {
                Console.WriteLine($"ID {x} : Prenom/Nom : {Names[x]} {FamilyNames[x]} !");
            }
        }

        //######################################### Exercice 53  #############################################

        // Used readonly cuz didint feel like putting them in the program since theyre huge
        private static string[] Pubmed()
        {
            string[] urlLinks = new string[Ids.Length]; // my return urls will be the same length as the number of ids



            for (var x = 0; x < Ids.Length; ++x) // O(n) lineaire ca serait pe un peu long et stupide lol
            {
                urlLinks[x] = $"{BaseAdress}{Ids[x]}"; // yayyyyy >.>b
            }

            return urlLinks;
        }


        private static void RenderStringTab(string[] theTable)
        {
            foreach (var l in theTable)
            {
                Console.WriteLine($"{l}");
            }
        }

        //######################################### Exercice 54  #############################################
        public static bool SolveMagicSquare(int[,] matrice, int num)
        {

  
        


            if (num <= 0)
            {
                return false;
            }
            for (int i = 0; i < matrice.GetLength(0); i++)
                for (int j = 0; j < matrice.GetLength(1); j++) matrice[i, j] = 0;
            //i = line , j= column
            matrice[0, matrice.GetLength(1) / 2] = 1;
            for (int i = 0, j = matrice.GetLength(1) / 2, process = 2; process <= num * num; process++)
            {
                if ((i - 1) > 0 && j + 1 < matrice.GetLength(1) && matrice[i - 1, j + 1] == 0)
                {
                    i = i - 1; j = j + 1;
                    matrice[i, j] = process;
                }
                else if ((i - 1) > 0 && j + 1 < matrice.GetLength(1) && matrice[i - 1, j + 1] != 0)
                {
                    i = i + 1;
                    matrice[i, j] = process;
                }
                else if (i == 0 && j == num - 1)
                {
                    i = 1; j = num - 1;
                    matrice[i, j] = process;
                }
                else
                {
                    if ((i - 1) < 0 && j + 1 < matrice.GetLength(1))
                    {
                        i = num - 1; j = j + 1;
                        matrice[i, j] = process;
                    }
                    else if ((j + 1) == matrice.GetLength(1) && (i - 1) > 0 && (i - 1) < matrice.GetLength(0))
                    {
                        i = i - 1; j = 0;
                        matrice[i, j] = process;
                    }
                    else if ((j + 1) == matrice.GetLength(1) && (i - 1) == 0)
                    {
                        i = 0; j = 0;
                        matrice[i, j] = process;
                    }
                    else if ((j + 1) == matrice.GetLength(1) && (i - 1) < 0)
                    {
                        i = i - 1; j = 0;
                        matrice[i, j] = process;
                    }
                    else if (i - 1 < matrice.GetLength(0) && j + 1 < matrice.GetLength(1) && matrice[i - 1, j + 1] != 0)
                    {
                        i = i + 1; matrice[i, j] = process;
                    }
                    else if ((i - 1) == 0 && j + 1 < matrice.GetLength(1) && matrice[i - 1, j + 1] == 0)
                    {
                        i = i - 1; j = j + 1;
                        matrice[i, j] = process;
                    }
                }
            }
            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    Console.Write(matrice[i, j]);
                    Console.Write(" ");
                    Console.Write(" ");
                }
                Console.WriteLine(" ");
                Console.WriteLine(" ");
            }
            return true;
        }
        //**************************************************************** //input: magic squre
        //output: if the fillings are correct(sum of lines= sum of column          s = sum of crossings) output=true => sucess, else=>fail.
        static bool test1(int[,] mat, int num)
        {
            int sum = 0;
            for (int i = 0; i < num; i++)
            {
                sum += mat[0, i];
            }
            int temp = 0;
            for (int i = 0; i < num; i++)
            {
                temp = 0;
                for (int j = 0; j < num; j++)
                {
                    temp += mat[i, j];
                }
                if (temp != sum) return false;
            }
            temp = 0;
            for (int i = 0; i < num; i++)
            {
                temp = 0;
                for (int j = 0; j < num; j++)
                {
                    temp += mat[j, i];
                }
                if (temp != sum) return false;
            }
            temp = 0;
            for (int i = 0; i < num; i++)
            {
                temp += mat[i, i];
            }
            if (temp != sum) return false;
            return true;
        }
    

//######################################### Exercice 55  #############################################

private static string CharToString()
        {
            char[] Prog = { 'P', 'r', 'o', 'g', 'r', 'a', 'm', 'm', 'a', 't', 'i', 'o', 'n','M', 'o', 'd', 'u', 'l', 'a', 'i', 'r', 'e' };
            string AllTogether = null;
            foreach (char c in Prog.ToArray().Reverse())
            {
                AllTogether += $"{c}";
                
            }
            return AllTogether;
        }

        //######################################### Exercice 56  #############################################

        private static void SumOfDiagCube()
        {
            int[,,] array3D = new int[,,] { { { 1, 2, 3 }, { 4, 5, 6 } },{ { 7, 8, 9 }, { 10, 11, 12 } } };
            int[,,] m = new int[3, 3, 3];
            int sum = 0;
            int n = 1;

            for (int x = 0; x < 3; x++)
            for (int y = 0; y < 3; y++)
            for (int z = 0; z < 3; z++)
                m[x, y, z] = n++;


            sum = m[0, 0, 0] + m[1, 1, 1] + m[2, 2, 2];

            Console.WriteLine("Sum of first diagonal: " + sum);
            //Sum of first diagonal: 42
        }

        //############################### Initializers ######################################

        private static void InitializePubmed()
        {
            string[] links = Pubmed();
            RenderStringTab(links);
        }

        private static void InitializeChartoString()
        {
            Console.WriteLine(CharToString());
        }


        private static void ExerciceSwitch()
        {
            int x;
            while (int.TryParse(Console.ReadLine(), out x) == false)
            {
                if (x < 1 | x > 5)
                {
                    ExerciceSwitch();
                }
                Console.Clear();
            }



            switch (x)
            {
                case 1:
                    { InitializeRenderNames(); }
                    break;
                case 2:
                    {
                        RenderUsers();
                    }
                    break;
                case 3:
                    {
                        InitializePubmed();
                    }
                    break;
                case 4:
                    int num = int.Parse(Console.ReadLine());
                    int[,] mat = new int[num, num];
                    SolveMagicSquare(mat, num);
                    if (test1(mat, num) == false) { Console.WriteLine("FAILED!!!"); }
                    else Console.WriteLine("SUCCESS!!!");
                    break;
                case 5:
                {
                    InitializeChartoString();
                }
                    break;
                case 6:
                {
                    
                }
                    break;
         
            }
            Console.WriteLine();
            ExerciceSwitch();
        }


        private static void Main(string[] args)
        {
            ExerciceSwitch();

        }
    }
}
