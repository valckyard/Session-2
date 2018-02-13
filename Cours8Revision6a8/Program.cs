using System;
using System.Collections.Generic;
using System.Linq;

namespace Cours8Revision6a8
{
    class Program
    {
        private static Dictionary<string, List<string>> DictionnaryGraph()
        {
            Dictionary<string, List<string>> graphe = new Dictionary<string, List<string>>();
            graphe.Add("a", new List<string> { "d", "e" });
            graphe.Add("b", new List<string> { "d", "e" });
            graphe.Add("c", new List<string> { "d", "e" });
            graphe.Add("d", new List<string> { "a", "b", "c" });
            graphe.Add("e", new List<string> { "a", "b", "c" });
            return graphe;
        }



        //############################################ REMOVE NODE #############################################################//
        //############################################ REMOVE NODE #############################################################//
        //############################################ REMOVE NODE #############################################################//




        private static void GenericGraphNodeRemoval<TK, TV>(ref Dictionary<TK, List<TV>> initDic, TV nodeTbRemoved)
        {


            foreach (dynamic key in initDic.ToList())
            {


                for (dynamic x = 0; x < key.Value.Count; ++x)
                {
                    if (nodeTbRemoved == key.Value[x])
                    {
                        initDic[key.Key].Remove(key.Value[x]);
                    }

                }
                if (key.Key == nodeTbRemoved)
                {
                    initDic.Remove(key.Key);
                }
            }
        }




        //############################################ ADD NODE #############################################################//
        //############################################ ADD NODE #############################################################//
        //############################################ ADD NODE #############################################################//




        private static void GenericGraphNodeAdd<TK, TV>(ref Dictionary<TK, List<TV>> diction, Dictionary<TK, List<TV>> addedKeyVal)
        {

            foreach (dynamic keyA in addedKeyVal)
            {
                diction.Add(keyA.Key, keyA.Value);
                dynamic keytoaddtoval = keyA.Key;

                foreach (dynamic OneValA in keyA.Value)
                    foreach (var keyD in diction)
                    {
                        if (keyA.Value.Contains(keyD.Key))
                            if (!keyD.Value.Contains(keytoaddtoval))
                                keyD.Value.Add(keytoaddtoval);

                    }
            }


        }




        //############################################ DFS #############################################################//
        //############################################ DFS #############################################################//
        //############################################ DFS #############################################################//





        private static List<TK> DfsClean<TK, TV>(Dictionary<TK, List<TV>> graphe, TK currentRoot, Stack<TK> stackMovement, List<TK> nodeOrderList)
        {


            if (!nodeOrderList.Contains(currentRoot))
            { nodeOrderList.Add(currentRoot); }


            if (graphe.Count != nodeOrderList.Count)
            {

                stackMovement.Push(currentRoot);


                foreach (dynamic key in graphe)
                {


                    if (key.Key == currentRoot)
                    {

                        Console.Write($"(Key {key.Key}|");


                        for (dynamic x = 0; x < key.Value.Count; ++x)
                        {

                            if (!nodeOrderList.Contains(key.Value[x]))
                            {

                                Console.Write($" {key.Value[x]},");
                                Console.Write($")    ");



                                stackMovement.Push(key.Value[x]);
                                currentRoot = key.Value[x];
                                return DfsClean(graphe, currentRoot, stackMovement, nodeOrderList);
                            }
                        }
                    }
                }




                Console.Write($" No Child Node Avail )   ");
                Console.Write($" Returning to Previous Key ");
                Console.WriteLine();
                currentRoot = nodeOrderList[nodeOrderList.Count - 2];
                return DfsClean(graphe, currentRoot, stackMovement, nodeOrderList);
            }

            Console.Write($" All Nodes Used END )   ");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Node Order From Root : ");
            GenericRenderList(nodeOrderList);
            return nodeOrderList;



        }




        //############################################ INIT REMOVAL #############################################################//




        private static void InitNodeRomoval()
        {
            string b = "b";
            Dictionary<string, List<string>> g = DictionnaryGraph();


            Console.WriteLine("PRE REMOVAL OF NODE AND CHILDNODES");

            GenericGraphDictRender(g);



            GenericGraphNodeRemoval(ref g, b);

            Console.WriteLine();
            Console.WriteLine($"REMOVAL OF  {b} :NODE AND {b} :CHILDNODES");

            GenericGraphDictRender(g);

        }




        //############################################ INIT ADD #############################################################//





        private static void InitNodeAdd()
        {
            Dictionary<string, List<string>> g = DictionnaryGraph();

            Console.WriteLine($"Prior to Adding Node : w(a,b) and its element to Dictionnary ");
            GenericGraphDictRender(g);
            Console.WriteLine();

            Dictionary<string, List<string>> addingNode =
                new Dictionary<string, List<string>> {{"w", new List<string> {"a", "b"}}};


            Console.WriteLine($"Adding Node : w(a,b) and its element to Dictionnary ");
            GenericGraphNodeAdd(ref g, addingNode);
            GenericGraphDictRender(g);
        }




        //############################################ GENERIC DFS #############################################################//




        private static void InitGenericDfs()
        {
            Stack<string> order = new Stack<string>();
            List<string> nodesPath = new List<string>();
            string root = "e";
            Dictionary<string, List<string>> g = DictionnaryGraph();

            DfsClean(g, root, order, nodesPath);
        }




        //############################################ INIT RENDER TYPEOGRAPGH #############################################################//





        private static void InitGraphRender()
        {
            Console.WriteLine("  Dictionary<string, List<string>> Graphe = new Dictionary<string, List<string>>();\n" +
            "  Graphe.Add(\"a\", new List<string> { \"d\", \"e\" });\n" +
            "  Graphe.Add(\"b\", new List<string> { \"d\", \"e\" });\n" +
            "  Graphe.Add(\"c\", new List<string> { \"d\", \"e\" });\n" +
            "  Graphe.Add(\"d\", new List<string> { \"a\", \"b\", \"c\" });\n" +
            "  Graphe.Add(\"e\", new List<string> { \"a\", \"b\", \"c\" }); ");
        }





        //############################################ INIT GRAPH RENDER #############################################################//





        private static void GenericGraphDictRender<TK, TV>(Dictionary<TK, List<TV>> dic)
        {
            foreach (var i in dic)
            {
                Console.Write($"KEY: {i.Key} (");
                foreach (var l in i.Value)
                {
                    Console.Write($"{l},");
                }
                Console.Write($")    ");
                Console.WriteLine();
            }
        }




        //############################################ INIT GENERIC LIST RENDER #############################################################//




        private static void GenericRenderList<T>(IEnumerable<T> xlist)
        {
            Console.Write($"(");
            foreach (dynamic elem in xlist)
            {
                Console.Write($"{elem},");
            }
            Console.Write($")  ");
            Console.WriteLine();
        }





        //meh
        private static void S() { Console.WriteLine(); }





        //############################################ EXERCICES SWITCH #############################################################//
        //############################################ EXERCICES SWITCH #############################################################//
        //############################################ EXERCICES SWITCH #############################################################//




        private static void ExSwitch()
        {

            do
            {
                Console.WriteLine($"        ╔═══════════════╦════════════════════════════════════════════════════╗");
                Console.WriteLine($"        ║TODO OPTIONS 1 ║ Dictionnary Graph                      Exercice 87 ║");
                Console.WriteLine($"        ║             2 ║ Remove Node from Graph (Dictionnary)   Ecercice 88 ║");
                Console.WriteLine($"        ║             3 ║ Add Node to Graph(Dictionnary)         Exercice 89 ║");
                Console.WriteLine($"        ║             4 ║ Generic Dictionnary Graph DFS          Exercice 891║");
                Console.WriteLine($"        ║             5 ║ EXIT PROGRAM                                       ║");
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
                        InitGraphRender();
                        S();
                        S();
                        break;
                    case 2:
                        InitNodeRomoval();
                        S();
                        S();
                        break;
                    case 3:
                        InitNodeAdd();
                        S();
                        S();
                        break;
                    case 4:
                        InitGenericDfs();
                        S();
                        S();
                        break;
                    case 5:
                        Environment.Exit(1);
                        break;
                }
            } while (true);

          
        }

        private static void Main()
        {

            ExSwitch();
        }
    }
}
