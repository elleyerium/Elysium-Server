using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ServerTest.Server;
using ServerTest.Server.ServerInterface;
using ServerTest.Database.DataTypes;

namespace ServerTest.Database
{
    public class RequestToDB
    {
        public static void CreateRequest(string requestMessage) //this func sending request to database.
        {
            DatabaseConnector.ConnectToDB();
            try
            {
                MySqlCommand sqlCommand = DatabaseConnector.sqlConnection.CreateCommand();
                MySqlDataReader Reader;
                sqlCommand.CommandText = requestMessage;
                DatabaseConnector.sqlConnection.Open();
                Reader = sqlCommand.ExecuteReader();
                if(Reader.HasRows)
                    FormsManaging.TextGenerator("user logged in!");
                else
                    FormsManaging.TextGenerator("failed to login");

                DatabaseConnector.sqlConnection.Close();
                //FormsManaging.TextGenerator($"{requestMessage} as request has been created!");
            }
            catch (MySqlException exception)
            {
                ExecuteResponce(exception);
                FormsManaging.TextGenerator(exception.ToString());
            }

        }
        public static string ExecuteResponce(MySqlException exception) //Get responce using MySql exception.
        {
            var result = ResponceFromDB.GetResponce(exception);
            return result;
        }
    }
}

