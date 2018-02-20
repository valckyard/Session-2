using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cours9ExerciceBis
{
    class Program
    {
        //################################################# EXERCICE 95 ######################################//
        //################################################# EXERCICE 95 ######################################//
        //################################################# EXERCICE 95 ######################################//

        public struct CV
        {
            public string Titre;
            public string Nom;
            public string Prenom;
            public List<Ecole> SchoolList;
            public List<ExperienceProfessionelle> Experience;
            public int CvScore { get; set; }


            public CV(string title, string nom, string prenom, List<Ecole> schools, List<ExperienceProfessionelle> experience)
            {
                Titre = title;
                Nom = nom;
                Prenom = prenom;
                SchoolList = schools;
                Experience = experience;
                CvScore = 0;
            }



            public int CalculeleScore()
            {
                CvScore = 0;

                foreach (var ecole in SchoolList)
                {
                    CvScore += ecole.Prestige;
                }

                CvScore = (Experience.Count * 5) + CvScore;
                return CvScore;
            }



            public void AfficherCv()
            {
                Console.WriteLine();
                Console.WriteLine($"{Titre} {Prenom} {Nom}");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Scolarite :");
                foreach (var School in SchoolList)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Nom de l'institution      : {School.NomEcole}");
                    Console.WriteLine($"Cours Suivi               : {School.CoursSuivi}");
                    Console.WriteLine($"Annee debut des cours     : {School.AnneeDepart}");
                    Console.WriteLine($"Annee fin des cours       : {School.AnneeFin}");
                    Console.WriteLine($"Prestige de l'institution : {School.Prestige}");

                }

                Console.WriteLine();
                Console.WriteLine($"Emplois Occupees");
                foreach (var Job in Experience)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Nom de l'entreprise       : {Job.NomEntreprise}");
                    Console.WriteLine($"Cours Suivi               : {Job.Poste}");
                    Console.WriteLine($"Annee debut des cours     : {Job.AnneeDepart}");
                    Console.WriteLine($"Annee fin des cours       : {Job.AnneeFin}");

                }
            }



            public void CompareCv(CV autreCv)
            {
                int myPrestige = 0;
                int hisPrestige = 0;
                foreach (var school in SchoolList)
                {
                    myPrestige += school.Prestige;
                }

                foreach (var school in autreCv.SchoolList)
                {
                    hisPrestige += school.Prestige;
                }

                myPrestige = myPrestige + (5 * Experience.Count);
                hisPrestige = hisPrestige + (5 * autreCv.Experience.Count);

                if (myPrestige > hisPrestige)
                {
                    Console.WriteLine($"{Prenom} {Nom} has a better Resume with a score of {myPrestige}!");
                    Console.WriteLine($"{autreCv.Prenom} {autreCv.Nom} had a score of {hisPrestige}!");
                }
                else
                {
                    Console.WriteLine($"{autreCv.Prenom} {autreCv.Nom} has a better Resume with a score of {hisPrestige}!");
                    Console.WriteLine($"{Prenom} {Nom} had a score of {myPrestige}!");
                }
            }
        }



        public struct Ecole
        {
            public string NomEcole;
            public string CoursSuivi;
            public int AnneeDepart;
            public int AnneeFin;
            public int Prestige; //1 a 10

            public Ecole(string school, string courses, int startYear, int endYear, int evalSchool)
            {
                NomEcole = school;
                CoursSuivi = courses;
                AnneeDepart = startYear;
                AnneeFin = endYear;
                Prestige = evalSchool;
            }
        }
        public struct ExperienceProfessionelle
        {
            public string NomEntreprise;
            public string Poste;
            public int AnneeDepart;
            public int AnneeFin;

            public ExperienceProfessionelle(string name, string station, int startYear, int endYear)
            {
                NomEntreprise = name;
                Poste = station;
                AnneeDepart = startYear;
                AnneeFin = endYear;
            }


        }



        //################################################# EXERCICE 98 ######################################//
        //################################################# EXERCICE 98 ######################################//
        //################################################# EXERCICE 98 ######################################//


        public static CV MeilleurCvDuneListe(ref List<CV> listeCvs)
        {
            int bestscore = 0;
            CV meilleurCv = new CV();
            foreach (var cv in listeCvs.ToList())
            {
                cv.CalculeleScore();
                if (cv.CalculeleScore() > bestscore)
                {
                    meilleurCv = cv;
                    bestscore = cv.CalculeleScore();
                }
            }

            return meilleurCv;
        }


        private static void S()
        {
            Console.WriteLine();
        }


        //################################################# EXERCICE SWITCH ######################################//
        //################################################# EXERCICE SWITCH ######################################//
        //################################################# EXERCICE SWITCH ######################################//

        private static void ExSwitch()
        {

            do
            {
                Console.WriteLine($"        ╔═══════════════╦════════════════════════════════════════════════════╗");
                Console.WriteLine($"        ║TODO OPTIONS 1 ║ EXERCICE 96 : AFFICHER TOUT LES CV                 ║");
                Console.WriteLine($"        ║             2 ║ EXERCICE 97 : COMPARER DEUX CV                     ║");
                Console.WriteLine($"        ║             3 ║ EXERCICE 98 : MEILLEUR CV D UNE LISTE              ║");
                Console.WriteLine($"        ║             4 ║ EXIT PROGRAM                                       ║");
                Console.WriteLine($"        ╚═══════════════╩════════════════════════════════════════════════════╝");
                Console.Write($"            Choice :");
                int choice;
                do
                {
                    while (int.TryParse(Console.ReadLine(), out choice) == false)
                    {

                    }
                } while (choice < 1 | choice > 5);
                Console.Clear();
                switch (choice)
                {
                    case 2:
                        InitCompare();
                        S();
                        S();
                        break;
                    case 3:
                        InitCvListCompair();
                        S();
                        S();
                        break;
                    case 1:
                        InitAfficherCv();
                        S();
                        S();
                        break;
                    case 4:
                        Environment.Exit(1);
                        break;
                }
            } while (true);


        }


        public static List<CV> Postulants()
        {
            List<CV> listPostulants = new List<CV>();
            CV alex = new CV("Mr.", "Caron", "Alexandre",
                new List<Ecole>
                {
                    new Ecole("Jardins Enchantees", "Pre-Maternelle", 1987, 1989, 6),
                    new Ecole("St-Marie", "Primaire", 1989, 1995, 9),
                    new Ecole("Val-Maurice", "Secondaire", 1995, 2000, 6),
                    new Ecole("Cegep Shawinigan", "Sciences Humaines", 2001, 2002, 7),
                    new Ecole("Cegep FXGarneau", "Science Humaines", 2006, 2008, 9),
                    new Ecole("Bishops University", "Management", 2010, 2013, 10),

                },
                new List<ExperienceProfessionelle>
                {
                    new ExperienceProfessionelle("Saputo","Operateur",2001,2007),
                    new ExperienceProfessionelle("Oceans Choice","Traducteur",2008,2010),
                    new ExperienceProfessionelle("Comfort Inn","Comptable",2010,2011),
                    new ExperienceProfessionelle("Trou Du Diable","Represantant",2011,2012),
                    new ExperienceProfessionelle("Fin Quartier","Gerant Poissonnerie",2014,2016),
                    new ExperienceProfessionelle("Metro","Gerant Poissonnnerie",2016,2017),
                });
            CV bob = new CV("Mr.", "Latourette", "Bobby",
                new List<Ecole>
                {
                    new Ecole("St-Tabernacle", "Primaire", 1989, 1995, 9),
                    new Ecole("Val-Osti", "Secondaire", 1995, 2000, 6),
                    new Ecole("Cegep Mange Dla Marde", "Sciences MMMKAY", 2001, 2002, 7),
                    new Ecole("DEP", "Soudure", 2006, 2008, 9),

                },
                new List<ExperienceProfessionelle>
                {
                    new ExperienceProfessionelle("Travailleur Autonome","Tondage de Pelouse en Vrack sti",2008,2018),
                });
            listPostulants.Add(alex);
            listPostulants.Add(bob);
            return listPostulants;
        }

        static void Main(string[] args)
        {
            ExSwitch();


        }



        private static void InitAfficherCv()
        {
            List<CV> kMaListe = Postulants();
            foreach (var cv in kMaListe)
            {
                cv.AfficherCv();
                Console.ReadLine();
            }
        }



        private static void InitCvListCompair()
        {
            List<CV> kMaListe = Postulants();
            CV Best = MeilleurCvDuneListe(ref kMaListe);
            Console.WriteLine($"{Best.Prenom} {Best.Nom}  a le meilleur cv avec un score de {Best.CvScore}");
        }



        private static void InitCompare()
        {
            List<CV> kMaListe = Postulants();
            kMaListe[0].CompareCv(kMaListe[1]);
        }
    }
}
