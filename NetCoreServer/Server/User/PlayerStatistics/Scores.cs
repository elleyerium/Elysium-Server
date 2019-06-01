using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreServer.Database;
using NetCoreServer.Server;
using NetCoreServer.Database.DataTypes;
using Newtonsoft.Json;
namespace NetCoreServer.Server.User.PlayerStatistics
{
    class Scores
    {
        public static void CreateTable(string username, int id)
        {
            var data = INSERT.InsertRequest("scores", "username", username);
            RequestToDB.CreateRequest(data, "CreateTable", id);

        }
        public static void GetUserScores(string username, int id)
        {
            RequestToDB.CreateRequest(SELECT.SelectLoginRequest("score","scores","username",Items.GetScoreList(username)),"GetScoreRequest", id);
        }

        public static void SetUserScores(string data, int id)
        {
            var request = INSERT.InsertRequest("scores", "score", data);
            RequestToDB.CreateRequest(request,"SetScoreRequest", id);
        }
    }
}
