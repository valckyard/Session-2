using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

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

        private static Dictionary<string, Dictionary<string, List<string>>> Database;



        private static double DoubleRand(double minimum, double maximum)
        {
            return R.NextDouble() * (maximum - minimum) + minimum;
        }

        private static List<int> CreationOfRandInt()
        {
            int ListSize = R.Next(5, 25);
            List<int> MagicRnumbers = new List<int>();
            for (int x = 0; x < ListSize; ++x)
            {
                MagicRnumbers.Add(R.Next(1, 1445));
            }
            return MagicRnumbers;
        }

        //61
        private static void AfficherBonsElements(SortedList<bool, int> Booledint)
        {
            List<int> TheList = CreationOfRandInt();

            foreach (int i in TheList)
            {
                if (i % 2 != 0)
                {
                    Booledint.Add(false, i);
                }
                else
                {
                    Booledint.Add(true, i);
                }
            }

            foreach (var i in Booledint)
            {
                if (i.Key)
                {
                    Console.WriteLine($"{i.Key}, {i.Value}");
                }
            }
        }




        private static Stack<int> CreationOfRandPileint()
        {
            int ListSize = R.Next(5, 6363);
            Stack<int> MagicRnumbers = new Stack<int>();
            for (int x = 0; x < ListSize; ++x)
            {
                MagicRnumbers.Push(R.Next(1, 7000));
            }
            return MagicRnumbers;
        }




        //62
        private static int UnStack(Stack<int> stack)
        {
            int NotCountButCount = 0;
            bool Houston = true;
            do
            {
                Houston = stack.Contains(NotCountButCount);
                if (Houston)
                    ++NotCountButCount;

            } while (Houston);
            return NotCountButCount;
        }



        private static List<string> NamesClients()
        {
            string ZaLigne;
            List<string> Noms = new List<string>();
            StreamReader SanchoBob = new StreamReader("names.txt");
            while ((ZaLigne = SanchoBob.ReadLine()) != null)
            {
                string[] SplittedLine = ZaLigne.Split(',');
                Noms.Add(SplittedLine[0]);
            }
            return Noms;
        }




        private static string ClientPockets()
        {
            string ClientActualMoney;
            double Max = 44.75;
            double Min = 0.11;
            string NoMonies = "Pasdargent";
            int nomoney = R.Next() %50;

            if (nomoney != 0)
                return ClientActualMoney = DoubleRand(Min, Max).ToString();

            else
                return NoMonies.ToString();
        }

        private static Queue<Clients> FullClientCreation()
        {
            Queue<Clients> ClientAvecSonArgent = new Queue<Clients>();
            List<string> ClientsN = NamesClients();
            int Counter = 0;
            do
            {
                ClientAvecSonArgent.Enqueue(new Clients { Names = ClientsN[Counter] , CashAvailorNo = ClientPockets() });
                ++Counter;
            } while (Counter < ClientsN.Count);
            foreach (var x in ClientAvecSonArgent)
           {
                Console.WriteLine($"{x.Names},{x.CashAvailorNo}");
            }
            return ClientAvecSonArgent;
        }



        //63

        private static List<ClientDonutsProcessed> TraiterProchainClient(Queue<Clients> RouletteRusseDesDonuts)
        {
            var MesClientsOntTuUnDonut = new List<ClientDonutsProcessed>();
            int Counter = 32868;
            while (Counter  != 0)
            {
                int MonEmployeQuiVaSeFaireRevoyer = R.Next() % 10; // 1 sur 10 des gens qui ont pas d argent on une beigne gratis
                if (RouletteRusseDesDonuts.Peek().CashAvailorNo.ToString() == "Pasdargent") //0
                {
                    if (MonEmployeQuiVaSeFaireRevoyer != 1)
                    {
                        MesClientsOntTuUnDonut.Add(new ClientDonutsProcessed()
                        {
                            Names = RouletteRusseDesDonuts.Peek().Names,

                            CashAvailorNo =
                           RouletteRusseDesDonuts.Peek().CashAvailorNo,

                            Yaundonut = false
                        });
                        RouletteRusseDesDonuts.Dequeue();
                        --Counter;
                    }


                    else if (MonEmployeQuiVaSeFaireRevoyer == 1)
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


                else
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
                else if(b.Yaundonut == false)
                {
                    ++yapasdonut;
                }
            }
            Console.WriteLine($"{yaundonut} Clients on un donut!");
            Console.WriteLine($"{yapasdonut} Clients ont perdu leurs temps en tbk et ont pas de donut!");
            Console.ReadLine();
        }

        private static void CreateTodoDB()
        {
            Console.WriteLine("TODO DB Name ?: ");
            string DBNAME =Console.ReadLine();
            Thread.Sleep(200);
            Dictionary<string, List<string>> UserDB = new Dictionary<string, List<string>>();
            Database.Add(DBNAME, new Dictionary<string, List<string>>());
        }

        private static void ToDoUserCreation()
        {
            Console.WriteLine("DB ti Use : ");
            string DBCHoose = Console.ReadLine();
          var exist = Database.ContainsKey(DBCHoose);
            if (exist)
            {
                Console.WriteLine("Name new User : ");
               string NewUsername = Console.ReadLine();
                Database[DBCHoose].Add(NewUsername, new List<string>());
                Thread.Sleep(200);
                Console.WriteLine($"User {NewUsername} Created !");
            }
            else
            {
                Console.WriteLine($"Db {DBCHoose} does not exist!");
            }
        }

        private static List<Clients> SetTodoDBuser(List<Clients> SetClient)
        {
            Console.WriteLine("Set Database to use to : ");
            string Databaseset = Console.ReadLine();
            Thread.Sleep(200);
            Console.WriteLine($"Setted Datatbase to {Database}!");
            Console.WriteLine();
            Console.WriteLine("Set User Name to : ");
            string Userset = Console.ReadLine();
            Thread.Sleep(200);
            Console.WriteLine($"Setted User is {Userset}!");
            SetClient = new List<Clients>();
            SetClient.Add(new Clients() { Names = Databaseset, CashAvailorNo = Userset });
            return SetClient;
        }





        private static void AddTodoUser(List<Clients> UserData)
        {
            Console.WriteLine("Task To Add to TODO : ");

            string task = Console.ReadLine();


            Database[UserData[0].Names][UserData[0].CashAvailorNo].Add(task);
            Console.WriteLine($"Tsak - {task} - Has been added to TODO of {UserData[0].CashAvailorNo}");
        }




        private static void ShowTODO(List<Clients> Users)
        {
            int counter = 1;
            foreach(var c in Database[Users[0].Names][Users[0].CashAvailorNo])
            {
                Console.WriteLine($"{counter} -- {c}");
                ++counter;
            }
        }
       

        private static void RemoveTODO(List<Clients> Users)
        {
            Console.Write($"Witch one do you want to delete ?:");
            int choice;
            do
            {
                while (int.TryParse(Console.ReadLine(), out choice) == false) ;
            } while (choice < 1 | choice > Database[Users[0].Names][Users[0].CashAvailorNo].Count);

            int counter = 1;
            foreach (var c in Database[Users[0].Names][Users[0].CashAvailorNo].ToList())
            {
                if (counter == choice)
                { Database[Users[0].Names][Users[0].CashAvailorNo].Remove(c);
                break; }
                // Console.WriteLine($"{counter} -- {c}");
                else
                ++counter;
            }
        }



        private static void TODOMENU()
        {
            List<Clients> USER = new List<Clients>();
            do
            {
                Console.WriteLine($"DB OPTIONS 1 - CREATE DATABASE");
                Console.WriteLine($"           2 - CREATE USER (REQUIRE DATABASE TO BE CREATED)");
                Console.WriteLine($"           3 - SET USER/DATABASE");
                Console.WriteLine($"           4 - ADD TODO");
                Console.WriteLine($"           5 - SHOW TODO");
                Console.WriteLine($"           6 - DELETE TODO not done");
                Console.WriteLine($"           7 - FUCK LES TODO VIVE LES DONUTS");
                Console.WriteLine($"-------------------------------------");
                Console.Write($"Choice :");
                int choice;
                do
                {
                    while (int.TryParse(Console.ReadLine(), out choice) == false) ;
                } while (choice < 1 | choice > 8);
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        CreateTodoDB();
                        s();
                        s();
                        break;
                    case 2:
                        ToDoUserCreation();
                        s();
                        s();
                        break;
                    case 3:
                        USER = SetTodoDBuser(USER);
                        s();
                        s();
                        break;
                    case 4:
                        AddTodoUser(USER);
                        s();
                        s();
                        break;
                    case 5:
                        ShowTODO(USER);
                        s();
                        s();
                        break;
                    case 6:
                        RemoveTODO(USER);
                        s();
                        s();
                        break;
                    case 7:
                        InitializeDonutRand();
                        s();
                        s();
                        break;
                }
            } while (true);

            }
	

	

        private static void initializeDBtodo()
        {
            Database = new Dictionary<string, Dictionary<string, List<string>>>();
        }

        private static void s()
        {
            Console.WriteLine();
        }
    

        static void Main(string[] args)
        {
            initializeDBtodo();
            TODOMENU();
        }

    }
}

