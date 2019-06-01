using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreServer.Database;
using NetCoreServer.Database.DataTypes;
using NetCoreServer.Server.Auth;
using NetCoreServer.Server.User.PlayerStatistics;
using NetCoreServer.Server.User.Leaderboards;
using NetCoreServer.ServerInterface;

namespace NetCoreServer.Server.Connector
{
    class ClientAction
    {
        public void Action(string ReceivedData, int id)
        {
            string[] DataArray = ReceivedData.Split('|');
            string request = DataArray.Last();
            string Tag = DataArray.First();
            try
            {
                switch (Tag)
                {
                    case "RegistrationRequest":
                        Register.RegisterProfile(DataArray.Last(), id);
                        Scores.CreateTable(Items.GetScoreList(request), id);
                        break;
                    case "LoginRequest":
                        Login.Auth(DataArray.Last(),id);
                        break;
                    case "SetScoreRequest":
                        Scores.SetUserScores(request, id);
                        break;
                    case "GetScoreRequest":
                        Scores.GetUserScores(Items.GetScoreList(request),id);
                        break;
                    case "GetPlayerStatsPosition":
                        break;
                    case "GetLeaderboardsRequest":
                        MainLeaderboard.RequestLeaderboards(id);
                        break;
                    case "GetClientID" :
                        ServerResponces.SendResponse(Connector.Clients[id], id.ToString());
                        break;
                    default:
                        throw new Exception(Tag);
                }
            }
            catch (Exception ex)
            {
                FormsManaging.TextGenerator(ex.ToString());
            }
        }
    }
}
