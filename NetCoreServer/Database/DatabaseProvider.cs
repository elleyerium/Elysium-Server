using System.IO;
using MySql.Data.MySqlClient;
using NetCoreServer.Server.Connector;
using NetCoreServer.ServerInterface;

namespace NetCoreServer.Database
{
    public class DatabaseProvider
    {
        internal ConnectionProvider ConnectionProv;
        internal ResponseFromDB ResponceFromDb;
        internal MySqlConnection SqlConnection;

        public DatabaseProvider(ResponseFromDB responseInstance, MySqlConnection sqlConnection)
        {
            ResponceFromDb = responseInstance;
            SqlConnection = sqlConnection;
        }

        /*public byte[] Request(string message)
        {
            return RequestToDb.CreateRequest(this, message);
        }*/
        public void ConnectToDB()
        {
            SqlConnection = new MySqlConnection("Server=localhost;Database=database;Uid=root;Pwd=12345678;");
            FormsManaging.TextGenerator("Connected to a Database.");
        }

        public static byte[] CreateRequest(DatabaseProvider databaseProvider, string requestMessage)
        {
            using (var memoryStream = new MemoryStream())
            {
                FormsManaging.TextGenerator($"Created a new request with data :> {requestMessage}");
                using (var writer = new BinaryWriter(memoryStream))
                {
                    try
                    {
                        var sqlCommand = databaseProvider.SqlConnection.CreateCommand();
                        sqlCommand.CommandText = requestMessage;
                        databaseProvider.SqlConnection.Open();
                        var reader = sqlCommand.ExecuteReader();
                        reader.Read();

                        if (reader.HasRows)
                            writer.Write((byte)1);
                        else if (!reader.HasRows)
                            writer.Write((byte)0);
                        //writer.Write((byte)6);
                        /*var dataAffected = reader.RecordsAffected;
                        if (dataAffected > 0)
                        {
                            writer.Write((byte)0);
                            FormsManaging.TextGenerator("Registered");
                        }
                        else if (dataAffected == 0)
                        {
                            writer.Write((byte)1);
                            FormsManaging.TextGenerator("failed");
                        }*/

                    }
                    catch (MySqlException exception)
                    {
                        FormsManaging.TextGenerator(exception.ToString());
                    }
                }
                databaseProvider.SqlConnection.Close();
                //FormsManaging.TextGenerator(memoryStream.Length.ToString());
                return memoryStream.ToArray();
            }
        }
    }
}