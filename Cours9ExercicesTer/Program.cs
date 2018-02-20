using System;
using System.Collections.Generic;
using System.Linq;

namespace Cours9ExercicesTer
{
    class Program
    {
        public enum Valeur
        {
            V,
            X,
            O
        }

        public struct Joueur
        {
            public Valeur ValJoueur;

        }

        public struct Vecteur
        {
            public int X;
            public int Y;

            public Vecteur(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public class Case
        {
            public Vecteur Vecteur;
            public Valeur Valeur;

            public bool Utilise;

            public Case(Vecteur vec)
            {
                Vecteur = vec;
                Valeur = Valeur.V;
                Utilise = false;
            }
            public bool Switchonuse()
            {
                Utilise = true;
                return Utilise;
            }




        }

        public struct Grid
        {
            public Dictionary<string, Case> CasesDeGrid;

            public Dictionary<string, Case> Create()
            {
                CasesDeGrid = new Dictionary<string, Case>();
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        CasesDeGrid.Add($"{x}{y}", new Case(new Vecteur(x, y)));
                    }
                }

                return CasesDeGrid;
            }



            public void AfficherGrid()
            {
                Console.WriteLine($" Y");
                Console.WriteLine($" 0     {CasesDeGrid["00"].Valeur}    |   {CasesDeGrid["10"].Valeur}   |    {CasesDeGrid["20"].Valeur}");
                Console.WriteLine("      ----------------------");
                Console.WriteLine($" 1     {CasesDeGrid["01"].Valeur}    |   {CasesDeGrid["11"].Valeur}   |    {CasesDeGrid["21"].Valeur}");
                Console.WriteLine("      ----------------------");
                Console.WriteLine($" 2     {CasesDeGrid["02"].Valeur}    |   {CasesDeGrid["12"].Valeur}   |    {CasesDeGrid["22"].Valeur}");
                Console.WriteLine();
                Console.WriteLine("       0        1        2   X");
            }
        }

        public static Case PlayerValue(Joueur player, Case x)
        {
            if (player.ValJoueur == Valeur.O)
            {
                x.Valeur = (Valeur)2;
                return x;
            }

            else
            {
                x.Valeur = (Valeur)1;
                return x;
            }

        }

        static void PlayCase(ref Grid _myGrid, Joueur Player)
        {

            Console.WriteLine($"What Case {Player.ValJoueur} want to play?");
            Console.Write("X axis : ");
            int x;
            while (int.TryParse(Console.ReadLine(), out x) == false)
            {

              
            }
            if (x < 0 | x > 3)
                PlayCase(ref _myGrid, Player);
            Console.WriteLine();
            Console.Write("Y axis : ");
            int y;
            while (int.TryParse(Console.ReadLine(), out y) == false)
            {

              
            }
            if (y < 0 | y > 3)
                PlayCase(ref _myGrid, Player);

            if (_myGrid.CasesDeGrid[$"{x}{y}"].Utilise)
            {
                Console.WriteLine("Case Already Played");
                PlayCase(ref _myGrid, Player);
            }
            else
            {
                _myGrid.CasesDeGrid[$"{x}{y}"].Switchonuse();

                PlayerValue(Player, _myGrid.CasesDeGrid[$"{x}{y}"]);

                Console.WriteLine(_myGrid.CasesDeGrid[$"{x}{y}"].Valeur);
            }



        }




        public static List<Joueur> PlayerChoice()
        {
            List<Joueur> joueurs = new List<Joueur>();
            string choice;
            do
            {
                Console.WriteLine("What shape do player 1 want ? X or O");
                choice = Console.ReadLine().ToUpper();
            } while (choice != "O" && choice != "X");

            if (choice == "X")
            {
                Joueur player1 = new Joueur();
                player1.ValJoueur = Valeur.X;
                Joueur player2 = new Joueur();
                player2.ValJoueur = Valeur.O;
                joueurs.Add(player1);
                joueurs.Add(player2);
                return joueurs;
            }
            else
            {
                Joueur player1 = new Joueur();
                player1.ValJoueur = Valeur.O;
                Joueur player2 = new Joueur();
                player2.ValJoueur = Valeur.X;
                joueurs.Add(player1);
                joueurs.Add(player2);
                return joueurs;
            }


        }


        public static void CheckWin(Grid grid)
        {
            List<Valeur> axisChk = new List<Valeur>();

            for (int x = 0; x < 3; x++)
            {
                axisChk = new List<Valeur>();
                for (int y = 0; y < 3; y++)
                {
                    if (!grid.CasesDeGrid[$"{x}{y}"].Utilise)
                        break;
                    else
                        axisChk.Add(grid.CasesDeGrid[$"{x}{y}"].Valeur);
                }

                CheckListWin(axisChk);
            }

            for (int y = 0; y < 3; y++)
            {
                axisChk = new List<Valeur>();
                for (int x = 0; x < 3; x++)
                {
                    if (!grid.CasesDeGrid[$"{x}{y}"].Utilise)
                        break;
                    else
                        axisChk.Add(grid.CasesDeGrid[$"{x}{y}"].Valeur);
                }

                CheckListWin(axisChk);
            }

            axisChk = new List<Valeur>();
            axisChk.Add(grid.CasesDeGrid[$"00"].Valeur);
            axisChk.Add(grid.CasesDeGrid[$"11"].Valeur);
            axisChk.Add(grid.CasesDeGrid[$"22"].Valeur);
            CheckListWin(axisChk);

            axisChk = new List<Valeur>();
            axisChk.Add(grid.CasesDeGrid[$"02"].Valeur);
            axisChk.Add(grid.CasesDeGrid[$"11"].Valeur);
            axisChk.Add(grid.CasesDeGrid[$"20"].Valeur);
            CheckListWin(axisChk);

        }

        private static void CheckListWin(List<Valeur> YAxisChk)
        {
            int valo = 0;
            int valx = 0;
            foreach (var O in YAxisChk)
            {
                if (O == Valeur.O)
                {
                    ++valo;
                }

                if (O == Valeur.X)
                {
                    ++valx;
                }
            }
            if (valo == 3)
            {
                Console.WriteLine("Joueur O Gagne!");
                Console.ReadLine();
                TheGame();
            }
            if (valx == 3)
            {
                Console.WriteLine("Joueur X Gagne!");
                Console.ReadLine();
                TheGame();
            }
        }


        static void Main(string[] args)
        {
            TheGame();

        }

        private static void TheGame()
        {
            Grid magrille = new Grid();
            magrille.Create();
            magrille.AfficherGrid();
            List<Joueur> mesJoueurs = PlayerChoice();
            int x = 0;

            do
            {

                PlayCase(ref magrille, mesJoueurs[x]);
                CheckWin(magrille);
                if (x == 0)
                {
                    x = 1;
                }
                else
                {
                    x = 0;
                }
                Console.Clear();
                magrille.AfficherGrid();
            } while (true);
        }
    }
}
