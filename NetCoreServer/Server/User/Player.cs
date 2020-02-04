using System;
using System.IO;
using System.Net.Sockets;
using LiteNetLib;
using LiteNetLib.Utils;
using NetCoreServer.Server.Connector;

namespace NetCoreServer.Server.User
{
    public class Player
    {
        public readonly PlayerStatistics Statistics;
        public readonly PlayerAccountInfo AccountInfo;
        public PlayerType PlayerType;
        public NetPeer Peer;

        public Player(PlayerAccountInfo accountInfo)
        {
            AccountInfo = accountInfo;
            Statistics = ConnectionProvider.DatabaseHandler.GetInfoByUsername(accountInfo.Username);
            Statistics.Id = AccountInfo.Id;
        }
    }
}