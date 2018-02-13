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
            InputCheck(NewDataBaseName);    


            Thread.Sleep(200);

            OpenConnectionToSQLServ();
            NewDatabaseCreate(NewDataBaseName);
            CloseConnectionToSQLServ();

        }




        private static void NewDatabaseCreate(string dbname)
        {

            try
            {
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



        //#########################################################################################################################################
        //#########################################             USER CREATION               #######################################################
        //#########################################################################################################################################




        private static void ToDoUserCreation()
        {


            Console.WriteLine("TODO DataBase to Use : ");
            string ChoosedDataBase = Console.ReadLine().ToUpper();
            InputCheck(ChoosedDataBase);

            OpenConnectionToSQLServ();
            bool Choose = CheckTableExist(ChoosedDataBase);
            CloseConnectionToSQLServ();


            if (Choose) 
            {

                Console.WriteLine("Name new User : ");
                string NewUsername = Console.ReadLine().ToUpper();
                InputCheck(NewUsername);

                Console.WriteLine($"{NewUsername} Password : ");
                string NewPassword = Console.ReadLine().ToUpper();
                InputCheck(NewPassword);

               
                OpenConnectionToSQLServ();
                bool Create = NewUserTableProc(ChoosedDataBase, NewUsername, NewPassword);
                CloseConnectionToSQLServ();

                if (!Create)
                {
                    Console.WriteLine("Une erreur c'est produite ! Reesayez !");
                }
                else
                {
                    Console.WriteLine($"User {NewUsername} Has been created in {ChoosedDataBase} Database!");
                }

            }
            else
            {
                Console.WriteLine($"Database {ChoosedDataBase} does not exist!");
            }


        }

       


        private static bool CheckTableExist(string tablename)
        {
            int Count = 0;
            try
            {
                SqlDataReader myReader = null;
                SqlCommand CheckDBexist = new SqlCommand();

                CheckDBexist.Connection = TODOSqlConn;
                CheckDBexist.CommandText = "todo_checktableexist";
                CheckDBexist.Parameters.Clear();
                CheckDBexist.CommandType = System.Data.CommandType.StoredProcedure;
                CheckDBexist.Parameters.AddWithValue("@TableName", tablename);


                myReader = CheckDBexist.ExecuteReader();
                while (myReader.Read())
                {
                    Count++;
                }
                myReader.Close();

            }
            catch (SqlException er)
            {
                Console.WriteLine("There was an error reported by SQL Server, " + er.Message);
                return false;
            }
            if (Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        

       


        private static bool NewUserTableProc(string DBCHOICE, string NUNAME, string NUPASS)
        {

            try
            {
                SqlCommand CreateUSER = new SqlCommand();

                CreateUSER.Connection = TODOSqlConn;
                CreateUSER.CommandText = "todo_createtodouser";
                CreateUSER.Parameters.Clear();
                CreateUSER.CommandType = System.Data.CommandType.StoredProcedure;
                CreateUSER.Parameters.AddWithValue("@DATABASENAME", DBCHOICE);
                CreateUSER.Parameters.AddWithValue("@NEWUSERNAME", NUNAME);
                CreateUSER.Parameters.AddWithValue("@NEWUSERPASSWORD", NUPASS);
                CreateUSER.Parameters.AddWithValue("@Column1Name", "ID");
                CreateUSER.Parameters.AddWithValue("@Column1DataType", "INT");
                CreateUSER.Parameters.AddWithValue("@Column2Name", "TODO");
                CreateUSER.Parameters.AddWithValue("@Column2DataType", "TEXT");
                CreateUSER.Parameters.AddWithValue("@Column3Name", "USERID");
                CreateUSER.Parameters.AddWithValue("@Column3DataType", "VARCHAR(30)");


                CreateUSER.ExecuteNonQuery();
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
                TODOMENU();
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
            string Tset = Console.ReadLine().ToUpper();
            InputCheck(Tset);
            DATABASESET = Tset;

            OpenConnectionToSQLServ();
            bool DCheck = CheckTableExist(DATABASESET);
            CloseConnectionToSQLServ();

            if (!DCheck)
            {
                Console.WriteLine("DatatBase des not exist! Returning to Menu...");
                USERNAMESET = null;
                PASSWORDSET = null;
                DATABASESET = null;
                s();
                s();
                TODOMENU();
            }

            Thread.Sleep(200);                                           
            Console.WriteLine($"Setted Datatbase to {DATABASESET}!");
            Console.WriteLine();


            Tset = null;
            Console.Write("Set User Name to : ");
            Tset = Console.ReadLine().ToUpper();
            InputCheck(Tset);
            USERNAMESET = Tset;

            string UserCheck = $"{DATABASESET}{USERNAMESET}TODO";

            OpenConnectionToSQLServ();
            bool Ucheck = CheckTableExist(UserCheck);
            CloseConnectionToSQLServ();

            if (Ucheck == false)
            {
                Console.WriteLine("Check Failed : User does not exist! Returning to Menu...");
                USERNAMESET = null;
                PASSWORDSET = null;
                DATABASESET = null;
                s();
                s();
                TODOMENU();
            }
            else
            {
                Console.WriteLine($"Passed Check : Setted User is {USERNAMESET}!");
                s();



                Tset = null;
                Console.Write("Set Password to : ");
                Tset = Console.ReadLine().ToUpper();
                InputCheck(Tset);
                PASSWORDSET = Tset;

                string PassCheck = $"SELECT * FROM {DATABASESET} WHERE USERNAME = '{USERNAMESET}' AND USERPASS = '{PASSWORDSET}'";

                string ReusableCheck = "";
                ReusableCheck = CheckUserParamSQL(PassCheck, "USERPASS");


                if (ReusableCheck != PASSWORDSET)
                {
                    Console.WriteLine("Check Failed : Wrong Password! Returning to Menu...");
                    USERNAMESET = null;
                    PASSWORDSET = null;
                    DATABASESET = null;
                    s();
                    s();
                    TODOMENU();

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
            string TASK = Console.ReadLine();

            OpenConnectionToSQLServ();
            bool CHECK = AddSendodoUserProc(USERNAMESET, TASK);
            CloseConnectionToSQLServ();

            if (CHECK)
            {
                Console.WriteLine($"Task - {TASK} - Has been added to TODO !");
            }
            else
            {
                Console.WriteLine($"Task - {TASK} - Could not be added !");
            }
        }


      

        private static bool AddSendodoUserProc(string SendtoUser, string Task)
        {

            try
            {
                SqlCommand AddSendTODO = new SqlCommand();

                AddSendTODO.Connection = TODOSqlConn;
                AddSendTODO.CommandText = "todo_addsend";
                AddSendTODO.Parameters.Clear();
                AddSendTODO.CommandType = System.Data.CommandType.StoredProcedure;
                AddSendTODO.Parameters.AddWithValue("@DATABASENAME", DATABASESET);
                AddSendTODO.Parameters.AddWithValue("@USERNAME", USERNAMESET);
                AddSendTODO.Parameters.AddWithValue("@SENDTOUSERNAME", SendtoUser);
                AddSendTODO.Parameters.AddWithValue("@TASK", Task);
                AddSendTODO.ExecuteNonQuery();
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
            string ReceivingUser = Console.ReadLine().ToUpper();
            InputCheck(ReceivingUser);
            s();

            Console.WriteLine($"Task to add to {ReceivingUser} TODO : ");
            string TASK = Console.ReadLine();


            OpenConnectionToSQLServ();
            bool CHECK = AddSendodoUserProc(ReceivingUser, TASK);
            CloseConnectionToSQLServ();


            if (CHECK)
            {
                Console.WriteLine($"Task - {TASK} - Has been added to {ReceivingUser} TODO !");
            }
            else
            {
                Console.WriteLine($"Task - {TASK} - Could not be added to {ReceivingUser} TODO !");
            }
        }




        //#########################################################################################################################################
        //#########################################               REMOVE TODO               #######################################################
        //#########################################################################################################################################



        private static void RemoveTODO()
        {
            UserSetCheck();

            Console.Write($"Witch one do you want to delete ?:");
            int choice;
            while (int.TryParse(Console.ReadLine(), out choice) == false) ;

            OpenConnectionToSQLServ();
            bool CHECK = RemovetodoProc(choice.ToString());
            CloseConnectionToSQLServ();

            if (CHECK)
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
                SqlCommand DeleteTodo = new SqlCommand();

                DeleteTodo.Connection = TODOSqlConn;
                DeleteTodo.CommandText = "todo_deletetodo";
                DeleteTodo.Parameters.Clear();
                DeleteTodo.CommandType = System.Data.CommandType.StoredProcedure;
                DeleteTodo.Parameters.AddWithValue("@DATABASENAME", DATABASESET);
                DeleteTodo.Parameters.AddWithValue("@USERNAME", USERNAMESET);
                DeleteTodo.Parameters.AddWithValue("@ID", id);
                DeleteTodo.ExecuteNonQuery();
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
        



        private static void ShowTODO()
        {
            UserSetCheck();

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


