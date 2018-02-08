using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.Design;
using System.Web.UI.WebControls;
//using System.Windows.Forms;
using Microsoft.TeamFoundation.TestManagement.Client;
using System.Collections;
//using TreeNode  System.Web.UI.WebControls;
namespace Cours8Exercice
{

    //public class Node
    //{
    //    public int Index { get; set; }
    //    public List<Node> neighbors;
    //    public Node(int index)
    //    {
    //        Index = index;
    //        neighbors = new List<Node>();
    //    }
    //    public void AddNeighbor(int index)
    //    {
    //        neighbors.Add(new Node(index));
    //    }
    //}

    //public class BFS
    //{

    //    public void BFSearch(Node Root)
    //    {
    //        Queue<Node> queue = new Queue<Node>();
    //        queue.Enqueue(Root);
    //        while (queue.Count > 0)
    //        {
    //            Node tempNode = queue.Dequeue();
    //            Console.WriteLine("Node number: " + tempNode.Index);
    //            foreach (var item in tempNode.neighbors)
    //            {
    //                queue.Enqueue(item);
    //            }
    //        }
    //    }
    //}
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

        public static List<LetterValue> CreateVal()
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

        //Exercice 81 Add Key values
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


        /// BFS FUCKED UP
        static Stack<string> Tree = new Stack<string>();

        static List<string> Visited = new List<string>();
        private static Stack<string> BFSStruct(Dictionary<string, List<string>> Dic, List<string> Root, int level)
        {
            List<string> listchilds = new List<string>();
            Console.Write($" LEVEL : {level}");



            for (int w = 0; w < Root.Count; w++)
                foreach (var key in Dic)
                {
                    if (key.Key == Root[w])
                    {
                        Tree.Push(Root[w]);
                        Visited.Add(Root[w]);

                        Console.Write($"(Key {key.Key}|");
                        for (int x = 0; x < key.Value.Count(); ++x)
                        {
                            if (!Tree.Contains(key.Value[x]))
                            {

                                listchilds.Add(key.Value[x]); // a c
                                Console.Write($" {key.Value[x]},");
                            }
                        }
                    }


                }
            Console.Write($")  ");
            Root = new List<string>();
            bool Gate = true;
            ++level;

            if (Visited.Count <= Dic.Count)
                while (Gate == true)
                {

                    foreach (var s in listchilds)
                    {
                        if (!Visited.Contains(s))
                        {
                            Root.Add(s);
                        }
                        else
                        {
                            Gate = false;
                        }
                    }
                    return BFSStruct(Dic, Root, level);
                }
            else
            {
                return Tree;
            }

            return Tree;
        }



        private static node ChildofChilds(Dictionary<string, List<string>> Dic, List<string> Childs, ref int level, ref List<string> Duplicate)
        {
            List<string> NewChilds = new List<string>();
            foreach (var ChildsASKey in Childs)
                foreach (var key in Dic)
                {
                    if (key.Key == ChildsASKey)

                        for (int x = 0; x < key.Value.Count(); ++x)
                        {
                            if (!Duplicate.Contains(key.Value[x]))
                            {
                                Duplicate.Add(key.Value[x]);
                                NewChilds.Add(key.Value[x]);
                            }
                        }
                }
            return (new node() { level = level, childs = NewChilds });
        }

        /////////////BFS
        private static List<string> NodeOrderList = new List<string>();
        private static Queue<string> RootAndChilds = new Queue<string>();
        private static Queue<string> BFSClean(Dictionary<string, List<string>> Dic, string Root)
        {
            if (Dic.Count == NodeOrderList.Count)
            {

                return RootAndChilds;
            }

            else
            {

                RootAndChilds.Enqueue(Root);
                NodeOrderList.Add(Root);
                foreach (var key in Dic)
                {

                    if (key.Key == Root)
                    {
                        Console.Write($"(Key {key.Key}|");

                        for (int x = 0; x < key.Value.Count; ++x)
                        {
                            if (!RootAndChilds.Contains(key.Value[x])) { Console.Write($" {key.Value[x]},"); RootAndChilds.Enqueue(key.Value[x]); }
                        }
                    }
                }
                Console.Write($")    ");

                foreach (var elem in RootAndChilds)
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


        ///////DFS
        private static Stack<string> StackMovement = new Stack<string>();
        private static Stack<string> DFSClean(Dictionary<string, List<string>> Dic, string CurrentRoot, bool ReverseAlpha)
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

                                return DFSClean(Dic, CurrentRoot, ReverseAlpha);
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
            return DFSClean(Dic, CurrentRoot, ReverseAlpha);
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
                if (S1 > S2) // return Lowest letter
                    return one;
                else
                    return two;
            }
        }



        static List<LetterValue> CompairLVal;
        static void Main(string[] args)
        {
            CompairLVal = CreateVal();


            foreach (var val in CompairLVal)
            {
                Console.Write($"({val.Letter},");
                Console.Write($"{val.Value})");
                Console.WriteLine();
            }


            Dictionary<string, List<string>> GrapheEx = DictionnaryGraph();
            Stack<string> Order = new Stack<string>();
            Order.Push("e");
            Order.Push("d");
            Order.Push("c");
            Order.Push("a");
            Order.Push("b");


            //FUCKED UP BFS
            //List<string> RootTab = new List<string> { "b" };
            //Stack<string> Processed = BFSStruct(GrapheEx, RootTab, 0);

            //foreach (var node in Processed)
            //{

            //    foreach (var childs in node)
            //    {
            //        Console.Write($"{childs},");
            //    }
            //    Console.WriteLine(node);
            //    Console.WriteLine();
            //}

            ///////////////////////////BFS//////////////////////// 85

            NodeOrderList = new List<string>();
            RootAndChilds = new Queue<string>();

            Console.WriteLine("~~~~PARCOURS BFS~~~~~");
            Queue<string> Retour = BFSClean(GrapheEx, "b");


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Simplement....");
            foreach (var elem in NodeOrderList)
            {
                Console.Write($"{elem},");
            }
            Console.WriteLine();
            Console.WriteLine();


            //84 BFS REVERSED

            Dictionary<string, List<string>> GrapheExRev = DictionnaryGraph();


            foreach (var key in GrapheExRev.ToList())
            {
                key.Value.Sort();
                key.Value.Reverse();
            }

            NodeOrderList = new List<string>();
            RootAndChilds = new Queue<string>();

            Console.WriteLine("~~~~PARCOURS BFS Reverse~~~~~");
            Queue<string> RetourRev = BFSClean(GrapheExRev, "b");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Simplement....");
            foreach (var elem in NodeOrderList)
            {
                Console.Write($"{elem},");
            }
            Console.WriteLine();
            Console.WriteLine();




            ////DFS
            NodeOrderList = new List<string>();
            StackMovement = new Stack<string>();
            Dictionary<string, List<string>> GrapheExForDFS = DictionnaryGraph();
            Console.WriteLine("~~~~PARCOURS DFS~~~~~");
            Stack<string> ReturnPath = DFSClean(GrapheExForDFS, "b", false);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Simplement....");
            foreach (var elem in NodeOrderList)
            {
                Console.Write($"{elem},");
            }
            Console.WriteLine();
            Console.WriteLine();

            //84 DFS REVERSED

            NodeOrderList = new List<string>();
            StackMovement = new Stack<string>();
            Dictionary<string, List<string>> GrapheExForDFSRev = DictionnaryGraph();


            foreach (var key in GrapheExForDFSRev.ToList())
            {
                key.Value.Sort();
                key.Value.Reverse();
            }

            Console.WriteLine("~~~~PARCOURS DFS REV~~~~~");
            Stack<string> ReturnPathRev = DFSClean(GrapheExForDFSRev, "b", true);
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
    }
}
