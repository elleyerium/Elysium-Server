using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using LiteNetLib;
using NetCoreServer.Server.Connector;
using NetCoreServer.Server.User;

namespace NetCoreServer
{
    public static class Utils
    {
        public static Player SetUserByEndPoint(NetPeer peer, IEnumerable<Player> players)
        {
            var player = players.FirstOrDefault(x => x.AccountInfo.EndPoint.Equals(peer.EndPoint)); //Find player instance with same IP
            if (player != null)
            {
                return player;
            }
            throw new Exception("Invalid endpoint. Can't find this player.");
        }
    }
}