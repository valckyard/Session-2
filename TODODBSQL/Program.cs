using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Threading;
using System.Data.SqlClient;

namespace Cours6Exercice
{




    class Program

    {
        private static readonly Random R = new Random();

        internal static SqlConnection TODOSqlConn;

        // My SQL Connection Method
        internal static bool OpenConnectionToSQLServ()
        {
            try
            {
                TODOSqlConn.Open();
            }
            catch (Exception er)
            {
                Console.WriteLine("There was an error reported by SQL Server, " + er.Message); return false;
            }
            return true;
        }

        //##########################################################################################################################################

        //My SQL Close Connection Method
        internal static bool CloseConnectionToSQLServ()
        {
            try
            {
                TODOSqlConn.Close();
                //TODOSqlConn.Dispose();
            }
            catch (Exception er)
            {
                Console.WriteLine("There was an error reported by SQL Server, " + er.Message); return false;
            }
            return true;
        }

        //##########################################################################################################################################
        // My SQL new Command Creation
        //##########################################################################################################################################
        internal static bool SqlNewCommand(string command)
        {

            try
            {
                SqlCommand insertCommand = new SqlCommand(command, TODOSqlConn);
                Console.WriteLine("Commands executed! Total rows affected are " + insertCommand.ExecuteNonQuery());
            }
            catch (SqlException er)
            {
                Console.WriteLine("There was an error reported by SQL Server, " + er.Message);
                return false;
            }
            return true;
        }

        //##########################################################################################################################################


        private static bool SendSQLCommand(string SQLCommand, string Presult, string Nresult)
        {
            bool ConnectOpen = true, CommandSent = true, ConnectClose = true;
            ConnectOpen = OpenConnectionToSQLServ();
            if (ConnectOpen)
            {
                CommandSent = SqlNewCommand(SQLCommand);

                if (CommandSent)
                {
                    ConnectClose = CloseConnectionToSQLServ();
                }
                if (!CommandSent)
                {
                    ConnectClose = CloseConnectionToSQLServ();
                }
            }
            if (!ConnectOpen | !CommandSent | !ConnectClose)
            {
                Console.WriteLine(Nresult);
                return false;
            }
            else //(ConnectOpen & CommandSent & ConnectClose)
            {
                Console.WriteLine(Presult);
                return true;
            }

        }

        private static string CheckUserParamSQL(string Command, string ValueCheck)
        {
            string Checking = "";

            SqlDataReader myReader = null;
            OpenConnectionToSQLServ();
            SqlCommand SQLCom = new SqlCommand(Command, TODOSqlConn);
            myReader = SQLCom.ExecuteReader();
            while (myReader.Read())
            {
                Checking = myReader[ValueCheck].ToString();
            }
            CloseConnectionToSQLServ();

            return Checking;
        }

        private static void NewDatabaseCreate(string dbname)
        {
           
            try {
                SqlCommand CreateDB = new SqlCommand();

                CreateDB.Connection = TODOSqlConn;
                CreateDB.CommandText = "todo_createdb";
                CreateDB.Parameters.Clear();
                CreateDB.CommandType = System.Data.CommandType.StoredProcedure;
                CreateDB.Parameters.AddWithValue("@TableName", dbname);
                CreateDB.Parameters.AddWithValue("@Column1Name", "USERNAME");
                CreateDB.Parameters.AddWithValue("@Column1DataType", "VARCHAR(30)");
                CreateDB.Parameters.AddWithValue("@Column2Name", "USERPASS");
                CreateDB.Parameters.AddWithValue("@Column2DataType", "VARCHAR(30)");

              
                CreateDB.ExecuteNonQuery();
          
            }
            catch (SqlException er)
            {
                Console.WriteLine("There was an error reported by SQL Server, " + er.Message);
            }
            }

    private static void InputCheck(string x)
        {
            if (x.Any(ch => !Char.IsLetterOrDigit(ch)) | x == "")
            {
                Console.WriteLine("Invalid Input!");
                TODOMENU();
            }
            
        }




        //##########################################################################################################################################
        //M""""""'YMMM#"""""""'M   MM'""""'YMMMM"""""""`MMMM""""""""`MMMP"""""""MMM""""""""MM""MMMP"""""YMMM"""""`'MMM 
        //M  mmmm. `M##  mmmm. `M  M' .mmm. `MMM  mmmm,  MMM  mmmmmmmMM' .mmmm  MMMmmm  mmmMM  MM' .mmm. `MM  mm.  MMM 
        //M  MMMMM  M#'        .M  M  MMMMMooMM'        .MM`      MMMMM         `MMMMM  MMMMM  MM  MMMMM  MM  MMM  MMM 
        //M  MMMMM  MM#  MMMb.'YM  M  MMMMMMMMMM  MMMb. "MMM  MMMMMMMMM  MMMMM  MMMMMM  MMMMM  MM  MMMMM  MM  MMM  MMM 
        //M  MMMM' .MM#  MMMM'  M  M. `MMM' .MMM  MMMMM  MMM  MMMMMMMMM  MMMMM  MMMMMM  MMMMM  MM. `MMM' .MM  MMM  MMM
        //M       .MMM#       .;M  MM.     .dMMM  MMMMM  MMM        .MM  MMMMM  MMMMMM  MMMMM  MMMb     dMMM  MMM  MMM 
        //MMMMMMMMMMMM#########M   MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM 
        //##########################################################################################################################################


        private static void CreateTodoDB()
        {


            Console.WriteLine("New TODO Database Name ?: ");
            string NewDataBaseName = Console.ReadLine().ToUpper(); // Upper make it more consistant
            InputCheck(NewDataBaseName);    //InputCheck(NewDataBaseName); // not avail => todomenu


            Thread.Sleep(200);
            
            // USING todo_createdb // stocked procedures
            OpenConnectionToSQLServ();
            NewDatabaseCreate(NewDataBaseName);
            CloseConnectionToSQLServ();

            //Hardcoded 
            //Responses
            //string DBNULL = $" Could not create {NewDataBaseName} Database! ";
            //string DBDONE = $"Database {NewDataBaseName} Created!";
            // string CreateDB = $"CREATE TABLE {NewDataBaseName} (USERNAME VARCHAR(30) PRIMARY KEY NOT NULL, USERPASS VARCHAR(30) NOT NULL);";
            //SendSQLCommand(CreateDB, DBDONE, DBNULL);
        }


        //##########################################################################################################################################
        //##########################################################################################################################################
        //##########################################################################################################################################
        // Exercice 65 User Creation
        private static void ToDoUserCreation()
        {

            Console.WriteLine("TODO DataBase to Use : ");
            string ChoosedDataBase = Console.ReadLine().ToUpper();
            InputCheck(ChoosedDataBase);

            string DBExist = $"SELECT * FROM {ChoosedDataBase}";
            string DBNULL = $" Could not choose {ChoosedDataBase} Database it does not exist! ";
            string DBDONE = $"Using {ChoosedDataBase} Database!";

            bool Choose = SendSQLCommand(DBExist, DBDONE, DBNULL);


            if (Choose)
            {
                Console.WriteLine("Name new User : ");
                string NewUsername = Console.ReadLine().ToUpper();
                InputCheck(NewUsername);

                Console.WriteLine($"{NewUsername} Password : ");
                string NewPassword = Console.ReadLine().ToUpper();
                InputCheck(NewPassword);

                string insertfk = $"CREATE TABLE {ChoosedDataBase}{NewUsername}TODO (ID INT IDENTITY PRIMARY KEY,TODO TEXT NULL, USERID VARCHAR(30) FOREIGN KEY REFERENCES {ChoosedDataBase}(USERNAME));" +
                    $"INSERT INTO {ChoosedDataBase} VALUES('{NewUsername}', '{NewPassword}')";


                bool Existornot = SendSQLCommand(insertfk, "yes", "no");
            }


        }

        //##########################################################################################################################################
        //##########################################################################################################################################
        //##########################################################################################################################################

        static string DATABASESET;
        static string USERNAMESET;
        static string PASSWORDSET;
        // Exercice 65 Set User and DataBase so they dont have to "Log in" everytime theres a todo to add or remove
        private static void SetTodoDBuser()
        {
            Console.Write("Set Database to use to : ");
            DATABASESET = Console.ReadLine().ToUpper();
            InputCheck(DATABASESET);


            string DatabaseCheck = $"SELECT * FROM {DATABASESET}";

            bool DCheck = SendSQLCommand(DatabaseCheck, "yes", "no");

            if (!DCheck)
            {
                Console.WriteLine("DatatBase des not exist! Returning to Menu...");
                s();
                s();
                TODOMENU();
            }

            Thread.Sleep(200);                                            // Does (i lie i set it at the end)
            Console.WriteLine($"Setted Datatbase to {DATABASESET}!");
            Console.WriteLine();



            Console.Write("Set User Name to : ");
            USERNAMESET = Console.ReadLine().ToUpper();
            InputCheck(USERNAMESET);

            string UserCheck = $"SELECT * FROM {DATABASESET} WHERE USERNAME = '{USERNAMESET}'";

            string ReusableCheck = "";

            ReusableCheck = CheckUserParamSQL(UserCheck, "USERNAME");

            if (ReusableCheck == "")
            {
                Console.WriteLine("Check Failed : User does not exist! Returning to Menu...");
                s();
                s();
                TODOMENU();
            }

            Console.WriteLine($"Passed Check : Setted User is {USERNAMESET}!");
            s();




            ReusableCheck = "";
            Console.Write("Set Password to : ");
            PASSWORDSET = Console.ReadLine().ToUpper();
            InputCheck(PASSWORDSET);


            string PassCheck = $"SELECT * FROM {DATABASESET} WHERE USERNAME = '{USERNAMESET}' AND USERPASS = '{PASSWORDSET}'";

            ReusableCheck = CheckUserParamSQL(PassCheck, "USERPASS");


            if (ReusableCheck != PASSWORDSET)
            {
                Console.WriteLine("Check Failed : Wrong Password! Returning to Menu...");
                s();
                s();
                TODOMENU();
               
            }


            Console.WriteLine($"Passed Check : Password set!");
           
        }



        //##########################################################################################################################################
        //##########################################################################################################################################
        //##########################################################################################################################################

        // Exercice 65 Adding a TODO (EASIEST PART OF THAT THING)
        private static void AddTodoUser()
        {



            Console.WriteLine("Task To Add to TODO : ");
            string TASK = Console.ReadLine();

            string TaskAdd = $"INSERT INTO {DATABASESET}{USERNAMESET}TODO VALUES('{TASK}', '{USERNAMESET}')";

            bool CHECK = SendSQLCommand(TaskAdd, "YES", "NO");

            Console.WriteLine($"Task - {TASK} - Has been added to TODO !");

        }


        //##########################################################################################################################################
        //##########################################################################################################################################
        //##########################################################################################################################################

        // Exercice 65 Visual of TODO Entered
        private static void ShowTODO()
        {
            string SHOWTODORECEIVED = $"SELECT*FROM {DATABASESET}{USERNAMESET}TODO where USERID != '{USERNAMESET}'";
            bool CHECK = SendSQLCommand(SHOWTODORECEIVED, "YES", "NO");
            int counter = 4;
            try
            {
                SqlDataReader myReader = null;
                OpenConnectionToSQLServ();
                SqlCommand myCommand = new SqlCommand(SHOWTODORECEIVED, TODOSqlConn);
                myReader = myCommand.ExecuteReader();
                Console.WriteLine("   | RECEIVED MESSAGES |");
                Console.WriteLine(@"╔════════════════════════════════════════════════════════════════════╗");
                while (myReader.Read())
                {
                    Console.SetCursorPosition(0, Console.CursorTop = counter);
                    Console.Write($"║");

                    Console.Write(myReader["USERID"].ToString());
                    Console.Write("(");
                    Console.Write(myReader["ID"].ToString());
                    Console.Write(")");
                    Console.Write(" -- ");
                    Console.Write(myReader["TODO"].ToString());
                    Console.SetCursorPosition(69, Console.CursorTop = counter);
                    Console.WriteLine($"║");
                    ++counter;

                }
                Console.SetCursorPosition(0, Console.CursorTop = counter);
                Console.WriteLine(@"╚════════════════════════════════════════════════════════════════════╝");
                CloseConnectionToSQLServ();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            s();
            Console.WriteLine("Press ENTER for your TODO");
            Console.ReadLine();
            Console.Clear();

            string SHOWTODO = $"SELECT*FROM {DATABASESET}{USERNAMESET}TODO where USERID = '{USERNAMESET}'";
            CHECK = SendSQLCommand(SHOWTODO, "YES", "NO");
            counter = 4;
            try
            {
                SqlDataReader myReader = null;
                OpenConnectionToSQLServ();
                SqlCommand myCommand = new SqlCommand(SHOWTODO, TODOSqlConn);
                myReader = myCommand.ExecuteReader();
                Console.WriteLine("   | YOUR TODO LIST |");
                Console.WriteLine(@"╔════════════════════════════════════════════════════════════════════╗");
                while (myReader.Read())
                {
                    Console.SetCursorPosition(0, Console.CursorTop = counter);
                    Console.Write($"║");

                    Console.Write(myReader["ID"].ToString());
                    Console.Write(" -- ");
                    Console.Write(myReader["TODO"].ToString());
                    Console.SetCursorPosition(69, Console.CursorTop = counter);
                    Console.WriteLine($"║");
                    ++counter;

                }
                Console.SetCursorPosition(0, Console.CursorTop = counter);
                Console.WriteLine(@"╚════════════════════════════════════════════════════════════════════╝");
                CloseConnectionToSQLServ();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            
        }


        //##########################################################################################################################################
        //##########################################################################################################################################
        //##########################################################################################################################################

        //Exercice 65 Removing element from TODO
        private static void RemoveTODO()
        {
            Console.Write($"Witch one do you want to delete ?:");
            int choice;
            while (int.TryParse(Console.ReadLine(), out choice) == false) ;
            string DELETE = $"DELETE FROM {DATABASESET}{USERNAMESET}TODO WHERE ID = {choice}";
            SendSQLCommand(DELETE, "YES", "NO");
        }



        //##########################################################################################################################################
        //##########################################################################################################################################
        //##########################################################################################################################################

            //send message ?
            private static void SendTODO()
        {
            Console.Write("Send Task to what user ? : ");
            string ReceivingUser = Console.ReadLine().ToUpper();
            InputCheck(ReceivingUser);
            s();

            Console.WriteLine($"Task to add to {ReceivingUser} TODO : ");
            string TASK = Console.ReadLine();



            string TaskAdd = $"INSERT INTO {DATABASESET}{ReceivingUser}TODO VALUES('{TASK}', '{USERNAMESET}')";

            bool CHECK = SendSQLCommand(TaskAdd, "YES", "NO");

            Console.WriteLine($"Task - {TASK} - Has been added to {ReceivingUser} TODO !");

        }


        //##########################################################################################################################################
        //##########################################################################################################################################
        //##########################################################################################################################################

        //private static List<Clients> USER = new List<Clients>();
        private static void TODOMENU()
        {

            do
            {
                Console.WriteLine($"        ╔═══════════════╦════════════════════════════════════════════════════╗");
                Console.WriteLine($"        ║TODO OPTIONS 1 ║ ADD TODO                                           ║");
                Console.WriteLine($"        ║             2 ║ SHOW TODO                                          ║");
                Console.WriteLine($"        ║             3 ║ DELETE TODO                                        ║");
                Console.WriteLine($"        ║             4 ║ CREATE DATABASE                                    ║");
                Console.WriteLine($"        ║             5 ║ CREATE USER (REQUIRE DATABASE TO BE CREATED)       ║");
                Console.WriteLine($"        ║             6 ║ SET USER/DATABASE                                  ║");
                Console.WriteLine($"        ║             7 ║ SEND TODO                                          ║");
                Console.WriteLine($"        ╚═══════════════╩════════════════════════════════════════════════════╝");
                Console.Write($"            Choice :");
                int choice;
                do
                {
                    while (int.TryParse(Console.ReadLine(), out choice) == false) ;
                } while (choice < 1 | choice > 7);
                Console.Clear();
                switch (choice)
                {
                    case 4:
                        CreateTodoDB();
                        s();
                        s();
                        break;
                    case 5:
                        ToDoUserCreation();
                        s();
                        s();
                        break;
                    case 6:
                        SetTodoDBuser();
                        s();
                        s();
                        break;
                    case 1:
                        AddTodoUser();
                        s();
                        s();
                        break;
                    case 2:
                        ShowTODO();
                        s();
                        s();
                        break;
                    case 3:
                        RemoveTODO();
                        s();
                        s();
                        break;
                    case 7:
                        SendTODO();
                        s();
                        s();
                        break;
                }
            } while (true);

        }


        private static void s()
        {
            Console.WriteLine();
        }


        //##########################################################################################################################################
        //##########################################################################################################################################
        //##########################################################################################################################################

        static void Main(string[] args)
        {
            TODOSqlConn = new SqlConnection();
            TODOSqlConn.ConnectionString = ConfigurationManager.ConnectionStrings["TODODBCON"].ToString();
            TODOMENU();
        }

    }
}


