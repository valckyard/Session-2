using System;
using System.Threading;

namespace Cours9Exercice
{

    internal enum Races
    {
        Humain,
        Elfe,
        Orc,
    }
    internal enum Names
    {
        PetroCan,
        Esso,
        Eko,
        UltraMar,
        LeDepDuCoin,
        CoopEtudiante
    }




    //PERS STRUCT EXERCICE 91
    internal struct Personnage
    {
        internal Names Nom;
        internal Races Race;
        internal int HitPoint;
        internal int Attack;
        internal int Defense;


        //PERS CONSTRUCTOR EXERCICE 91
        internal Personnage(Names name, Races myRace, int hP, int atk, int def)
        {
            Nom = name;
            Race = myRace;
            HitPoint = hP;
            Attack = atk;
            Defense = def;
        }


        //EXERCICE 91
        internal int PowerUp()
        {

            Console.WriteLine("POWERUP!");
            Attack = Attack * 2;

            return Attack;
        }

        //EXERCICE HMM FUN 
        internal int PowerDown()
        {

            Console.WriteLine("POWERDOWN!");
            Attack = Attack / 2;

            return Attack;
        }

        //EXERCICE 91
        internal bool AmIDead()
        {
            if (HitPoint > 0)
                return true;
            return false;

        }

        //RANDOM PERS CREATION
        internal Personnage CreateRandomPersonnage()
        {
            Names zeName = (Names)Program.R.Next(0, 6);
            Races randRace = (Races)Program.R.Next(0, 3);
            int randHp = Program.R.Next(1, 101);
            int randAtk = Program.R.Next(1, 10);
            int randDef = Program.R.Next(1, 10);

            Personnage randPers = new Personnage(zeName, randRace, randHp, randAtk, randDef);
            return randPers;
        }


        //EXERCICE 91
        internal void AfficherPersonnage()
        {
            Console.WriteLine($"Nom : {Nom}");
            Console.WriteLine($"Race : {Race}");
            Console.WriteLine($"hP : {HitPoint}");
            Console.WriteLine($"atk : {Attack}");
            Console.WriteLine($"def : {Defense}");
        }


        //FRAPPER AUTRE PERSONNE EXERCICE 92
        internal Personnage FrapperUnAutrePers(ref Personnage defender)
        {
            int dmg = Attack - defender.Defense;
            if (dmg <= 0)
                dmg = 1;

            Console.WriteLine($"{Nom} Attacks {defender.Nom} for {dmg} !");


            Console.Write($"{defender.Nom} hP: {defender.HitPoint} hP ====>");
            defender.HitPoint = defender.HitPoint - dmg;
            Console.WriteLine($" {defender.HitPoint} hP!");

            Console.WriteLine();

            return defender;
        }


    }





    class Program
    {
        public static Random R = new Random();




        //################################################# FIGHT TO DEATH  93/94 #############################################//
        //################################################# FIGHT TO DEATH  93/94 #############################################//
        //################################################# FIGHT TO DEATH  93/94 #############################################//




        private static void PersonnageToDeath()
        {

            Personnage hero = new Personnage().CreateRandomPersonnage();
            Personnage ennemi = new Personnage().CreateRandomPersonnage();
            int persAttacking = R.Next(1, 3);
            do
            {
                int powerUpChance = R.Next(0, 20);
                switch (persAttacking)
                {

                    case 1:
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            if (powerUpChance == 0)
                                hero.PowerUp();
                            if (powerUpChance == 19)
                                ennemi.PowerDown();
                            hero.FrapperUnAutrePers(ref ennemi);
                        }
                        break;
                    case 2:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            if (powerUpChance == 0)
                                ennemi.PowerUp();
                            if (powerUpChance == 19)
                                ennemi.PowerDown();
                            ennemi.FrapperUnAutrePers(ref hero);
                        }

                        break;
                }

                if (persAttacking == 1)
                {
                    persAttacking = 2;
                }
                else
                {
                    persAttacking = 1;

                }

                Thread.Sleep(555);
            } while (ennemi.AmIDead() & hero.AmIDead());

            Console.ForegroundColor = ConsoleColor.Gray;
            if (hero.HitPoint <= 0)
            {
                Console.WriteLine($"{ennemi.Nom} Won with {ennemi.HitPoint} hP");
            }
            else
            {
                Console.WriteLine($"{hero.Nom} Won with {hero.HitPoint} hP");
            }
        }





        //################################################# FRAPPER AUTRE PERSONNAGE 92 #############################################//
        //################################################# FRAPPER AUTRE PERSONNAGE 92 #############################################//
        //################################################# FRAPPER AUTRE PERSONNAGE 92 #############################################//




        private static void TwoRandPers()
        {
            Personnage hero = new Personnage().CreateRandomPersonnage();
            Personnage ennemi = new Personnage().CreateRandomPersonnage();

            hero.FrapperUnAutrePers(ref ennemi);
        }




        //################################################# ALL STRUCT FUNCTIONS 91 #############################################//
        //################################################# ALL STRUCT FUNCTIONS 91 #############################################//
        //################################################# ALL STRUCT FUNCTIONS 91 #############################################//




        private static void PersTest()
        {

            Personnage myPers = new Personnage().CreateRandomPersonnage();
            myPers.AfficherPersonnage();

            Console.WriteLine();
            Console.WriteLine($"Is {myPers.Nom} still alive?");
            Console.WriteLine(myPers.AmIDead());


            Console.WriteLine();
            myPers.PowerUp();

            Console.WriteLine();
            myPers.AfficherPersonnage();

            Console.WriteLine();
            myPers.PowerDown();
            myPers.HitPoint = 0;
            Console.WriteLine();
            myPers.AfficherPersonnage();

            Console.WriteLine();
            Console.WriteLine($"Is {myPers.Nom} still alive?");

            Console.WriteLine(myPers.AmIDead());
            Console.WriteLine();

        }


        private static void S()
        {
            Console.WriteLine();
        }




        private static void ExSwitch()
        {

            do
            {
                Console.WriteLine($"        ╔═══════════════╦════════════════════════════════════════════════════╗");
                Console.WriteLine($"        ║TODO OPTIONS 1 ║ EXERCICE 91 : PERSONNAGES STRUCT AND FUNCTIONS     ║");
                Console.WriteLine($"        ║             2 ║ EXERCICE 92 : HIT AN ENNEMY                        ║");
                Console.WriteLine($"        ║             3 ║ EXERCICE 93/94 : FIGHT BETWEEN 2 RANDOM CHARACTERS ║");
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
                    case 1:
                        PersTest();
                        S();
                        S();
                        break;
                    case 2:
                        TwoRandPers();
                        S();
                        S();
                        break;
                    case 3:
                        PersonnageToDeath();
                        S();
                        S();
                        break;
                    case 4:
                        Environment.Exit(1);
                        break;
                }
            } while (true);


        }
        static void Main()
        {
            ExSwitch();

        }
    }
}