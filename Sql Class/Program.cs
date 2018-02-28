using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;

namespace SQL__TEST
{
    public class NetworkedSql
    {
        public SqlConnection ConnSql { get; set; }

        public NetworkedSql()
        {
            string ConnString = "Server=localhost;Initial Catalog=prof_parcinfo;User Id=sa; password=Blade880";
            ConnSql = new SqlConnection(ConnString);

        }

        public void SqlConnect()
        {
            try
            {
                ConnSql.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void SqlDisconnect()
        {
            try
            {
                ConnSql.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public void Read2Values(string myCommand,string value1,string value2)
        {
            SqlConnect();
           var mycommand = new SqlCommand(myCommand,ConnSql);
            SqlDataReader myreader = mycommand.ExecuteReader();
            Console.WriteLine($"{value1}\t{value2}");
            while (myreader.Read())
            {
                //Console.Write(myreader.GetValue(1));
                //Console.Write("  " +myreader.GetValue(2));
                Console.Write(myreader[$"{value1}"]);
                Console.Write("\t");
                Console.Write(myreader[$"{value2}"]);
                Console.WriteLine();
            }
            Console.WriteLine("Done");
            SqlDisconnect();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var myconn = new NetworkedSql();
            string command = "SELECT * FROM Segment";
            myconn.Read2Values(command,"Ipreseau","NbrSalle");

        }

    }
}