using System;
using System.Net;
using NetCoreServer.Server.User.PlayerStatistics;

namespace NetCoreServer.Server.User
{
    public class PlayerAccountInfo
    {
        internal string Username;
        internal Guid Token;

        public PlayerAccountInfo(string uname, Guid token)
        {
            Username = uname;
            Token = token;
        }
    }
}