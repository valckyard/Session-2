using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours1Notes
{
    class Program
    {
        public static int PuissanceFonction(int n, int x) // fonction
        {
            int Res = 1;
            for (int i = 0; i < n; i++)
            {
                Res = Res * x;
            }
            return Res;
        }// retourne la puissance

        public static void PuissanceProcedure(int n, int x) // Procedure
        {
            int Res = 1;
            for (int i = 0; i < n; i++)
            {
                Res = Res * x;
            }
            Console.WriteLine(Res);
        }// ne retourne pas de valeur

        static void Main(string[] args)
        {
            PuissanceProcedure(2, 4);
            int Resultat = PuissanceFonction(2, 4);

        }
    }
}
