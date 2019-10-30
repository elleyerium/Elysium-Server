using System;
using System.Net;
using NetCoreServer.Server.User.PlayerStatistics;

namespace NetCoreServer.Server.User
{
    public class PlayerAccountInfo
    {
        internal string Username;
        internal string Token;

        public PlayerAccountInfo(string uname, string token)
        {
            Username = uname;
            Token = token;
        }
    }
}