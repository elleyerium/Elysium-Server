using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerTest.Database.DataTypes;
using ServerTest.Database;
using ServerTest.Server.ServerInterface;
using MySql.Data.MySqlClient;

namespace ServerTest.Server.User.Leaderboards
{
    class MainLeaderboard
    {
        public static string RequestLeaderboards()
        {
            string count = RequestToDB.CreateRequest(SELECT.SelectData("*", "scores", "score"), "GetLeaderboardsRequest");
            int CountOfItems = count.Split(' ').Count();
            List <LeaderList> result = new List<LeaderList>(CountOfItems);
            for (int i = 0; i < result.Capacity; i++)
            {
                result.Add(new LeaderList() { data = count });
            }
            var responce = count;
            return responce;
        }
    }

    class LeaderList
    {
        public string data { get; set; }
    }
}
