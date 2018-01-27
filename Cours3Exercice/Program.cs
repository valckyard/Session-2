using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours3Exercice
{
    public class RowList
    {
        public double Row1 { get; set; }
        public double Row2 { get; set; }
    }
    class Program
    {

        //Ex31** : Donner le nombre d’étapes effectuées par la fonction, en déduire la complexité en temps
        //(Notation de Landeau) de cet algorithme en C#

        // Exercice 31
        public static double sommeTableau(double[] monTableau)
        {
            double somme = 0;
            for (int i = 0; i < monTableau.Length; i++)  // 2
            {
                somme += monTableau[i];                  // 1
                //N = Length of table   monTableau.Length = x
                //Nx = (1(i>x) + 1(++i) + 1(+=)) * x (2)
                //N1 = (1 + 1 + 1) * 1 (3) 
                //N2 = (1 + 1 + 1) * 2 (6)     so ++3 each new var in table
                //N3 = (1 + 1 + 1) * 3 (9)
                //N4 = (1 + 1 + 1) * 4 (12)
            }
            return somme;
        } 
        // Reponse Lineaire == O(n) = 3(n)



        //  Ex32** : Donner le nombre d’étapes effectuées par la fonction, en déduire la complexité en temps
        //  (Notation de Landeau) de cet algorithme en C#

        // Exercice 32
        public static double sommeMatrice(double[,] maMatrice)
        {
            double x = 0;
            double y = 0;
            double somme = 0;
            for (int i = 0; i < maMatrice.GetLength(0); i++)// 2      //2*n
            {
               
                for (int j = 0; j < maMatrice.GetLength(1); j++)// 2  //3*n
                {
                    somme += maMatrice[i, j]; // 1
                  
                    
                }
            }
            Console.WriteLine(x);
            return somme;
        }
        // Reponse Quadratique =  n(2+3n)  Simplifie  a  ===== {{ 2n+3n^2 }}                 




        //Ex33*: Donner le nombre d’étapes effectuées par la fonction, en déduire la complexité en temps
        //(Notation de Landeau) de cet algorithme en C#
        //(Cette fonction est inutile et retournera toujours 0)

        // Exercice 33
        public static int fonctionInutile(int n)
        {
            if (n == 1)                                                     // 1
            {
                return 1;
            }
            else
            {
                return fonctionInutile(n - 1) - fonctionInutile(n - 1);     //1 + 2*(1+2(1)
            }
        }
        //Indice : Commencez par observer le nombre d’« étapes » effectuées, pour n allant de 1 à 4
        // n=1, 1 étape(1 comparaison)                      = 1  
        // n=2, 1 + 2*(1) = 3 étapes                        = 2 + 1  / 1 + 2*(1)   
        // n = 3, 1 + 2*(1+2*(1)) = 7 étapes                = 6 + 1  / 1 + 2*(1 + 2(1))   n(1+2*(1)) +1

        // n = 4, 1 + 2*(1+2*(1+2*(1))) = 15 étapes         = 14 + 1 /                     n(1+2(1)) +1
        // n = 5  1 + 2*(1+2*(1+2*(1+2*(1)))) = 29 etapes   = 30 + 1  
        // n = 6  1 + 2*(1+2*(1+2*(1+2*(1+2*(1))))) 63 et   = 62 + 1


        //
        //      4            1 + 2 *(     
        //  3       3         (1 + 2 *(       1*2*4+4 
        //2   2   2   2        ( 1 + 2 *(     1+1+1
        //1   1   1   1          (1)          15


        //      5               1*2*4*8+8
        //  4       4           1+1+1+1
        //3     33      3       76           
        //22   2222     22
        //11   1111     11


        // Fonction Recusive
        // f(n) = 2(n-1) + 1

        // Reponse 
        // {{ (2^n)-(n-(n-1)) }} ou {{ (2^n) -1 }}
        //Donc Finalement format {{ O^n }} expotentielle




        static void Main(string[] args)
        {
            List<RowList> MyMat = new List<RowList>();
            for (int x = 0; x < 4; ++x)
            {
                MyMat.Add(new RowList { Row1 = x + 1});
            }
            int[] MyTable = new int[] { 1,2,3,4};
            MyinttableWork(MyTable);

            MyMatwork(MyMat);


        }

        public static void MyinttableWork(int[] Lala)
        {
            double x = 0;
            double y = 0;
            double somme = 0;
            for (int i = 0; i < Lala.Length; i++)//Parcours lignes        //2 for 2
            {
                x += 2;
                for (int j = 0; j < Lala.Length; j++)//Parcours colonnes  //2 run each twice (2) for each (2
                {
                    somme += (Lala[i] + Lala[j]);
                    y += 2 * 3;
                }
                
            }
            double z = (4*2) * (4*3); // (n*2)*(n*3)
            Console.WriteLine(y);
            Console.WriteLine(z);
            Console.WriteLine();
        }
        public static void MyMatwork(List<RowList> MyMat)
        {
            double somme = 0;
            int x = 0;
            int y = 0;
            int z = 0;
            foreach (RowList i in MyMat)
            {
                x += ((2 * MyMat.Count()) * 2) + 1;
                y += 2;
                z += (2 * MyMat.Count()) * 2; // valid


                foreach (RowList i2 in MyMat)
                {
                    somme += (i.Row1 + i2.Row1);

                    y += 3;

                    z += 1;                 // valid
                }
            }

            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);
            Console.WriteLine();

          double calc = Math.Pow(4,2) * 5;
            int calc2 = (MyMat.Count() * 2) * ((MyMat.Count() * 3));
            int calc3 = (MyMat.Count() * 2) * ((MyMat.Count() * 2 + 1));
            int calc4 = ((MyMat.Count() * 2) * (MyMat.Count() * 2)) + ((MyMat.Count() * MyMat.Count()) * (1));

            Console.WriteLine(calc); // length * length = number of time Procedure inside is used
            Console.WriteLine(calc2);  //(2*n)(3*n)
            Console.WriteLine(calc3);  //(2*n)(n*2+1)
            Console.WriteLine(calc4);   // ((2*n)(2*n)) + ((n * n)(1))
        }
    }
}
