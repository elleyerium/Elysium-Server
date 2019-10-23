using MySql.Data.MySqlClient;

namespace NetCoreServer.Database
{
    public class DatabaseProvider
    {
        internal ResponseFromDB ResponceFromDb;
        internal RequestToDB RequestToDb;
        internal MySqlConnection SqlConnection;

        public DatabaseProvider(ResponseFromDB responseInstance, RequestToDB requestInstance, MySqlConnection sqlConnection)
        {
            ResponceFromDb = responseInstance;
            RequestToDb = requestInstance;
            SqlConnection = sqlConnection;
        }

        public void ConnectToDB()
        {
            SqlConnection = new MySqlConnection("Server=localhost;Database=database;Uid=root;Pwd=34etehuh121;");
        }
    }
}