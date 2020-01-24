using System;
using System.Net;
using NetCoreServer.Server.User.PlayerStatistics;

namespace NetCoreServer.Server.User
{
    public class PlayerAccountInfo
    {
        internal string Username;
        internal string Token;
        internal EndPoint EndPoint;
        internal int Id;

        public PlayerAccountInfo(string uname, string token, int id, EndPoint endPoint)
        {
            Username = uname;
            Token = token;
            Id = id;
            EndPoint = endPoint;
        }
    }
}