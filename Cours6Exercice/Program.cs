using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Net.Sockets;

namespace Cours6Exercice
{


    internal class Clients
    {
        internal string Names { get; set; }
        internal string CashAvailorNo { get; set; }
    }

    internal class ClientDonutsProcessed
    {
        internal bool Yaundonut { get; set; }
        internal string Names { get; set; }
        internal string CashAvailorNo { get; set; }
    }





    class Program

    {
        private static readonly Random R = new Random();
        private static readonly Random R2 = new Random();

        private static Dictionary<string, Dictionary<string, List<string>>> ServerTODO;





        //#################################################################################################//
        //############################################## 61 ###############################################//
        //#################################################################################################//

        // Exercice 61 List Module
        private static List<int> Createint()
        {
            int ListSize = R.Next(1, 250);
            List<int> MagicRnumbers = new List<int>();
            for (int x = 0; x < ListSize; ++x)
            {
                MagicRnumbers.Add(x);
            }
            return MagicRnumbers;
        }

        // Exercice 61 Split a int list odd/even with a key true or false 
        private static void AfficherBonsElements(ref SortedList<int, bool> Booledint) // if i feel like using it later
        {
            List<int> TheList = Createint();

            foreach (int i in TheList)
            {
                if ((i % 2) != 0)
                {
                    Booledint.Add(i, false);
                }
                else
                {
                    Booledint.Add(i, true);
                }
            }

            foreach (var i in Booledint)
            {
                if (i.Value)
                {
                    Console.WriteLine($"{i.Key}, {i.Value}");
                }
            }
        }

        private static void InitializeAfficherBonElements()
        {
            SortedList<int, bool> SortedIntODDEVEN = new SortedList<int, bool>();
            AfficherBonsElements(ref SortedIntODDEVEN);
        }

        //#################################################################################################//
        //############################################## 62 ###############################################//
        //#################################################################################################//

        //Exercice 62 Creation of a Pile
        private static Stack<int> CreationOfRandPileint()
        {
            int ListSize = R.Next(5, 25000);
            Stack<int> MagicRnumbers = new Stack<int>();
            for (int x = 0; x < ListSize; ++x)
            {
                MagicRnumbers.Push(R.Next(1, 19999));
            }
            return MagicRnumbers;
        }




        //Exercice 62 Recursive unstacking of a copy till exeption
        private static int UnStack(Stack<int> stack, int count)
        {
            Stack<int> Copy = stack; // copy so its not destroyed then push it tru the function

            try
            {
                Copy.Pop();
                Console.WriteLine(Copy.Peek());
                ++count;
            }
            catch(System.Exception)
            {
                return count;
            }
            //catch (Exception ex)
            //{
            //    if (ex is StackOverflowException || ex is InvalidOperationException)
            //    {
                  
            //        return count;
            //    }
            //}

            return UnStack(Copy, count);

        }


        //Exercice 62 Init
        private static void InitializeUnStack()
        {
            Stack<int> PileOfDoom = CreationOfRandPileint();
            int Count = UnStack(PileOfDoom, 0);
            s();
            s();
            Console.WriteLine($"There is {Count} Elements in the Pile ");
        }




        //#################################################################################################//
        //############################################## 63-64 ############################################//
        //#################################################################################################//

        // Exercice 64 Meh i used a streamreader BUT it does get a new string[] in the queue haha
        private static List<string> NamesClients()
        {
            string OneLine;
            List<string> Noms = new List<string>();
            StreamReader SanchoBobReadsText = new StreamReader("names.txt"); //32868 names that 5 or more baby had been given in USA in 2016
            while ((OneLine = SanchoBobReadsText.ReadLine()) != null)
            {
                string[] SplittedLine = OneLine.Split(',');             //splitting at , i dont want the rest
                Noms.Add(SplittedLine[0]);
            }
            return Noms;
        }



        // Money generation module 
        private static double DoubleRand(double minimum, double maximum)
        {
            return R.NextDouble() * (maximum - minimum) + minimum;
        }

        // Exercice 63 create pocket money randomly for my 32858 persons in the stack
        private static string ClientPockets()
        {
            string ClientActualMoney;
            double Max = 44.75;
            double Min = 0.11;
            string NoMonies = "Pasdargent";
            int nomoney = R.Next() % 50; // meh its arbitrary haha

            if (nomoney != 0)                                               // for all those having money
                return ClientActualMoney = DoubleRand(Min, Max).ToString();

            else                                                             // thoses with none
                return NoMonies.ToString();
        }


        // Exercice 63 Creation of the FULL clients
        private static Queue<Clients> FullClientCreation()
        {
            Queue<Clients> ClientAvecSonArgent = new Queue<Clients>();
            List<string> ClientsN = NamesClients();                         // Using Name Module wioth StreamReader
            int Counter = 0;

            do
            {
                ClientAvecSonArgent.Enqueue(new Clients { Names = ClientsN[Counter], CashAvailorNo = ClientPockets() }); // adding name to each and money and enqueue them
                ++Counter;

            } while (Counter < ClientsN.Count);


            foreach (var x in ClientAvecSonArgent)          //funfun
            {
                Console.WriteLine($"{x.Names},{x.CashAvailorNo}");
            }
            return ClientAvecSonArgent;
        }




        // Exercice 63 ... Abusive version of Tim Horton with a shitty employee
        private static List<ClientDonutsProcessed> TraiterProchainClient(Queue<Clients> RouletteRusseDesDonuts)
        {
            var MesClientsOntTuUnDonut = new List<ClientDonutsProcessed>(); // Could have juste added the new value to Client Class but wheres the fun
            int Counter = RouletteRusseDesDonuts.Count;
            while (Counter != 0)
            {
                int MonEmployeQuiVaSeFaireRevoyer = R.Next() % 10;                          //Employee giving my donuts

                if (RouletteRusseDesDonuts.Peek().CashAvailorNo.ToString() == "Pasdargent") // When they have no money
                {

                    if (MonEmployeQuiVaSeFaireRevoyer != 1)                                 // Employee not getting fired
                    {
                        MesClientsOntTuUnDonut.Add(new ClientDonutsProcessed()
                        {
                            Names = RouletteRusseDesDonuts.Peek().Names,

                            CashAvailorNo =
                           RouletteRusseDesDonuts.Peek().CashAvailorNo,

                            Yaundonut = false
                        });

                        RouletteRusseDesDonuts.Dequeue();                                   //Sending him back to the back
                        --Counter;
                    }


                    else if (MonEmployeQuiVaSeFaireRevoyer == 1)                            //Employee giving my good away hes now FIRED
                    {

                        MesClientsOntTuUnDonut.Add(new ClientDonutsProcessed()
                        {
                            Names = RouletteRusseDesDonuts.Peek().Names,
                            CashAvailorNo =
                           RouletteRusseDesDonuts.Peek().CashAvailorNo,
                            Yaundonut = true
                        });

                        RouletteRusseDesDonuts.Dequeue();
                        --Counter;
                    }
                }


                else                                                                        // They have monies
                {
                    MesClientsOntTuUnDonut.Add(new ClientDonutsProcessed()
                    {
                        Names = RouletteRusseDesDonuts.Peek().Names,
                        CashAvailorNo =
                           RouletteRusseDesDonuts.Peek().CashAvailorNo,
                        Yaundonut = true
                    });

                    RouletteRusseDesDonuts.Dequeue();
                    --Counter;
                }
            }
            return MesClientsOntTuUnDonut;
        }



        // Exercice 63 donuuuuttttttt
        static void InitializeDonutRand()
        {
            int yaundonut = 0;
            int yapasdonut = 0;
            var ClientsEnLigne = FullClientCreation();
            List<ClientDonutsProcessed> ClientAKuneBeigneVF = TraiterProchainClient(ClientsEnLigne);

            foreach (var b in ClientAKuneBeigneVF)
            {
                if (b.Yaundonut != false)
                {
                    ++yaundonut;
                }
                else if (b.Yaundonut == false)
                {
                    ++yapasdonut;
                }
            }
            Console.WriteLine($"{yaundonut} Clients on un donut!");
            Console.WriteLine($"{yapasdonut} Clients ont perdu leurs temps en tbk et ont pas de donut!");
            Console.ReadLine();
        }



        //#################################################################################################//
        //############################################## 65 ###############################################//
        //#################################################################################################//


        // Create a Database of TODO in my "Database"#server
        private static void CreateTodoDB()
        {
            Console.WriteLine("New TODO Database Name ?: ");
            string NewDataBaseName = Console.ReadLine().ToUpper(); // Upper make it more consistant

            if (ServerTODO.ContainsKey(NewDataBaseName) | NewDataBaseName == null) // Already one named this way ?
            {
                Console.WriteLine("Database Already Exist!");
                return;
            }

            else
            {
                Thread.Sleep(200);
                // Add new Database to Server
                ServerTODO.Add(NewDataBaseName, new Dictionary<string, List<string>>());
                Console.WriteLine($"DataBase {NewDataBaseName} Created !");
            }
        }

        // Exercice 65 User Creation
        private static void ToDoUserCreation()
        {
            Console.WriteLine("TODO DataBase to Use : ");
            string ChoosedDataBase = Console.ReadLine().ToUpper();

            if (ServerTODO.ContainsKey(ChoosedDataBase))                    // Does Database Exist 
            {

                Console.WriteLine($"Using {ChoosedDataBase} DataBase!");
                Thread.Sleep(200);
                s();


                Console.WriteLine("Name new User : ");
                string NewUsername = Console.ReadLine().ToUpper();

                if (!ServerTODO[ChoosedDataBase].ContainsKey(NewUsername)) //Check if the User is not in use in the choosen Database
                {
                    ServerTODO[ChoosedDataBase].Add(NewUsername, new List<string>());     // it is not Create User
                    Thread.Sleep(200);
                    Console.WriteLine($"User {NewUsername} Created !");
                }

                else
                {
                    Console.WriteLine($"User {NewUsername} already exist!");              //it is return
                    return;
                }
            }
            else                                                                    // Database Does not Exist
            {
                Console.WriteLine($"DataBase {ChoosedDataBase} does not exist!");
            }
        }



        // Exercice 65 Set User and DataBase so they dont have to "Log in" everytime theres a todo to add or remove
        private static List<Clients> SetTodoDBuser(List<Clients> SetClient)
        {
            Console.WriteLine("Set Database to use to : ");
            string Databaseset = Console.ReadLine().ToUpper();

            if (!ServerTODO.ContainsKey(Databaseset))               //Does Datatbase Exist
            {
                Console.WriteLine($"DataBase {Databaseset} does not exist!");  //Does not
                TODOMENU();
            }
            else
            {
                Thread.Sleep(200);                                            // Does (i lie i set it at the end)
                Console.WriteLine($"Setted Datatbase to {ServerTODO}!");
                Console.WriteLine();
            }

            Console.WriteLine("Set User Name to : ");
            string Userset = Console.ReadLine().ToUpper();


            if (ServerTODO[Databaseset].ContainsKey(Userset)) //Check if the User Exist
            {
                Thread.Sleep(200);                                                              //it is Setting the DB and User in a list
                Console.WriteLine($"Setted User is {Userset}!");
                SetClient.Add(new Clients() { Names = Databaseset, CashAvailorNo = Userset });
            }
            else
            {
                Console.WriteLine($"User {Userset} does not exist!");    //Does not
                TODOMENU();
            }
            return SetClient;
        }




        // Exercice 65 Adding a TODO (EASIEST PART OF THAT THING)
        private static void AddTodoUser(List<Clients> UserData)
        {

            if (UserData.Count == 0) // GateCheck // Hate it when it crash.... i mean a lot
            {
                Console.WriteLine("You need to set a DataBase and a User !");
                return;
            }
            else             // Lets ADD something
            {
                Console.WriteLine("Task To Add to TODO : ");

                string task = Console.ReadLine();


                ServerTODO[UserData[0].Names][UserData[0].CashAvailorNo].Add(task);               // Well thats about it its a String List 
                Console.WriteLine($"Tsak - {task} - Has been added to TODO of {UserData[0].CashAvailorNo}");
            }
        }



        // Exercice 65 Visual of TODO Entered
        private static void ShowTODO(List<Clients> Users)
        {

            if (Users.Count == 0) //Gateway
            {
                Console.WriteLine("You need to set a DataBase and a User !");
                return;
            }

            else
            {
                int counter = 1; //Well Counter Make it Cleaner than putting something starting 0

                //Such wow , <doge> , Much Hello World , Many HTML , wow , Very Computer, Such Programming
                //Wow how Skill , Much Click, return Doge;
                Console.WriteLine(@"╔════════════════════════════════════════════════════════════════════╗");
                foreach (var c in ServerTODO[Users[0].Names][Users[0].CashAvailorNo])
                {
                    Console.SetCursorPosition(0, Console.CursorTop = counter);
                    Console.Write($"║ {counter} -- {c}");
                    Console.SetCursorPosition(69, Console.CursorTop = counter);
                    Console.Write($"║");
                    ++counter;
                }
                Console.SetCursorPosition(0, Console.CursorTop = counter);
                Console.WriteLine(@"╚════════════════════════════════════════════════════════════════════╝");
            }

        }



        //Exercice 65 Removing element from TODO
        private static void RemoveTODO(List<Clients> Users)
        {

            if (Users.Count == 0) // Gateway
            {
                Console.WriteLine("You need to set a DataBase and a User !");
                return;
            }

            else
            {
                Console.Write($"Witch one do you want to delete ?:");
                int choice;
                do
                {
                    while (int.TryParse(Console.ReadLine(), out choice) == false) ;
                } while (choice < 1 | choice > ServerTODO[Users[0].Names][Users[0].CashAvailorNo].Count); // Making sure user isent autistic and goes over the todo he has



                int counter = 1;
                foreach (var c in ServerTODO[Users[0].Names][Users[0].CashAvailorNo].ToList()) // TOLIST SO IT DOES NOT CRASH
                {
                    if (counter == choice)                  // Counter and choice in Symbiosys
                    {
                        ServerTODO[Users[0].Names][Users[0].CashAvailorNo].Remove(c);  // Removing element 
                        break;                                                         // Breaking so it does not break something else
                    }
                    else
                        ++counter;
                }
            }
        }




        // Juist a Menu id take 3 pizza plz
        private static void TODOMENU()
        {
            List<Clients> USER = new List<Clients>();
            do
            {
                Console.WriteLine($"        ╔═══════════════╦════════════════════════════════════════════════════╗");
                Console.WriteLine($"        ║TODO OPTIONS 1 ║ ADD TODO                                           ║");
                Console.WriteLine($"        ║             2 ║ SHOW TODO                                          ║");
                Console.WriteLine($"        ║             3 ║ DELETE TODO                                        ║");
                Console.WriteLine($"        ║             4 ║ CREATE DATABASE                                    ║");
                Console.WriteLine($"        ║             5 ║ CREATE USER (REQUIRE DATABASE TO BE CREATED)       ║");
                Console.WriteLine($"        ║             6 ║ SET USER/DATABASE                                  ║");
                Console.WriteLine($"        ║             7 ║ FUCK LES TODO VIVE LES DONUTS                      ║");
                Console.WriteLine($"        ║             8 ║ UNSTACKING OF PILE                                 ║");
                Console.WriteLine($"        ║             9 ║ AFFICHERBONSELEMENTS                               ║");
                Console.WriteLine($"        ╚═══════════════╩════════════════════════════════════════════════════╝");
                Console.Write($"            Choice :");
                int choice;
                do
                {
                    while (int.TryParse(Console.ReadLine(), out choice) == false) ;
                } while (choice < 1 | choice > 10);
                Console.Clear();
                switch (choice)
                {
                    case 4:
                        CreateTodoDB();
                        s();
                        s();
                        break;
                    case 5:
                        ToDoUserCreation();
                        s();
                        s();
                        break;
                    case 6:
                        USER = SetTodoDBuser(USER);
                        s();
                        s();
                        break;
                    case 1:
                        AddTodoUser(USER);
                        s();
                        s();
                        break;
                    case 2:
                        ShowTODO(USER);
                        s();
                        s();
                        break;
                    case 3:
                        RemoveTODO(USER);
                        s();
                        s();
                        break;
                    case 7:
                        InitializeDonutRand();
                        s();
                        s();
                        break;
                    case 8:
                        InitializeUnStack();
                        s();
                        s();
                        break;
                    case 9:
                        InitializeAfficherBonElements();
                        s();
                        s();
                        break;
                }
            } while (true);

        }




        private static void initializeDBtodo()
        {
            ServerTODO = new Dictionary<string, Dictionary<string, List<string>>>();
        }

        private static void s()
        {
            Console.WriteLine();
        }


        static void Main(string[] args)
        {


            TODOMENU();
        }

    }
}

