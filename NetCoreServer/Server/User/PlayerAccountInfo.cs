using System;
using System.Net;
using NetCoreServer.Database;
using NetCoreServer.Server.Connector;
using NetCoreServer.Server.User.Files;

namespace NetCoreServer.Server.User
{
    public class PlayerAccountInfo
    {
        internal readonly Avatar Avatar;
        internal readonly string Username;
        internal readonly string Token;
        internal readonly EndPoint EndPoint;
        internal readonly uint Id;

        public PlayerAccountInfo(string username, string token, uint id, EndPoint endPoint)
        {
            Username = username;
            Token = token;
            Id = id;
            EndPoint = endPoint;
            Avatar = new Avatar(ConnectionProvider.DatabaseHandler.GetAvatarSource(username));
        }
    }
}