using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace AccountService.Models
{
    public class DBConnect
    {
        public MySqlConnection connection;
        private string server;
        private string port;
        private string database;
        private string uid;
        private string password;
        public DBConnect()
        {
            Initialize();
            System.Diagnostics.Debug.WriteLine("DOTNET_API_DB_HOST value: " + System.Environment.GetEnvironmentVariable("DOTNET_API_DB_HOST"));
            System.Diagnostics.Debug.WriteLine("DOTNET_API_DB_PORT value: " + System.Environment.GetEnvironmentVariable("DOTNET_API_DB_PORT"));
        }
        private void Initialize()
        {
            var DB_HOST = System.Environment.GetEnvironmentVariable("DOTNET_API_DB_HOST");
            var DB_PORT = System.Environment.GetEnvironmentVariable("DOTNET_API_DB_PORT");
            server = DB_HOST != null ? DB_HOST : "localhost";
            port = DB_PORT != null ? DB_PORT : "3306";

            database = "db";
            uid = "root";
            password = "P@ssw0rd";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "PORT=" + DB_PORT + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public List<Dictionary<string, string>> Select()
        {
            string query = "SELECT * FROM account";

            //Create a list to store the result
            List<string>[] list = new List<string>[5];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();

            var var1 = new List<Dictionary<string, string>>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["username"] + "");
                    list[2].Add(dataReader["password"] + "");
                    list[3].Add(dataReader["isDeleted"] + "");
                    list[4].Add(dataReader["userid"] + "");

                    var var2 = new Dictionary<string, string>();
                    var2["id"] = dataReader["id"] + "";
                    var2["username"] = dataReader["username"] + "";
                    var2["password"] = dataReader["password"] + "";
                    var2["isDeleted"] = dataReader["isDeleted"] + "";
                    var2["userid"] = dataReader["userid"] + "";
                    var1.Add(var2);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return var1;
            }
            else
            {
                return var1;
            }
        }
    }
}