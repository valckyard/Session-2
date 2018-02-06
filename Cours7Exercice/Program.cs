using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours7Exercice
{
    class Program
    {
        private static List<T> SortMyList<T>(List<T> TheList1)
        {


            if ((TheList1.GetType() == typeof(int)) | (TheList1.GetType() == typeof(double)))
            {
                dynamic x;
                dynamic y;
                dynamic count = TheList1.Count();

                for (var p = 0; p <= count; p++)
                {
                    for (var i = 0; i <= count; i++)
                    {
                        x = TheList1[i];
                        y = TheList1[i + 1];

                        if (x > y)
                        {
                            dynamic Temp = y;
                            y = x;
                            x = Temp;
                        }
                    }

                }
                return TheList1;
            }
            else
            {
                Console.WriteLine("FU c est pas un int ou un double");
                return TheList1;
            }
        }


        static void Main(string[] args)
        {
            List<int> suif = new List<int>();
            SortMyList(suif);

        }
    }
}
