using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using NetCoreServer.Database;
using NetCoreServer.Database.DataTypes;
using NetCoreServer.Server.Connector;
using NetCoreServer.Server.User;
using NetCoreServer.Server.User.PlayerStatistics;
using NetCoreServer.ServerInterface;

namespace NetCoreServer.Server.Auth
{
    public class AuthProvider
    {
        internal ConnectionProvider ConnectionProv;

        public void Login(string username, string password, string token)
        {
            try
            {
                var req = $"SELECT * FROM users WHERE username = '{username}' AND password = '{password}' AND token = '{token}'";
                var responseCode = DatabaseProvider.CreateRequest(ConnectionProv.DbaseProvider, req);
                FormsManaging.TextGenerator(responseCode.Length.ToString());
                using (var ms = new MemoryStream(responseCode))
                {
                    using (var reader = new BinaryReader(ms))
                    {
                        var first = reader.ReadByte();
                        switch (first)
                        {
                            case 0:
                                FormsManaging.TextGenerator("There are some troubles so user can't login");
                                break;
                            case 1:
                                FormsManaging.TextGenerator($"{username} logged in!");
                                ConnectionProv.Players.Add(new Player(new PlayerAccountInfo(username, token), new PlayerMultiplayerInfo()));
                                break;
                        }
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                FormsManaging.TextGenerator(ex.ToString());
            }
        }

        public void CreateAccount(string username, string email, string password)
        {
            try
            {
                var req =
                    $"INSERT INTO users (username, password, email, regTime, token) VALUES ({username}, {password}, {email}" +
                    $", {DateTime.Now.ToString("s")}, {Guid.NewGuid().ToString()})";//INSERT.InsertRequest("users", Items.GetRegisterList(), Items.SetRegisterList(data));
                DatabaseProvider.CreateRequest(ConnectionProv.DbaseProvider, req);
            }

            catch (Exception ex)
            {
                FormsManaging.TextGenerator(ex.ToString());
            }
        }

        public void LogOut(string token)
        {
            ConnectionProv.Players.Remove(ConnectionProv.Players.FirstOrDefault(x => x.AccountInfo.Token == token));
            DatabaseProvider.CreateRequest(ConnectionProv.DbaseProvider, $"update users set token = '0' where token = '{token}'");
        }
    }
}