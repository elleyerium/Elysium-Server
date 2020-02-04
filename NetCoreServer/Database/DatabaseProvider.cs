using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using MySql.Data.MySqlClient;
using NetCoreServer.Server.Connector;
using NetCoreServer.Server.User;
using NetCoreServer.ServerInterface;

namespace NetCoreServer.Database
{
    public class DatabaseProvider
    {
        private ConnectionProvider _connectionProv;
        private MySqlConnection _sqlConnection;

        internal DatabaseProvider(MySqlConnection sqlConnection, ConnectionProvider connectionProv)
        {
            _connectionProv = connectionProv;
            _sqlConnection = sqlConnection;
        }

        public void Connect()
        {
            _sqlConnection = new MySqlConnection("Server=localhost;Database=database;Uid=root;Pwd=12345678;");
            FormsManaging.TextGenerator("Connected to the Database.");
        }

        private MySqlDataReader CreateCommand(string data)
        {
            if(_sqlConnection.State == ConnectionState.Open)
                _sqlConnection.Close();
            _sqlConnection.Open();
            var command = _sqlConnection.CreateCommand();
            command.CommandText = data;
            return command.ExecuteReader();
        }

        #region auth

        public bool AuthenticateUser(string username, string salt)
        {
            var reader = CreateCommand($"select * from users where username = '{username}' AND password = '{salt}'");
            while (reader.Read())
            {
                if (reader.HasRows && _connectionProv.PlayerPool.List.FirstOrDefault(x => x.AccountInfo.Id == uint.Parse(reader["id"].ToString())) == null)
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

            if (reader.RecordsAffected > 0)
            {
                CreateCommand($"insert into scores (username, level, totalScore, exp, spacePoints) values " +
                              $"('{username}', '{1}', '{0}', '{0}' , '{0}')");
            }

            return reader.RecordsAffected > 0;
        }

        #endregion

        #region utils

        public uint GetIdByUsername(string username)
        {
            var reader = CreateCommand($"select id from users where username = '{username}'");
            uint id = 0;

            while (reader.Read())
            {
                id = uint.Parse(reader["id"].ToString());
            }

            return id;
        }

        public PlayerType GetPlayerRoleByToken(string token)
        {
            var reader = CreateCommand($"select role from users where token = '{token}'");
            var playerType = PlayerType.Player;
            while (reader.Read())
            {
                playerType = Enum.Parse<PlayerType>(reader["role"].ToString());
            }

            return playerType;
        }

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

        public PlayerStatistics GetInfoByUsername(string username)
        {
            var info = new PlayerStatistics { Username = username };
            var reader = CreateCommand($"select totalScore, level, spacePoints, rank, exp from scores where username = '{username}'");
            while (reader.Read())
            {
                info.Score = uint.Parse(reader["totalScore"].ToString());
                info.Level = ushort.Parse(reader["level"].ToString());
                info.SpacePoints = ushort.Parse(reader["spacePoints"].ToString());
                info.Rank = uint.Parse(reader["rank"].ToString());
                info.Exp = ushort.Parse(reader["exp"].ToString());
            }
            Console.WriteLine($"score: {info.Score}, level: {info.Level}, SP: {info.SpacePoints}");
            return info;
        }

        #endregion

        #region additional

        public string GetAvatarSource(string username)
        {
            var reader = CreateCommand($"select avatar from users where username = '{username}'");
            var source = string.Empty;

            while (reader.Read())
            {
                source = reader["avatar"].ToString();
            }

            return source;
        }

        #endregion
    }
}