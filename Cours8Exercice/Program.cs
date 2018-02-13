using System;
using System.Collections.Generic;
using System.Linq;


namespace Cours8Exercice
{

    enum Letters
    {
        a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z
    }

    class LetterValue
    {
        public Letters Letter { get; set; }
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
            S();
            S();
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

        //////////STATIC/////// Init Switch/////////
        private static List<LetterValue> _compairLVal;
        ////////////////////////////////////////////




        //############# Create compair file for letters ###################//
        private static List<LetterValue> CreateVal()
        {
            List<LetterValue> lVal = new List<LetterValue>();
            int val = 26;
            for (int x = 0; x < 26; ++x)
            {
                lVal.Add(new LetterValue() { Letter = (Letters)x, Value = val });
                --val;
            }
            return lVal;
        }




        //##################### Compair letters func###############################//
        private static string LetterLowerWin(string one, string two, bool reverse)
        {
            int s1 = 0;
            int s2 = 0;
            foreach (var L in _compairLVal)
            {
                if (one == L.Letter.ToString())
                {
                    s1 = L.Value;
                }
                if (two == L.Letter.ToString())
                {
                    s2 = L.Value;
                }
            }
            if (reverse == true) // Return highest letter
            {
                if (s1 < s2)
                    return one;
                return two;
            }

            if (s1 < s2) // return Lowest letter
                return two;
            return one;
        }




        //######################### Init letter comparaison Render#########################//
        private static void InitCompairList()
        {
            _compairLVal = CreateVal();


            foreach (var val in _compairLVal)
            {
                Console.Write($"({val.Letter},");
                Console.Write($"{val.Value})");
                Console.WriteLine();
            }
        }




        //############################################ LETTER COMPAIR TEST #############################################################//
        //############################################ LETTER COMPAIR TEST #############################################################//
        //############################################ LETTER COMPAIR TEST #############################################################//




        private static void InitCompairTest()
        {
            bool reverse = false;
            int x;
            Console.WriteLine("Alphabetical Order Strength         - 1");
            Console.WriteLine("Reverse Alphabetical Order Strength - 2");
            Console.Write("Choice : ");
            do
            {
                while (int.TryParse(Console.ReadLine(), out x) == false) { }
            } while (x < 1 | x > 2);
            if (x != 1) reverse = true;

            S();

            Console.Write("First Letter : ");
            string one = "";
            do
            {
                one = Console.ReadLine().ToLower();
                InputCheck(ref one);

            } while (one.Count() > 1 | one.Count() < 1);

            S();

            Console.Write("Second Letter : ");
            string two = "";
            do
            {
                two = Console.ReadLine().ToLower();
                InputCheck(ref two);

            } while (one.Count() > 1 | one.Count() < 1);

            S();

            string result = LetterLowerWin(one, two, reverse);
            Console.WriteLine($"Reverse = {reverse} => {one} VS {two}  .... Winner {result} !");

        }




        //############## Imput checker ##################//
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
            Dictionary<string, List<string>> graphe = new Dictionary<string, List<string>>();
            graphe.Add("a", new List<string> { "b", "d" });
            graphe.Add("b", new List<string> { "a", "c" });
            graphe.Add("c", new List<string> { "b", "d", "e" });
            graphe.Add("d", new List<string> { "a", "c" });
            graphe.Add("e", new List<string> { "c" });
            return graphe;
        }



        //Render 
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


        private static Stack<string> _stackMovement = new Stack<string>();
        private static List<string> _nodeOrderList = new List<string>();
        private static Queue<string> _queueMovement = new Queue<string>();



        //################################################################### BFS ##################################################################
        //################################################################### BFS ##################################################################
        //################################################################### BFS ##################################################################




        // bfs func
        private static Queue<string> BfsClean(Dictionary<string, List<string>> dic, string root)
        {
            if (dic.Count == _nodeOrderList.Count)
            {

                return _queueMovement;
            }

            else
            {

                _queueMovement.Enqueue(root);
                _nodeOrderList.Add(root);
                foreach (var key in dic)
                {

                    if (key.Key == root)
                    {
                        Console.Write($"(Key {key.Key}|");

                        for (int x = 0; x < key.Value.Count; ++x)
                        {
                            if (!_queueMovement.Contains(key.Value[x])) { Console.Write($" {key.Value[x]},"); _queueMovement.Enqueue(key.Value[x]); }
                        }
                    }
                }
                Console.Write($")    ");

                foreach (var elem in _queueMovement)
                {
                    if (!_nodeOrderList.Contains(elem))
                    {
                        root = elem;
                        break;
                    }
                }

                return BfsClean(dic, root);
            }
        }



        //Init bfs
        private static void BfsNormalInit()
        {
            _nodeOrderList = new List<string>();
            _queueMovement = new Queue<string>();

            Dictionary<string, List<string>> graphe = DictionnaryGraph();

            Console.WriteLine("~~~~PARCOURS BFS~~~~~");
            Queue<string> Retour = BfsClean(graphe, "b");


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Simplement....");
            foreach (var elem in _nodeOrderList)
            {
                Console.Write($"{elem},");
            }
            Console.WriteLine();
            Console.WriteLine();

        }



        //Init Reverse bfs
        private static void BfsReverseInit()
        {
            _nodeOrderList = new List<string>();
            _queueMovement = new Queue<string>();


            Dictionary<string, List<string>> dictionnaryGraph = DictionnaryGraph();


            foreach (var key in dictionnaryGraph.ToList())
            {
                key.Value.Sort();
                key.Value.Reverse();
            }



            Console.WriteLine("~~~~PARCOURS BFS Reverse~~~~~");
            Queue<string> RetourRev = BfsClean(dictionnaryGraph, "b");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Simplement....");
            foreach (var elem in _nodeOrderList)
            {
                Console.Write($"{elem},");
            }
            Console.WriteLine();
            Console.WriteLine();
        }



        //################################################################### DFS ##################################################################
        //################################################################### DFS ##################################################################
        //################################################################### DFS ##################################################################




        //dfs func
        private static Stack<string> DfsClean(Dictionary<string, List<string>> dic, string currentRoot)
        {
            if (dic.Count == _nodeOrderList.Count)
            {

                return _stackMovement;
            }

            else
            {


                if (!_nodeOrderList.Contains(currentRoot))
                    _nodeOrderList.Add(currentRoot);



                _stackMovement.Push(currentRoot);

                foreach (var key in dic)
                {

                    if (key.Key == currentRoot)
                    {
                        Console.Write($"(Key {key.Key}|");

                        for (int x = 0; x < key.Value.Count; ++x)
                        {


                            if (!_nodeOrderList.Contains(key.Value[x]))
                            {

                                Console.Write($" {key.Value[x]},");
                                Console.Write($")    ");

                                _stackMovement.Push(key.Value[x]);
                                currentRoot = key.Value[x];

                                return DfsClean(dic, currentRoot);
                            }

                        }

                    }
                }
            }


            if (_nodeOrderList.Count != dic.Count)
            {
                Console.Write($" No Child Node Avail )   ");
                Console.Write($" Returning to Previous Key ");
                Console.WriteLine();
            }
            else
            {
                Console.Write($" All Nodes Used END )   ");
            }
            currentRoot = _nodeOrderList[_nodeOrderList.Count - 2];
            return DfsClean(dic, currentRoot);
        }





        //Init normal dfs
        private static void DfsNormalInit()
        {
            _nodeOrderList = new List<string>();
            _stackMovement = new Stack<string>();



            Dictionary<string, List<string>> graph = DictionnaryGraph();


            Console.WriteLine("~~~~PARCOURS DFS~~~~~");
            Stack<string> ReturnPath = DfsClean(graph, "b");

            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("Simplement....");
            foreach (var elem in _nodeOrderList)
            {
                Console.Write($"{elem},");
            }


            Console.WriteLine();
            Console.WriteLine();

        }





        //init Reverse dfs
        private static void DfsReverseInit()
        {

            _nodeOrderList = new List<string>();
            _stackMovement = new Stack<string>();


            Dictionary<string, List<string>> graphe = DictionnaryGraph();


            foreach (var key in graphe.ToList())
            {
                key.Value.Sort();
                key.Value.Reverse();
            }

            Console.WriteLine("~~~~PARCOURS DFS REV~~~~~");
            Stack<string> returnPathRev = DfsClean(graphe, "b");


            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("Simplement....");
            foreach (var elem in _nodeOrderList)
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
                    while (int.TryParse(Console.ReadLine(), out choice) == false)
                    {
                    }
                } while (choice < 1 | choice > 8);
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        BfsNormalInit();
                        S();
                        S();
                        break;
                    case 2:
                        BfsReverseInit();
                        S();
                        S();
                        break;
                    case 3:
                        DfsNormalInit();
                        S();
                        S();
                        break;
                    case 4:
                        DfsReverseInit();
                        S();
                        S();
                        break;
                    case 5:
                        InitDictionnaryGraphRender();
                        S();
                        S();
                        break;
                    case 6:
                        InitRenderPeopleGraph();
                        S();
                        S();
                        break;
                    case 7:
                        InitCompairList();
                        S();
                        S();
                        break;
                    case 8:
                        InitCompairTest();
                        S();
                        S();
                        break;
                }
            } while (true);

        }




        private static void S()
        {
            Console.WriteLine();
        }




        private static void Main()
        {
         
            ExSwitch();
        }
    }
}
