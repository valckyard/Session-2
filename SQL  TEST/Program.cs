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
            string ConnString = "Server=localhost;Initial Catalog=TODODB;User Id=testtodo; password=patate";
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

    }
    class Program
    {
        static void Main(string[] args)
        {
           var myconn = new NetworkedSql();
            myconn.SqlConnect();
            
            myconn.SqlDisconnect();

        }
          
    }
}