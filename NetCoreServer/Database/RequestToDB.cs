using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using NetCoreServer.Server;
using NetCoreServer.ServerInterface;
using NetCoreServer.Database.DataTypes;
using NetCoreServer.Server.Connector;

namespace NetCoreServer.Database
{
    public class RequestToDB
    {
         public static string CreateRequest(string requestMessage, string tag, int ID)
         {
            string Responce = null;
            //DatabaseConnector.ConnectToDB();
              try
              {
                MySqlCommand sqlCommand = DatabaseConnector.sqlConnection.CreateCommand();
                MySqlDataReader Reader;
                sqlCommand.CommandText = requestMessage;
                DatabaseConnector.sqlConnection.Open();
                Reader = sqlCommand.ExecuteReader();
                ResponceFromDB.GetResponce(Reader, tag, ID);
                DatabaseConnector.sqlConnection.Close();

              }
              catch (MySqlException exception)
              {
                ExecuteResponce(exception);
                FormsManaging.TextGenerator(exception.ToString());
              }
            return Responce;
         }

         public static string ExecuteResponce(MySqlException exception)
         {
            var result = ResponceFromDB.GetException(exception);
            return result;
         }
    }
}

