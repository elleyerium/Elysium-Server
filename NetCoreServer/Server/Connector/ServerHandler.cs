using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreServer.Database;
using NetCoreServer.Database.DataTypes;
using NetCoreServer.Server.Auth;
using NetCoreServer.Server.Multiplayer.Leaderboards;
using NetCoreServer.Server.User;
using NetCoreServer.Server.User.PlayerStatistics;
using NetCoreServer.ServerInterface;

namespace NetCoreServer.Server.Connector
{
    class ServerHandler
    {
        public void HandleClientData(byte[] receivedData, ConnectionProvider connectionProvider, int id)
        {
            using (var reader = new BinaryReader(new MemoryStream(receivedData)))
            {
                try
                {
                    var first = reader.ReadByte();
                    FormsManaging.TextGenerator(first.ToString());
                    switch (first)
                    {
                        case 1:
                            var firstCaseByte = reader.ReadByte();
                            switch (firstCaseByte)
                            {
                                 case 1:
                                     connectionProvider.AuthProv.Login(reader.ReadString(), reader.ReadString(), reader.ReadString());
                                     break;
                                 case 2:
                                     connectionProvider.AuthProv.CreateAccount(reader.ReadString(), reader.ReadString(), reader.ReadString());
                                     break;
                                 case 3:
                                     connectionProvider.AuthProv.LogOut(reader.ReadString());
                                     break;
                                 default:
                                     FormsManaging.TextGenerator("Unknown byte!");
                                     break;
                            }
                            break;
                        default:
                            throw new Exception($"Unknown byte {first}");
                    }
                }
                catch (Exception ex)
                {
                    FormsManaging.TextGenerator(ex.ToString());
                }
            }
        }

        public void HandleServerData(byte[] receivedData, ConnectionProvider connectionProvider, int id)
        {
            using (var reader = new BinaryReader(new MemoryStream(receivedData)))
            {
                try
                {
                    var first = reader.ReadByte();
                    FormsManaging.TextGenerator(first.ToString());
                    switch (first)
                    {
                        case 1:
                            var firstCaseByte = reader.ReadByte();
                            switch (firstCaseByte)
                            {
                                case 1:
                                    connectionProvider.AuthProv.Login(reader.ReadString(), reader.ReadString(), reader.ReadString());
                                    break;
                                case 2:
                                    connectionProvider.AuthProv.CreateAccount(reader.ReadString(), reader.ReadString(), reader.ReadString());
                                    break;
                                case 3:
                                    connectionProvider.AuthProv.LogOut(reader.ReadString());
                                    break;
                                default:
                                    FormsManaging.TextGenerator("Unknown byte!");
                                    break;
                            }
                            break;
                        default:
                            throw new Exception($"Unknown byte {first}");
                    }
                }
                catch (Exception ex)
                {
                    FormsManaging.TextGenerator(ex.ToString());
                }
            }
        }
    }
}
