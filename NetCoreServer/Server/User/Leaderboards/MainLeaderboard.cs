using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreServer.Database.DataTypes;
using NetCoreServer.Database;
using NetCoreServer.ServerInterface;

namespace NetCoreServer.Server.User.Leaderboards
{
    class MainLeaderboard
    {
        public static string RequestLeaderboards(int id)
        {
            SELECT Select = new SELECT();
            string count = RequestToDB.CreateRequest(Select.SelectData("*", "scores", "score"), "GetLeaderboardsRequest", id);
            int CountOfItems = count.Split(' ').Count();
            List <LeaderList> result = new List<LeaderList>(CountOfItems);
            for (int i = 0; i < result.Capacity; i++)
            {
                result.Add(new LeaderList { data = count });
            }
            return count;
        }
    }

    class LeaderList
    {
        public string data { get; set; }
    }
}
