using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace NetCoreServer.Database
{
    public static class DatabaseConnector

    {
        public static MySqlConnection sqlConnection;

        public static void ConnectToDB()
        {
            sqlConnection = new MySqlConnection("Server=localhost;Database=DataBase;Uid=root;Pwd=34etehuh121;");   
        }
        
    }
}
