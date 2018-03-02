using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sql_Class
{
    public class NetworkedSql
    {
        public SqlConnection ConnSql { get; set; }

        public NetworkedSql(string database)
        {
            string connString = $"Server=localhost;Initial Catalog={database};User Id=sa; password=Blade880";
            ConnSql = new SqlConnection(connString);
        }

        public bool SqlConnect()
        {
            try
            {
                ConnSql.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        public bool SqlDisconnect()
        {
            try
            {
                ConnSql.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return false;
            }

            return true;
        }

        public void ReadValues()
        {
            try
            {
                List<string> valueList = new List<string>();

                Console.Write("Quel Table ? : ");
                string table = Console.ReadLine().ToUpper();

                if (table != "")
                {


                    int y;
                    Console.Write("Combien de valeur a afficher ? : ");

                    while (int.TryParse(Console.ReadLine(), out y) == false)
                    {
                    }


                    for (int i = 0; i < y; i++)
                    {
                        Console.Write($"Nom de la column {i + 1} ? : ");
                        valueList.Add(Console.ReadLine().ToUpper());
                    }

                    Console.WriteLine();
                    //string value1 = Console.ReadLine().ToUpper();
                    //string value2 = Console.ReadLine().ToUpper();


                    string myCommand = $"SELECT * FROM {table}";
                    SqlConnect();
                    var mycommand = new SqlCommand(myCommand, ConnSql);
                    SqlDataReader myreader = mycommand.ExecuteReader();
                    foreach (var val in valueList)
                    {
                        Console.Write($"{val}");
                        Console.Write("\t");
                    }

                    //Console.WriteLine($"{value1}\t{value2}");
                    Console.WriteLine();


                    while (myreader.Read())
                    {
                        int count = valueList.Count;
                        int countz = 0;
                        foreach (var val in valueList)
                        {
                            Console.Write(myreader[$"{val}"]);
                            Console.Write("\t");
                            ++countz;
                            if (countz % count == 0)
                            {
                                Console.WriteLine();
                            }
                        }
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Done! Press enter to continue!");
                SqlDisconnect();
                Console.ReadLine();
                Console.Clear();
                Program.RequeteSelect();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR");
                Console.ReadLine();
                Console.Clear();
                Program.RequeteSelect();
            }
        }

       public class Program
        {
           public static void Main(string[] args)
            {
                RequeteSelect();
            }

            public static void RequeteSelect()
            {
                Console.Write("Quelle base de donnees ? :");
                string db = Console.ReadLine();
                var myconn = new NetworkedSql(db);
                if (myconn.SqlConnect())
                {
                    try
                    {
                        myconn.SqlDisconnect();
                        myconn.ReadValues();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Impossible de Connecter a la base de donnee ! Press enter to try again!");
                        Console.ReadLine();
                        RequeteSelect();
                    }
                }
                else
                {
                    Console.WriteLine("Impossible de Connecter a la base de donnee ! Press enter to try again!");
                    Console.ReadLine();
                    RequeteSelect();
                }
               
            }
        }
    }
}