using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cours10Exercice
{
    class randy
    {
        public static Random Rand = new Random();
    }

    public struct JeuSaladier
    {
        public string NomSaladier;
        public Equipe Equipe_A;
        public Equipe Equipe_B;
        public int MancheActuelle;
        public List<string> Saladier;
        public List<string> SaladierUtilise;

        public JeuSaladier(string nomdemoNomSaladier)
        {
            NomSaladier = nomdemoNomSaladier;
            Equipe_A = new Equipe();
            Equipe_B = new Equipe();
            MancheActuelle = 1;
            Saladier = new List<string>(); //add func create
            SaladierUtilise = new List<string>();

        }

        public string SortirUneSalade()
        {

            int x = randy.Rand.Next(0, Saladier.Count);
            string randomsalade = Saladier[x];
            SaladierUtilise.Add(Saladier[x]);
            Saladier.Remove(Saladier[x]);
            return randomsalade;


        }

        public void init()
        {
            Console.Write("Nom de l'equipe A ?");
            var nomA = Console.ReadLine();
            Equipe_A.Nom = nomA;

            Console.WriteLine();

            Console.Write("Nom de l'equipe B ?");
            var nomB = Console.ReadLine();
            Equipe_B.Nom = nomB;

            Console.WriteLine();

            bool Done = false;

            do
            {
                Console.Write($"Ajouer un joueur a l'equipe  {Equipe_A.Nom} ? O/N");
                string question = Console.ReadLine().ToUpper();

                switch (question)
                {
                    case "O":
                        {
                            Console.WriteLine(
                                $"Quel est le nom du joueur {Equipe_A.ListeEquipe.Count + 1} de l'equipe {Equipe_A.Nom} !");
                            var nom = Console.ReadLine();
                            Equipe_A.ListeEquipe.Add(new Joueur(nom));
                            for (int x = 0; x < 5; x++)
                            {
                                Console.Write("Mot a ajouter au saladier :");
                                Saladier.Add(Console.ReadLine());
                                Console.WriteLine();
                            }

                            Console.WriteLine("Done!");
                            Console.WriteLine();

                        }
                        break;
                    case "N":
                        Done = true;
                        break;
                    default:
                        Console.WriteLine("NonValide");
                        Console.WriteLine();
                        break;
                }
            } while (!Done || Equipe_A.ListeEquipe.Count < 2);

            Done = false;

            do
            {
                Console.Write($"Ajouer un joueur a l'equipe  {Equipe_B.Nom} ? O/N");
                string question = Console.ReadLine().ToUpper();

                switch (question)
                {
                    case "O":
                        {
                            Console.WriteLine(
                                $"Quel est le nom du joueur {Equipe_B.ListeEquipe.Count + 1} de l'equipe {Equipe_B.Nom} !");
                            var nom = Console.ReadLine();
                            Equipe_B.ListeEquipe.Add(new Joueur(nom));
                            for (int x = 0; x < 5; x++)
                            {
                                Console.Write("Mot a ajouter au saladier :");
                                Saladier.Add(Console.ReadLine());
                                Console.WriteLine();
                            }

                            Console.WriteLine("Done!");
                            Console.WriteLine();

                        }
                        break;
                    case "N":
                        Done = true;
                        break;
                    default:
                        Console.WriteLine("NonValide");
                        Console.WriteLine();
                        break;
                }
            } while (!Done || Equipe_B.ListeEquipe.Count < 2);


            Console.WriteLine("Creation Done!");
        }

        public void AutoInit()
        {
            Equipe_A = new Equipe("EquipeA");
            Equipe_B = new Equipe("EquipeB");

            for (int i = 0; i < 4; i++)
            {
                Equipe_A.ListeEquipe.Add(new Joueur($"{i}"));
                Equipe_B.ListeEquipe.Add(new Joueur($"{i}"));
            }


            List<string> list = new List<string>();
            string oneLine;
            StreamReader myReader = new StreamReader("initials.txt");
            while ((oneLine = myReader.ReadLine()) != null)
            {
                list.Add(oneLine);
            }

            for (int i = 0; i < 40; i++)
            {
                Saladier.Add(list[randy.Rand.Next(0,list.Count)]);
            }

            Console.WriteLine("Creation Done!");

        }
    }


}


