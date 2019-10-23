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
         public string CreateRequest(DatabaseProvider databaseProvider, string requestMessage, string tag, int ID)
         {
            string Responce = null;

              try
              {
                var sqlCommand = databaseProvider.SqlConnection.CreateCommand();
                MySqlDataReader reader;
                sqlCommand.CommandText = requestMessage;
                databaseProvider.SqlConnection.Open();
                reader = sqlCommand.ExecuteReader();
                //databaseProvider.ResponceFromDb.GetResponse(reader, tag, ID);
                //DatabaseConnector.sqlConnection.Close();

              }
              catch (MySqlException exception)
              {
                //ExecuteResponce(exception);
                FormsManaging.TextGenerator(exception.ToString());
              }

            return Responce;
         }

         /*public string ExecuteResponse(MySqlException exception)
         {
            var result = ResponceFromDB.GetException(exception);
            return result;
         }*/
    }
}

