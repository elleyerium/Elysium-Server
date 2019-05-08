﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreServer.Database;
using NetCoreServer.Server;
using NetCoreServer.Database.DataTypes;
using Newtonsoft.Json;
namespace NetCoreServer.User.PlayerStatistics
{
    class Scores
    {
        public static void CreateTable(string username)
        {
            var data = INSERT.InsertRequest("scores", "username", username);
            RequestToDB.CreateRequest(data, "CreateTable");

        }
        public static void GetUserScores(string username)
        {
            RequestToDB.CreateRequest(SELECT.SelectLoginRequest("score","scores","username",Items.GetScoreList(username)),"GetScoreRequest");
        }

        public static void SetUserScores(string data)
        {
            var request = INSERT.InsertRequest($"scores", "score", data);
            RequestToDB.CreateRequest(request,"SetScoreRequest");
        }
    }
}
