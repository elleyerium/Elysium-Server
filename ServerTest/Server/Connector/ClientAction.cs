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
        private static string Prepare(string text)
        {
            return text.Substring(0, text.IndexOf('\0'));
        }
        public static string Action(string ReveivedTag)
        {
            var tag = Prepare(ReveivedTag);
            switch (tag)
            {
                case "RegistrationRequest":
                    RequestToDB.CreateRequest(INSERT.InsertRequest("scores", Items.GetRegisterList(), Items.SetRegisterList(tag)));
                    break;
                case "LoginRequest":
                    //tag = "2";
                    break;
                case "SetScoreRequest":
                    //tag = "4";
                    break;
                case "GetScoreRequest":
                    //tag = "4";
                    break;
                case "GetPlayerStatsPosition":
                    //tag = "5";
                    break;
                default:
                    ServerInterface.FormsManaging.TextGenerator(tag);
                    throw new Exception(tag);
            }
            return tag;
        }
    }
}