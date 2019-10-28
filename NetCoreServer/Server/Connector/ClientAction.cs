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
    class ClientAction
    {
        public void Action(byte[] receivedData, ConnectionProvider connectionProvider, int id)
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
                            var username = reader.ReadString();
                            var pass = reader.ReadString();
                            var token = reader.ReadString();
                            FormsManaging.TextGenerator(token);
                            connectionProvider.AuthProv.Login(username, pass, token);
                            break;
                        case 5:
                            var regUsername = reader.ReadString();
                            var regEmail = reader.ReadString();
                            var regPass = reader.ReadString();
                            connectionProvider.AuthProv.CreateAccount(regUsername, regEmail, regPass);
                            break;
                        /*case "GetScoreRequest":
                            Scores.GetUserScores(Items.GetScoreList(request), id);
                            break;
                        case "GetPlayerStatsPosition":
                            break;
                        case "GetLeaderboardsRequest":
                            MainLeaderboard.RequestLeaderboards(id);
                            break;
                        case "GetClientID":
                            ServerResponces.SendResponse(connector.Clients[id], id.ToString());
                            break;*/
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
