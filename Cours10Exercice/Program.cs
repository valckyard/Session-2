using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cours10Exercice
{
    class Program
    {
        static void Main(string[] args)
        {
            JeuSaladier MaSalade = new JeuSaladier("MonJeu");
            MaSalade.AutoInit();



            
            int equipe = randy.Rand.Next(0, 2);

            bool win = false;
            do
            {
                string tofind = MaSalade.SortirUneSalade();
                if (equipe == 1)
                {
                    Devine(tofind, ref MaSalade.Equipe_A, ref MaSalade);
                }
                else
                {

                    Devine(tofind,ref MaSalade.Equipe_B, ref MaSalade);
                
                }


                if (equipe == 1)
                {
                    equipe = 2;
                }
                else
                {
                    equipe = 1;
                }




            } while (!win);


        }

        public static void Devine(string tofind,ref Equipe malade, ref JeuSaladier masal)
        {
            Console.WriteLine($"Le joueur de l equipe {malade.Nom} : {malade.ListeEquipe[malade.CurrentPlayer]}");
            Console.WriteLine("TOURNEZ VOUS IL VERRA LE MOT!");
            Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine(tofind);
            Console.WriteLine("Enter to hide");
            Console.ReadLine();
            Console.Clear();

            while (masal.MancheActuelle <= 3)
            {
                Console.WriteLine($"Tout Est Permis sauf le nom ! Essai {masal.MancheActuelle}" );
                checkmot(ref malade, Console.ReadLine(), tofind);
                ++masal.MancheActuelle;
                Console.WriteLine($"UN SEUL MOT ! Essai {masal.MancheActuelle}");
               checkmot(ref malade, Console.ReadLine(), tofind);
                ++masal.MancheActuelle;
                Console.WriteLine($"MIME LA PERSONALITE! Essai {masal.MancheActuelle}");
                checkmot(ref malade, Console.ReadLine(), tofind);
                ++masal.MancheActuelle;

            }

            Console.WriteLine($"Fin du tour de {malade.Nom} et du joueur {malade.ListeEquipe[malade.CurrentPlayer]}");
            malade.Nextplayer();
            
        }

        public static void checkmot(ref Equipe equipe, string mot, string mottofind)
        {
            if (mot == mottofind)
            {
                Console.WriteLine($"Mot Trouver {equipe.Nom} gagne 1 pts ");
                equipe.Score++;
            }
            else
            {
                Console.WriteLine($"Ce n est pas le mot ");
            }
            


        }
    }
}
