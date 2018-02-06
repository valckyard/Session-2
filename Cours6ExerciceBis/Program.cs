using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours6ExerciceBis
{
    class Program
    {
        private static Random R = new Random();

        //Exercice 66
        private static List<int> SimulerXLancers(int n)
        {
            List<int> Results = new List<int>();

            for(int x = 0;  x< n;++x)
            {
                Results.Add(R.Next(1, 7));
            }
            return Results;
        }

        private static List<int> initializeXLancers()
        {
            Console.Write("Combien de fois lancer le de ? :");
            int x;
            while (int.TryParse(Console.ReadLine(), out x) == false) ;

            List<int> Results =SimulerXLancers(x);
            foreach(int i in Results)
            {
                Console.Write($"{i},");
            }
            return Results;

        }

        //Exercice 67
        private static bool DePipe(List<int> Lancers)
        {
            if (Lancers.Count < 30)
            {
                Console.Write("Pas assez de donnees pour evaluer si le de est Pipe!");
                return false;
            }
            else
            {
                int un = 0, deux = 0, trois = 0, quatre = 0, cinq = 0, six = 0;
               foreach(int i in Lancers)
                {
                    switch(i)
                    {
                        case 1:
                            un += 1;
                            continue;
                        case 2:
                            deux += 1;
                            continue;
                        case 3:
                            trois += 1;
                            continue;
                        case 4:
                            quatre += 1;
                            continue;
                        case 5:
                            cinq += 1;
                            continue;
                        case 6:
                            six += 1;
                            continue;

                    }
                    if((((un / Lancers.Count) * 100 > Lancers.Count * 0.2) | ((deux / Lancers.Count) * 100 > Lancers.Count * 0.2) | ((trois / Lancers.Count) * 100 > Lancers.Count * 0.2)
                        | ((quatre / Lancers.Count) * 100 > Lancers.Count * 0.2) | ((cinq / Lancers.Count) * 100 > Lancers.Count * 0.2) | ((six / Lancers.Count) * 100 > Lancers.Count * 0.2)))
                    {
                        return true;
                    }
                    else if ((((un / Lancers.Count) * 100 < Lancers.Count * 0.09) | ((deux / Lancers.Count) * 100 < Lancers.Count * 0.09) | ((trois / Lancers.Count) * 100 < Lancers.Count * 0.09)
                        | ((quatre / Lancers.Count) * 100 < Lancers.Count * 0.09) | ((cinq / Lancers.Count) * 100 < Lancers.Count * 0.09) | ((six / Lancers.Count) * 100 < Lancers.Count * 0.09)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
        }

        private static void ExerciceSwitch()
        {

            Console.WriteLine($" 1 - Throw dem Dices");
            Console.WriteLine($" 2 - Are Theses Dices loaded");
            Console.Write("Choice : ");
            int x;
            while (int.TryParse(Console.ReadLine(), out x) == false)
            {
                if (x < 1 | x > 2)
                {
                    ExerciceSwitch();
                }
                Console.Clear();
            }



            switch (x)
            {
                case 1:
                    {
                        initializeXLancers();
                    }
                    break;
                case 2:
                    {
                       List<int> Results = initializeXLancers();
                        bool loadedques = DePipe(Results);
                        Console.WriteLine($"Are these dices loaded : {loadedques}");
                    }
                    break;
            }
            ExerciceSwitch();
        }

        static void Main(string[] args)
        {
            ExerciceSwitch();
        }
    }
}
