using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTest_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            using (SqlConnection TODOSqlConn = new SqlConnection())
            {
              
                TODOSqlConn.ConnectionString = "user id = sa; " +
                                      "password=Blade880;server=localhost;" +//174.94.71.98
                                      "Trusted_Connection=yes;" +
                                      "database=TODODB; " +
                                      "connection timeout=30"; 
               
    
                try
                {
                    TODOSqlConn.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM username", TODOSqlConn);
                    SqlCommand insertCommand = new SqlCommand("alter table usernameaaa add suif varchar(30)", TODOSqlConn);

                    Console.WriteLine("Commands executed! Total rows affected are " + insertCommand.ExecuteNonQuery());

                }
                catch (SqlException er)
                {
                    Console.WriteLine("There was an error reported by SQL Server, " + er.Message);
                }
                TODOSqlConn.Close();
                TODOSqlConn.Dispose();

                string dbname = "SUIF";

                SqlCommand CreateDB = new SqlCommand();

                CreateDB.CommandText = "TODO_DB_BuildTable";
                CreateDB.Parameters.Clear();
                CreateDB.CommandType = CommandType.StoredProcedure;
                CreateDB.Parameters.AddWithValue("@TableName", dbname);
                //CreateDB.Parameters.AddWithValue("@YourCustomTable", dtCustomerFields).SqlDbType = SqlDbType.Structured;

                //Execute
                CreateDB.ExecuteNonQuery();

            }
        }
    }
}