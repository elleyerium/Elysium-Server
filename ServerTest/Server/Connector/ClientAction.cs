using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerTest.Database;
using ServerTest.Database.DataTypes;
using ServerTest.Server.Auth;
using ServerTest.User.PlayerStatistics;

namespace ServerTest.Server.Connector
{
    class ClientAction
    {
        public static string Action(string ReceivedData)
        {
            string[] s = new string[ReceivedData.Split('|').Count()];
            s = ReceivedData.Split('|');

            string Tag = s.Last();
            //ServerInterface.FormsManaging.TextGenerator(Tag);

            switch (Tag)
            {
                case "RegistrationRequest":
                    RequestToDB.CreateRequest(INSERT.InsertRequest("scores", Items.GetRegisterList(), Items.SetRegisterList(Tag)));
                    break;
                case "LoginRequest":
                    //Tag = "2";
                    break;
                case "SetScoreRequest":
                    //Tag = "4";
                    break;
                case "GetScoreRequest":
                    //Tag = "4";
                    break;
                case "GetPlayerStatsPosition":
                    //Tag = "5";
                    break;
                default:
                    ServerInterface.FormsManaging.TextGenerator(Tag);
                    throw new Exception(Tag);
            }
            return Tag;
        }
    }
}
