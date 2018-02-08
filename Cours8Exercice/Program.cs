using System;
using System.Collections.Generic;
using System.Linq;


namespace Cours8Exercice
{

    enum Lettres
    {
        a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z
    }

    class LetterValue
    {
        public Lettres Letter { get; set; }
        public int Value { get; set; }
    }

    class node
    {
        public int level { get; set; }
        public List<string> childs { get; set; }
    }


    class Program
    {

        //################################################################### PEOPLE GRAPH ###############################################################
        //################################################################### PEOPLE GRAPH ###############################################################
        //################################################################### PEOPLE GRAPH ###############################################################


        private static void InitRenderPeopleGraph()
        {
            s();
            s();
            Console.WriteLine(@"                                               |-KAREN-|");
            Console.WriteLine(@"                                              /         \");
            Console.WriteLine(@"                                             /           \");
            Console.WriteLine(@"                                   |MAXIME -|             |-CHARLES|");
            Console.WriteLine(@"                                             \           /");
            Console.WriteLine(@"                                              \         /");
            Console.WriteLine(@"                                               |--BOB--|");
            Console.WriteLine(@"                                                   |");
            Console.WriteLine(@"                                                   |");
            Console.WriteLine(@"                                              |ALEXANDRE|");
        }


        //################################################################### LETTER PRIORITY CREATION/METHOD ###############################################################
        //################################################################### LETTER PRIORITY CREATION/METHOD ###############################################################
        //################################################################### LETTER PRIORITY CREATION/METHOD ###############################################################

        //////////STATIC/////// Init Switch7
        private static List<LetterValue> CompairLVal;


        private static List<LetterValue> CreateVal()
        {
            List<LetterValue> LVal = new List<LetterValue>();
            int Val = 26;
            for (int x = 0; x < 26; ++x)
            {
                LVal.Add(new LetterValue() { Letter = (Lettres)x, Value = Val });
                --Val;
            }
            return LVal;
        }


        private static string LetterLowerWin(string one, string two, bool reverse)
        {
            int S1 = 0;
            int S2 = 0;
            foreach (var L in CompairLVal)
            {
                if (one == L.Letter.ToString())
                {
                    S1 = L.Value;
                }
                if (two == L.Letter.ToString())
                {
                    S2 = L.Value;
                }
            }
            if (reverse == true) // Return highest letter
            {
                if (S1 < S2)
                    return one;
                else
                    return two;
            }
            else
            {
                if (S1 < S2) // return Lowest letter
                    return two;
                else
                    return one;
            }
        }

        private static void InitCompairList()
        {
            CompairLVal = CreateVal();


            foreach (var val in CompairLVal)
            {
                Console.Write($"({val.Letter},");
                Console.Write($"{val.Value})");
                Console.WriteLine();
            }
        }

        private static void InitCompairTest()
        {
            bool Reverse = false;
            int x;
            Console.WriteLine("Alphabetical Order Strength         - 1");
            Console.WriteLine("Reverse Alphabetical Order Strength - 2");
            Console.Write("Choice : ");
            do
            {
                while (int.TryParse(Console.ReadLine(), out x) == false) { };
            } while (x < 1 | x > 2);
            if (x != 1) Reverse = true;

            s();

            Console.Write("First Letter : ");
            string one = "";
            do
            {
                one = Console.ReadLine().ToLower();
                InputCheck(ref one);

            } while (one.Count() > 1 | one.Count() < 1);

            s();

            Console.Write("Second Letter : ");
            string two = "";
            do
            {
                two = Console.ReadLine().ToLower();
                InputCheck(ref two);

            } while (one.Count() > 1 | one.Count() < 1);

            s();

            string Result = LetterLowerWin(one, two, Reverse);
            Console.WriteLine($"Reverse = {Reverse} => {one} VS {two}  .... Winner {Result} !");

        }





        private static void InputCheck(ref string x)
        {
            if (x.Any(ch => !Char.IsLetter(ch)) | x == "")
            {
                Console.WriteLine("Invalid Input!");
                x = "";
            }

        }

        //################################################################### GRAPH ###############################################################
        //################################################################### GRAPH ###############################################################
        //################################################################### GRAPH ###############################################################


        private static Dictionary<string, List<string>> DictionnaryGraph()
        {
            Dictionary<string, List<string>> Graphe = new Dictionary<string, List<string>>();
            Graphe.Add("a", new List<string> { "b", "d" });
            Graphe.Add("b", new List<string> { "a", "c" });
            Graphe.Add("c", new List<string> { "b", "d", "e" });
            Graphe.Add("d", new List<string> { "a", "c" });
            Graphe.Add("e", new List<string> { "c" });
            return Graphe;
        }

        private static void InitDictionnaryGraphRender()
        {
            Console.WriteLine(@" Dictionary<string, List<string>> Graphe = new Dictionary<string, List<string>>();");
            Console.WriteLine("  Graphe.Add(\"a\", new List<string> { \"b\", \"d\" });");
            Console.WriteLine("  Graphe.Add(\"b\", new List<string> { \"a\", \"c\" });");
            Console.WriteLine("  Graphe.Add(\"c\", new List<string> { \"b\", \"d\", \"e\" });");
            Console.WriteLine("  Graphe.Add(\"d\", new List<string> { \"a\", \"c\" });");
            Console.WriteLine("  Graphe.Add(\"e\", new List<string> { \"c\" });");

        }



        //################################################################### STATIC ###############################################################
        //################################################################### STATIC ###############################################################
        //################################################################### STATIC ###############################################################


        private static Stack<string> StackMovement = new Stack<string>();
        private static List<string> NodeOrderList = new List<string>();
        private static Queue<string> QueueMovement = new Queue<string>();



        //################################################################### BFS ##################################################################
        //################################################################### BFS ##################################################################
        //################################################################### BFS ##################################################################



        private static Queue<string> BFSClean(Dictionary<string, List<string>> Dic, string Root)
        {
            if (Dic.Count == NodeOrderList.Count)
            {

                return QueueMovement;
            }

            else
            {

                QueueMovement.Enqueue(Root);
                NodeOrderList.Add(Root);
                foreach (var key in Dic)
                {

                    if (key.Key == Root)
                    {
                        Console.Write($"(Key {key.Key}|");

                        for (int x = 0; x < key.Value.Count; ++x)
                        {
                            if (!QueueMovement.Contains(key.Value[x])) { Console.Write($" {key.Value[x]},"); QueueMovement.Enqueue(key.Value[x]); }
                        }
                    }
                }
                Console.Write($")    ");

                foreach (var elem in QueueMovement)
                {
                    if (!NodeOrderList.Contains(elem))
                    {
                        Root = elem;
                        break;
                    }
                }

                return BFSClean(Dic, Root);
            }
        }


        private static void BFSNormalInit()
        {
            NodeOrderList = new List<string>();
            QueueMovement = new Queue<string>();

            Dictionary<string, List<string>> Graphe = DictionnaryGraph();

            Console.WriteLine("~~~~PARCOURS BFS~~~~~");
            Queue<string> Retour = BFSClean(Graphe, "b");


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Simplement....");
            foreach (var elem in NodeOrderList)
            {
                Console.Write($"{elem},");
            }
            Console.WriteLine();
            Console.WriteLine();

        }

        private static void BFSReverseInit()
        {
            NodeOrderList = new List<string>();
            QueueMovement = new Queue<string>();


            Dictionary<string, List<string>> GrapheReversed = DictionnaryGraph();


            foreach (var key in GrapheReversed.ToList())
            {
                key.Value.Sort();
                key.Value.Reverse();
            }



            Console.WriteLine("~~~~PARCOURS BFS Reverse~~~~~");
            Queue<string> RetourRev = BFSClean(GrapheReversed, "b");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Simplement....");
            foreach (var elem in NodeOrderList)
            {
                Console.Write($"{elem},");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        //################################################################### DFS ##################################################################
        //################################################################### DFS ##################################################################
        //################################################################### DFS ##################################################################



        private static Stack<string> DFSClean(Dictionary<string, List<string>> Dic, string CurrentRoot)
        {
            if (Dic.Count == NodeOrderList.Count)
            {

                return StackMovement;
            }

            else
            {


                if (!NodeOrderList.Contains(CurrentRoot))
                    NodeOrderList.Add(CurrentRoot);



                StackMovement.Push(CurrentRoot);

                foreach (var key in Dic)
                {

                    if (key.Key == CurrentRoot)
                    {
                        Console.Write($"(Key {key.Key}|");

                        for (int x = 0; x < key.Value.Count; ++x)
                        {


                            if (!NodeOrderList.Contains(key.Value[x]))
                            {

                                Console.Write($" {key.Value[x]},");
                                Console.Write($")    ");

                                StackMovement.Push(key.Value[x]);
                                CurrentRoot = key.Value[x];

                                return DFSClean(Dic, CurrentRoot);
                            }

                        }

                    }
                }
            }


            if (NodeOrderList.Count != Dic.Count)
            {
                Console.Write($" No Child Node Avail )   ");
                Console.Write($" Returning to Previous Key ");
                Console.WriteLine();
            }
            else
            {
                Console.Write($" All Nodes Used END )   ");
            }
            CurrentRoot = NodeOrderList[NodeOrderList.Count - 2];
            return DFSClean(Dic, CurrentRoot);
        }

        private static void DFSNormalInit()
        {
            NodeOrderList = new List<string>();
            StackMovement = new Stack<string>();



            Dictionary<string, List<string>> Graphe = DictionnaryGraph();


            Console.WriteLine("~~~~PARCOURS DFS~~~~~");
            Stack<string> ReturnPath = DFSClean(Graphe, "b");

            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("Simplement....");
            foreach (var elem in NodeOrderList)
            {
                Console.Write($"{elem},");
            }


            Console.WriteLine();
            Console.WriteLine();

        }

        private static void DFSReverseInit()
        {

            NodeOrderList = new List<string>();
            StackMovement = new Stack<string>();


            Dictionary<string, List<string>> Graphe = DictionnaryGraph();


            foreach (var key in Graphe.ToList())
            {
                key.Value.Sort();
                key.Value.Reverse();
            }

            Console.WriteLine("~~~~PARCOURS DFS REV~~~~~");
            Stack<string> ReturnPathRev = DFSClean(Graphe, "b");


            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("Simplement....");
            foreach (var elem in NodeOrderList)
            {
                Console.Write($"{elem},");
            }


            Console.WriteLine();
            Console.WriteLine();
        }

        //################################################################### SWITCH ###############################################################
        //################################################################### SWITCH ###############################################################
        //################################################################### SWITCH ###############################################################

        private static void ExSwitch()
        {

            do
            {
                Console.WriteLine($"        ╔═══════════════╦════════════════════════════════════════════════════╗");
                Console.WriteLine($"        ║TODO OPTIONS 1 ║ BFS NORMAL                Exercice 84/86           ║");
                Console.WriteLine($"        ║             2 ║ BFS REVERSE               Ecercice 84/86           ║");
                Console.WriteLine($"        ║             3 ║ DFS NORMAL                Exercice 83/85           ║");
                Console.WriteLine($"        ║             4 ║ DFS REVERSE               EXercice 83/85           ║");
                Console.WriteLine($"        ║             5 ║ RENDER DICTIONNARY GRAPH  Exercice 81              ║");
                Console.WriteLine($"        ║             6 ║ RENDER GRAPH PEOPLE       Exercice 82              ║");
                Console.WriteLine($"        ║             7 ║ LETTER VALUES IMPLEMENTATION                       ║");
                Console.WriteLine($"        ║             8 ║ TEST LETTER STRENGTH LOWER HIGHER                  ║");
                Console.WriteLine($"        ╚═══════════════╩════════════════════════════════════════════════════╝");
                Console.Write($"            Choice :");
                int choice;
                do
                {
                    while (int.TryParse(Console.ReadLine(), out choice) == false) ;
                } while (choice < 1 | choice > 8);
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        BFSNormalInit();
                        s();
                        s();
                        break;
                    case 2:
                        BFSReverseInit();
                        s();
                        s();
                        break;
                    case 3:
                        DFSNormalInit();
                        s();
                        s();
                        break;
                    case 4:
                        DFSReverseInit();
                        s();
                        s();
                        break;
                    case 5:
                        InitDictionnaryGraphRender();
                        s();
                        s();
                        break;
                    case 6:
                        InitRenderPeopleGraph();
                        s();
                        s();
                        break;
                    case 7:
                        InitCompairList();
                        s();
                        s();
                        break;
                    case 8:
                        InitCompairTest();
                        s();
                        s();
                        break;
                }
            } while (true);

        }

        private static void s()
        {
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            ExSwitch();

        }
    }
}
