using System;
using System.Collections.Generic;


namespace Cours6ExerciceBis
{
    class Program
    {
        private static readonly Random R = new Random();



        //############################################ SIMULER LANCERS #############################################################//
        //############################################ SIMULER LANCERS #############################################################//
        //############################################ SIMULER LANCERS #############################################################//





        //Exercice 66
        private static List<int> SimulerXLancers(int n)
        {
            List<int> results = new List<int>();

            for(int x = 0;  x< n;++x)
            {
                results.Add(R.Next(1, 7));
            }
            return results;
        }



        //init lancers
        private static List<int> InitializeXLancers()
        {
            Console.Write("Combien de fois lancer le de ? :");
            int x;
            while (int.TryParse(Console.ReadLine(), out x) == false)
            {
            }

            List<int> results =SimulerXLancers(x);
            foreach(int i in results)
            {
                Console.Write($"{i},");
            }
            return results;

        }






        //############################################ DES PIPE #############################################################//
        //############################################ DES PIPE #############################################################//
        //############################################ DES PIPE #############################################################//






        //Exercice 67
        private static bool DePipe(List<int> lancers)
        {
            if (lancers.Count < 30)
            {
                Console.Write("Pas assez de donnees pour evaluer si le de est Pipe!");
                return false;
            }
            else
            {
                int un = 0, deux = 0, trois = 0, quatre = 0, cinq = 0, six = 0;
               foreach(int i in lancers)
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
                    if((((un / lancers.Count) * 100 > lancers.Count * 0.2) | ((deux / lancers.Count) * 100 > lancers.Count * 0.2) | ((trois / lancers.Count) * 100 > lancers.Count * 0.2)
                        | ((quatre / lancers.Count) * 100 > lancers.Count * 0.2) | ((cinq / lancers.Count) * 100 > lancers.Count * 0.2) | ((six / lancers.Count) * 100 > lancers.Count * 0.2)))
                    {
                        return true;
                    }
                    else if ((((un / lancers.Count) * 100 < lancers.Count * 0.09) | ((deux / lancers.Count) * 100 < lancers.Count * 0.09) | ((trois / lancers.Count) * 100 < lancers.Count * 0.09)
                        | ((quatre / lancers.Count) * 100 < lancers.Count * 0.09) | ((cinq / lancers.Count) * 100 < lancers.Count * 0.09) | ((six / lancers.Count) * 100 < lancers.Count * 0.09)))
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





        //############################################ EXERCICES SWITCH #############################################################//
        //############################################ EXERCICES SWITCH #############################################################//
        //############################################ EXERCICES SWITCH #############################################################//




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
                        InitializeXLancers();
                    }
                    break;
                case 2:
                    {
                       List<int> results = InitializeXLancers();
                        bool loadedques = DePipe(results);
                        Console.WriteLine($"Are these dices loaded : {loadedques}");
                    }
                    break;
            }
            ExerciceSwitch();
        }

        static void Main()
        {
            ExerciceSwitch();
        }
    }
}
