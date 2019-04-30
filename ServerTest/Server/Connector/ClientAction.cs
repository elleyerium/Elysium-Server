using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerTest.Database;
using ServerTest.Database.DataTypes;
using ServerTest.Server.Auth;
using ServerTest.User.PlayerStatistics;
using ServerTest.Server.User.Leaderboards;

namespace ServerTest.Server.Connector
{
    class ClientAction
    {
        public static string Action(string ReceivedData)
        {
            string[] DataArray = ReceivedData.Split('|');
            string request = DataArray.Last();
            string Tag = DataArray.First();
            string responce = "1";
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
