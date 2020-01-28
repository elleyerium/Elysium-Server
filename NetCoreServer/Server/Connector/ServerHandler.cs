using System;
using LiteNetLib;
using LiteNetLib.Utils;

namespace NetCoreServer.Server.Connector
{
    class ServerHandler
    {
        private readonly ConnectionProvider _connectionProvider;

        public ServerHandler(ConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public void ServerIncomingHandler(NetPacketReader reader, NetPeer peer)
        {
            switch ((MessageType)reader.GetByte())
            {
                case MessageType.LeaderboardsRequest:
                    break;
                case MessageType.GetConcurrentUsers:
                    ServerOutgoingHandler(MessageType.GetConcurrentUsers, peer);
                    break;
                default:
                    throw new Exception("Invalid MessageType.");
            }
        }

        private void ServerOutgoingHandler(MessageType messageType, NetPeer peer)
        {
            var writer = new NetDataWriter();
            switch (messageType)
            {
                case MessageType.GetConcurrentUsers:
                    var connCount = _connectionProvider.ServerInfo.ConnectionsCount;
                    writer.Put((byte)MessageType.GetConcurrentUsersResponse);
                    writer.Put(connCount);
                    for (var i = 0; i < connCount; i++)
                    {
                        writer.Put(_connectionProvider.Holder.List[i].AccountInfo.Username);
                        writer.Put(_connectionProvider.Holder.List[i].AccountInfo.Id);
                    }
                    break;
                case MessageType.LeaderboardsResponse:
                    break;
                case MessageType.PlayerStatsResponse:
                    break;
                default:
                    Console.WriteLine();
                    throw new ArgumentOutOfRangeException();
            }
            ConnectionProvider.SendMessage(peer, writer);
        }
    }
}
