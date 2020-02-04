using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using LiteNetLib;
using LiteNetLib.Utils;
using NetCoreServer.Server.User;

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
            var writer = new NetDataWriter();
            switch ((MessageType)reader.GetByte())
            {
                case MessageType.LeaderboardsRequest:
                    ServerOutgoingHandler(MessageType.LeaderboardsResponse, peer, reader);
                    break;
                case MessageType.GetConcurrentUsers:
                    ServerOutgoingHandler(MessageType.GetConcurrentUsersResponse, peer, reader);
                    break;
                case MessageType.GetPlayerStats:
                    ServerOutgoingHandler(MessageType.PlayerStatsResponse, peer, reader);
                    break;
                case MessageType.SendChatMessage:
                    var sender = _connectionProvider.PlayerPool.List.FirstOrDefault(x => x.Peer == peer);

                    if (sender != null)
                    {
                        //writer.Put(sender.AccountInfo.Id);
                        writer.Put(sender.AccountInfo.Username);
                        writer.Put(reader.GetString());
                        writer.Put(sender.PlayerType.ToString());
                    }

                    ConnectionProvider.Broadcast(MessageType.IncomingChatMessage, writer);
                    break;
                case MessageType.UpdateProfileSettings:
                    break;
                case MessageType.GetAvatar:
                    break;
                default:
                    throw new Exception("Invalid MessageType.");
            }
        }

        private void ServerOutgoingHandler(MessageType messageType, NetPeer peer, NetPacketReader reader)
        {
            var writer = new NetDataWriter();
            switch (messageType)
            {
                case MessageType.GetConcurrentUsers:
                    GetConcurrentUsers(writer);
                    break;
                case MessageType.LeaderboardsResponse:
                    break;
                case MessageType.PlayerStatsResponse:
                    writer.Put((byte)MessageType.PlayerStatsResponse);
                    var data = reader.GetUInt();
                    Console.WriteLine($"{data} id received");
                    try
                    {
                        Console.WriteLine(_connectionProvider.PlayerPool.List
                            .FirstOrDefault(x => x.AccountInfo.Id == data)
                            ?.Statistics.Username);
                        writer.Put(_connectionProvider.PlayerPool.List
                            .FirstOrDefault(x => x.AccountInfo.Id == data)
                            ?.Statistics);
                    }
                    catch
                    {
                        // ignored
                    }

                    break;
                case MessageType.GetConcurrentUsersResponse:
                    GetConcurrentUsers(writer);
                    break;
                case MessageType.UpdateProfileSettingsResponse:
                    break;
                case MessageType.GetAvatarResponse:
                    break;
                default:
                    Console.WriteLine();
                    throw new ArgumentOutOfRangeException();
            }
            ConnectionProvider.SendMessage(peer, writer);
        }

        #region 'get' responses

        private void GetConcurrentUsers(NetDataWriter writer)
        {
            var connCount = _connectionProvider.ServerInfo.ConnectionsCount;
            writer.Put((byte)MessageType.GetConcurrentUsersResponse);
            writer.Put(connCount);
            for (var i = 0; i < connCount; i++)
            {
                var id = _connectionProvider.PlayerPool.List[i].AccountInfo.Id;
                writer.Put(id);
            }
        }

        private void GetLeaderboards(NetDataWriter writer)
        {

            /*writer.Put((byte)MessageType.LeaderboardsResponse);
            for (var i = 0; i < connCount; i++)
            {
                writer.Put(_connectionProvider.Holder.List[i].AccountInfo.Username);
                writer.Put(_connectionProvider.Holder.List[i].AccountInfo.Id);
            }*/
        }

        #endregion
    }
}
