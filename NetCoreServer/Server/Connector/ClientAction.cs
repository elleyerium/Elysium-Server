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
        public void Action(byte[] receivedData, Connector connector, int id)
        {
            using (var reader = new BinaryReader(new MemoryStream(receivedData)))
            {
                try
                {
                    var first = reader.ReadByte();
                    switch (first)
                    {
                        case 1:
                            var uname = reader.ReadString();
                            //Login.Auth(uname, id);
                            //connector.Holder.List.Add(new Player(new PlayerAccountInfo(uname), new PlayerMultiplayerInfo()));
                            break;
                        case 5:
                            Register.RegisterProfile(reader.ReadString(), id);
                            Scores.CreateTable(Items.GetScoreList(reader.ReadString()), id);
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
