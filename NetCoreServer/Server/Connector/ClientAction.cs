using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreServer.Database;
using NetCoreServer.Database.DataTypes;
using NetCoreServer.Server.Auth;
using NetCoreServer.User.PlayerStatistics;
using NetCoreServer.Server.User.Leaderboards;

namespace NetCoreServer.Server.Connector
{
    class ClientAction
    {
        public static string Action(string ReceivedData)
        {
            string[] DataArray = ReceivedData.Split('|');
            string request = DataArray.Last();
            string Tag = DataArray.First();
            string responce = null;
            try
            {
                switch (Tag)
                {
                    case "RegistrationRequest":
                        Register.RegisterProfile(DataArray.Last());
                        Scores.CreateTable(Items.GetScoreList(request));
                        break;
                    case "LoginRequest":
                        Login.Auth(DataArray.Last());
                        break;
                    case "SetScoreRequest":
                        Scores.SetUserScores(request);
                        break;
                    case "GetScoreRequest":
                        Scores.GetUserScores(Items.GetScoreList(request));
                        break;
                    case "GetPlayerStatsPosition":
                        break;
                    case "GetLeaderboardsRequest":
                        responce = MainLeaderboard.RequestLeaderboards();
                        break;
                    default:
                        throw new Exception(Tag);
                }
            }
            catch (Exception ex)
            {
                ServerInterface.FormsManaging.TextGenerator(ex.ToString());
            }
            return responce;
        }
    }
}
