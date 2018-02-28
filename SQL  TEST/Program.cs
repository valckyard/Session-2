using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SqlTest_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string OneLine;
            List<string> Noms = new List<string>();
            StreamReader SanchoBobReadsText = new StreamReader("names.txt"); //32868 names that 5 or more baby had been given in USA in 2016
            while ((OneLine = SanchoBobReadsText.ReadLine()) != null)
            {
                string[] SplittedLine = OneLine.Split(',');             //splitting at , i dont want the rest
                Noms.Add(SplittedLine[0]);
            }
          // StreamWriter  new str
        }
          
    }
}