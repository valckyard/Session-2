using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Threading;
using System.Data.SqlClient;

namespace Cours6Exercice
{

    //valcx.ddns.net


    class Program

    {
        private static readonly Random R = new Random();

        internal static SqlConnection TODOSqlConn;

        // My SQL Connection Method
        internal static bool OpenConnectionToSqlServ()
        {
            try
            {
                TODOSqlConn.Open();
            }
            catch (Exception er)
            {
                Console.WriteLine("There was an error reported by SQL Server, " + er.Message);
                return false;
            }
            return true;
        }

        //##########################################################################################################################################

        //My SQL Close Connection Method
        internal static bool CloseConnectionToSqlServ()
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


        private static bool SendSqlCommand(string sqlCommand, string presult, string nresult)
        {
            bool connectOpen = true, commandSent = true, connectClose = true;
            connectOpen = OpenConnectionToSqlServ();
            if (connectOpen)
            {
                commandSent = SqlNewCommand(sqlCommand);

                if (commandSent)
                {
                    connectClose = CloseConnectionToSqlServ();
                }
                if (!commandSent)
                {
                    connectClose = CloseConnectionToSqlServ();
                }
            }
            if (!connectOpen | !commandSent | !connectClose)
            {
                Console.WriteLine(nresult);
                return false;
            }
            else //(ConnectOpen & CommandSent & ConnectClose)
            {
                Console.WriteLine(presult);
                return true;
            }

        }

        private static string CheckUserParamSql(string command, string valueCheck)
        {
            string checking = "";

            SqlDataReader myReader = null;
            OpenConnectionToSqlServ();
            SqlCommand sqlCom = new SqlCommand(command, TODOSqlConn);
            myReader = sqlCom.ExecuteReader();
            while (myReader.Read())
            {
                checking = myReader[valueCheck].ToString();
            }
            CloseConnectionToSqlServ();

            return checking;
        }


        private static void InputCheck(string x)
        {
            if (x.Any(ch => !Char.IsLetterOrDigit(ch)) | x == "")
            {
                Console.WriteLine("Invalid Input!");
                Todomenu();
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
            string newDataBaseName = Console.ReadLine().ToUpper(); // Upper make it more consistant
            InputCheck(newDataBaseName);    


            Thread.Sleep(200);

            OpenConnectionToSqlServ();
            NewDatabaseCreate(newDataBaseName);
            CloseConnectionToSqlServ();

        }




        private static void NewDatabaseCreate(string dbname)
        {

            try
            {
                SqlCommand createDb = new SqlCommand();

                createDb.Connection = TODOSqlConn;
                createDb.CommandText = "todo_createdb";
                createDb.Parameters.Clear();
                createDb.CommandType = System.Data.CommandType.StoredProcedure;
                createDb.Parameters.AddWithValue("@TableName", dbname);
                createDb.Parameters.AddWithValue("@Column1Name", "USERNAME");
                createDb.Parameters.AddWithValue("@Column1DataType", "VARCHAR(30)");
                createDb.Parameters.AddWithValue("@Column2Name", "USERPASS");
                createDb.Parameters.AddWithValue("@Column2DataType", "VARCHAR(30)");


                createDb.ExecuteNonQuery();

            }
            catch (SqlException er)
            {
                Console.WriteLine("There was an error reported by SQL Server, " + er.Message);
            }
        }



        //#########################################################################################################################################
        //#########################################             USER CREATION               #######################################################
        //#########################################################################################################################################




        private static void ToDoUserCreation()
        {


            Console.WriteLine("TODO DataBase to Use : ");
            string choosedDataBase = Console.ReadLine().ToUpper();
            InputCheck(choosedDataBase);

            OpenConnectionToSqlServ();
            bool choose = CheckTableExist(choosedDataBase);
            CloseConnectionToSqlServ();


            if (choose) 
            {

                Console.WriteLine("Name new User : ");
                string newUsername = Console.ReadLine().ToUpper();
                InputCheck(newUsername);

                Console.WriteLine($"{newUsername} Password : ");
                string newPassword = Console.ReadLine().ToUpper();
                InputCheck(newPassword);

               
                OpenConnectionToSqlServ();
                bool create = NewUserTableProc(choosedDataBase, newUsername, newPassword);
                CloseConnectionToSqlServ();

                if (!create)
                {
                    Console.WriteLine("Une erreur c'est produite ! Reesayez !");
                }
                else
                {
                    Console.WriteLine($"User {newUsername} Has been created in {choosedDataBase} Database!");
                }

            }
            else
            {
                Console.WriteLine($"Database {choosedDataBase} does not exist!");
            }


        }

       


        private static bool CheckTableExist(string tablename)
        {
            int count = 0;
            try
            {
                SqlDataReader myReader = null;
                SqlCommand checkDBexist = new SqlCommand();

                checkDBexist.Connection = TODOSqlConn;
                checkDBexist.CommandText = "todo_checktableexist";
                checkDBexist.Parameters.Clear();
                checkDBexist.CommandType = System.Data.CommandType.StoredProcedure;
                checkDBexist.Parameters.AddWithValue("@TableName", tablename);


                myReader = checkDBexist.ExecuteReader();
                while (myReader.Read())
                {
                    count++;
                }
                myReader.Close();

            }
            catch (SqlException er)
            {
                Console.WriteLine("There was an error reported by SQL Server, " + er.Message);
                return false;
            }
            if (count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        

       


        private static bool NewUserTableProc(string dbchoice, string nuname, string nupass)
        {

            try
            {
                SqlCommand createUser = new SqlCommand
                {
                    Connection = TODOSqlConn,
                    CommandText = "todo_createtodouser"
                };

                createUser.Parameters.Clear();
                createUser.CommandType = System.Data.CommandType.StoredProcedure;
                createUser.Parameters.AddWithValue("@DATABASENAME", dbchoice);
                createUser.Parameters.AddWithValue("@NEWUSERNAME", nuname);
                createUser.Parameters.AddWithValue("@NEWUSERPASSWORD", nupass);
                createUser.Parameters.AddWithValue("@Column1Name", "ID");
                createUser.Parameters.AddWithValue("@Column1DataType", "INT");
                createUser.Parameters.AddWithValue("@Column2Name", "TODO");
                createUser.Parameters.AddWithValue("@Column2DataType", "TEXT");
                createUser.Parameters.AddWithValue("@Column3Name", "USERID");
                createUser.Parameters.AddWithValue("@Column3DataType", "VARCHAR(30)");


                createUser.ExecuteNonQuery();
                return true;
            }
            catch (SqlException er)
            {
                Console.WriteLine("There was an error reported by SQL Server, " + er.Message);
                return false;
            }
        }




        private static void UserSetCheck()
        {
            if (USERNAMESET == null | PASSWORDSET == null | DATABASESET == null)
            {
                Console.WriteLine("User is not set! Sending back to Menu!");
                s();
                s();
                Todomenu();
            }
        }




        //#########################################################################################################################################
        //#########################################             USER SET GLOBAL              /#####################################################
        //#########################################################################################################################################



      //###### STATIC USER SET ######//
        private static string DATABASESET;
        private static string USERNAMESET;
        private static string PASSWORDSET;
        //###### STATIC USER SET ######//




        private static void SetTodoDBuser()
        {
            Console.Write("Set Database to use to : ");
            string tset = Console.ReadLine().ToUpper();
            InputCheck(tset);
            DATABASESET = tset;

            OpenConnectionToSqlServ();
            bool dCheck = CheckTableExist(DATABASESET);
            CloseConnectionToSqlServ();

            if (!dCheck)
            {
                Console.WriteLine("DatatBase des not exist! Returning to Menu...");
                USERNAMESET = null;
                PASSWORDSET = null;
                DATABASESET = null;
                s();
                s();
                Todomenu();
            }

            Thread.Sleep(200);                                           
            Console.WriteLine($"Setted Datatbase to {DATABASESET}!");
            Console.WriteLine();


            tset = null;
            Console.Write("Set User Name to : ");
            tset = Console.ReadLine().ToUpper();
            InputCheck(tset);
            USERNAMESET = tset;

            string userCheck = $"{DATABASESET}{USERNAMESET}TODO";

            OpenConnectionToSqlServ();
            bool ucheck = CheckTableExist(userCheck);
            CloseConnectionToSqlServ();

            if (ucheck == false)
            {
                Console.WriteLine("Check Failed : User does not exist! Returning to Menu...");
                USERNAMESET = null;
                PASSWORDSET = null;
                DATABASESET = null;
                s();
                s();
                Todomenu();
            }
            else
            {
                Console.WriteLine($"Passed Check : Setted User is {USERNAMESET}!");
                s();



                tset = null;
                Console.Write("Set Password to : ");
                tset = Console.ReadLine().ToUpper();
                InputCheck(tset);
                PASSWORDSET = tset;

                string passCheck = $"SELECT * FROM {DATABASESET} WHERE USERNAME = '{USERNAMESET}' AND USERPASS = '{PASSWORDSET}'";

                string reusableCheck = "";
                reusableCheck = CheckUserParamSql(passCheck, "USERPASS");


                if (reusableCheck != PASSWORDSET)
                {
                    Console.WriteLine("Check Failed : Wrong Password! Returning to Menu...");
                    USERNAMESET = null;
                    PASSWORDSET = null;
                    DATABASESET = null;
                    s();
                    s();
                    Todomenu();

                }


                Console.WriteLine($"Passed Check : Password set!");

            }
        }



        //#########################################################################################################################################
        //#########################################                ADD TODO                 #######################################################
        //#########################################################################################################################################

       

        private static void AddTodoUser()
        {

            UserSetCheck();

            Console.WriteLine("Task To Add to TODO : ");
            string task = Console.ReadLine();

            OpenConnectionToSqlServ();
            bool check = AddSendodoUserProc(USERNAMESET, task);
            CloseConnectionToSqlServ();

            if (check)
            {
                Console.WriteLine($"Task - {task} - Has been added to TODO !");
            }
            else
            {
                Console.WriteLine($"Task - {task} - Could not be added !");
            }
        }


      

        private static bool AddSendodoUserProc(string SendtoUser, string Task)
        {

            try
            {
                SqlCommand addSendTodo = new SqlCommand();

                addSendTodo.Connection = TODOSqlConn;
                addSendTodo.CommandText = "todo_addsend";
                addSendTodo.Parameters.Clear();
                addSendTodo.CommandType = System.Data.CommandType.StoredProcedure;
                addSendTodo.Parameters.AddWithValue("@DATABASENAME", DATABASESET);
                addSendTodo.Parameters.AddWithValue("@USERNAME", USERNAMESET);
                addSendTodo.Parameters.AddWithValue("@SENDTOUSERNAME", SendtoUser);
                addSendTodo.Parameters.AddWithValue("@TASK", Task);
                addSendTodo.ExecuteNonQuery();
                return true;
            }
            catch (SqlException er)
            {
                Console.WriteLine("There was an error reported by SQL Server, " + er.Message);
                return false;
            }
        }




        //#########################################################################################################################################
        //#########################################                SEND TODO                #######################################################
        //#########################################################################################################################################



        private static void SendTODO()
        {
            UserSetCheck();

            Console.Write("Send Task to what user ? : ");
            string receivingUser = Console.ReadLine().ToUpper();
            InputCheck(receivingUser);
            s();

            Console.WriteLine($"Task to add to {receivingUser} TODO : ");
            string task = Console.ReadLine();


            OpenConnectionToSqlServ();
            bool check = AddSendodoUserProc(receivingUser, task);
            CloseConnectionToSqlServ();


            if (check)
            {
                Console.WriteLine($"Task - {task} - Has been added to {receivingUser} TODO !");
            }
            else
            {
                Console.WriteLine($"Task - {task} - Could not be added to {receivingUser} TODO !");
            }
        }




        //#########################################################################################################################################
        //#########################################               REMOVE TODO               #######################################################
        //#########################################################################################################################################



        private static void RemoveTodo()
        {
            UserSetCheck();

            Console.Write($"Witch one do you want to delete ?:");
            int choice;
            while (int.TryParse(Console.ReadLine(), out choice) == false) ;

            OpenConnectionToSqlServ();
            bool check = RemovetodoProc(choice.ToString());
            CloseConnectionToSqlServ();

            if (check)
            {
                Console.WriteLine($"TODO No {choice} has been removed from {USERNAMESET} TODO");
            }
            else
            {
                Console.WriteLine($"TODO No {choice} Could not be removed from {USERNAMESET} TODO");
            }

        }




        private static bool RemovetodoProc(string id)
        {
            //int count = 0;
            try
            {
                SqlCommand deleteTodo = new SqlCommand();

                deleteTodo.Connection = TODOSqlConn;
                deleteTodo.CommandText = "todo_deletetodo";
                deleteTodo.Parameters.Clear();
                deleteTodo.CommandType = System.Data.CommandType.StoredProcedure;
                deleteTodo.Parameters.AddWithValue("@DATABASENAME", DATABASESET);
                deleteTodo.Parameters.AddWithValue("@USERNAME", USERNAMESET);
                deleteTodo.Parameters.AddWithValue("@ID", id);
                deleteTodo.ExecuteNonQuery();
                return true;
            }
            catch (SqlException er)
            {
                Console.WriteLine("There was an error reported by SQL Server, " + er.Message);
                return false;
            }
        }




        //#########################################################################################################################################
        //#########################################                SHOW TODO                #######################################################
        //#########################################################################################################################################
        



        private static void ShowTodo()
        {
            UserSetCheck();

            string showtodoreceived = $"SELECT*FROM {DATABASESET}{USERNAMESET}TODO where USERID != '{USERNAMESET}'";
            bool check = SendSqlCommand(showtodoreceived, "YES", "NO");
            int counter = 4;
            try
            {
                SqlDataReader myReader = null;
                OpenConnectionToSqlServ();
                SqlCommand myCommand = new SqlCommand(showtodoreceived, TODOSqlConn);
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
                CloseConnectionToSqlServ();
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
            check = SendSqlCommand(SHOWTODO, "YES", "NO");
            counter = 4;
            try
            {
                SqlDataReader myReader = null;
                OpenConnectionToSqlServ();
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
                CloseConnectionToSqlServ();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }



        //##########################################################################################################################################
        //##########################################################################################################################################
        //##########################################################################################################################################

       


        private static void Todomenu()
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
                        ShowTodo();
                        s();
                        s();
                        break;
                    case 3:
                        RemoveTodo();
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
            TODOSqlConn = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["TODODBCON"].ToString()
            };
            Todomenu();
        }

    }
}


