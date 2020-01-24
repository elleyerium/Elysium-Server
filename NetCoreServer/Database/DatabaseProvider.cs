using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using NetCoreServer.Server.Connector;
using NetCoreServer.Server.User.PlayerStatistics;
using NetCoreServer.ServerInterface;

namespace NetCoreServer.Database
{
    public class DatabaseProvider
    {
        internal ConnectionProvider ConnectionProv;
        internal MySqlConnection SqlConnection;

        public DatabaseProvider(MySqlConnection sqlConnection)
        {
            SqlConnection = sqlConnection;
        }

        public void Connect()
        {
            SqlConnection = new MySqlConnection("Server=localhost;Database=database;Uid=root;Pwd=12345678;");
            FormsManaging.TextGenerator("Connected to the Database.");
        }

        private MySqlDataReader CreateCommand(string data)
        {
            if(SqlConnection.State == ConnectionState.Open)
                SqlConnection.Close();
            SqlConnection.Open();
            var command = SqlConnection.CreateCommand();
            command.CommandText = data;
            return command.ExecuteReader();
        }

        public bool AuthenticateUser(string username, string salt)
        {
            var reader = CreateCommand($"select * from users where username = '{username}' AND password = '{salt}'");
            while (reader.Read())
            {
                if (reader.HasRows)
                    return true;
            }
            return false;
        }

        public bool RegisterAccount(string username, string password, string email, string token)
        {
            var reader = CreateCommand(
                $"insert into users (username, password, email, token) values ('{username}', '{password}', '{email}', '{token}')");
            while (reader.Read())
            {
                Console.WriteLine("Affected");
            }
            return reader.RecordsAffected > 0;
        }

        public int GetIdByUsername(string username)
        {
            var reader = CreateCommand($"select id from users where username = '{username}'");
            var id = 0;

            while (reader.Read())
            {
                id = int.Parse(reader["id"].ToString());
            }

            return id;
        }

        #region Tokens

        public IEnumerable<string> GetTokens()
        {
            var list = new List<string>();
            var reader = CreateCommand("select token from users");

            while (reader.Read())
            {
                list.Add(reader["token"].ToString());
            }
            return list.ToArray();
        }

        public bool IsTokenValid(string token)
        {
            var reader = CreateCommand($"select token from users where token = '{token}'");
            while (reader.Read())
            {
                if (reader.HasRows)
                    return true;
            }
            return false;
        }

        public void RemoveToken(string username)
        {
            var reader = CreateCommand($"update users set token = null where username = '{username}'");
        }

        public string GetTokenByName(string username)
        {
            var reader = CreateCommand($"select token from users where username = '{username}'");
            string token = null;
            while (reader.Read())
            {
                token = reader["token"].ToString();
            }

            return token;
        }

        #endregion

        public PlayerMultiplayerInfo GetInfoByUsername(string username)
        {
            var info = new PlayerMultiplayerInfo();
            var reader = CreateCommand($"select score, level, spacepoints from scores where username = '{username}'");
            while (reader.Read())
            {
                info.Score = int.Parse(reader["score"].ToString());
                info.Level = int.Parse(reader["level"].ToString());
                info.SpacePoints = int.Parse(reader["spacepoints"].ToString());
            }
            Console.WriteLine($"score: {info.Score}, level: {info.Level}, SP: {info.SpacePoints}");
            return info;
        }
    }
}