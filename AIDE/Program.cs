using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDE
{
    public class Clients
    {
        public string Nom { get; set; }
        public string Argent { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Clients> Pablo = new List<Clients>();

            Pablo.Add(new Clients { Nom = "titsuif", Argent = "Pas une criss de cenne" });

            Console.WriteLine($"{Pablo[0].Argent}, {Pablo[0].Nom}");

            foreach (var i in Pablo)
            {
              
            }
        }
    }
}
