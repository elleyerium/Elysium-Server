using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using LiteNetLib;
using LiteNetLib.Utils;
using MySql.Data.MySqlClient;
using NetCoreServer.Database;
using NetCoreServer.Server.Auth;
using NetCoreServer.Server.Statistics;
using NetCoreServer.Server.User;
using NetCoreServer.Server.User.PlayerStatistics;

namespace NetCoreServer.Server.Connector
{
    internal class ConnectionProvider
    {
        private const int Port = 27015;
        private const string ServerAddress = "127.0.0.1";
        private ServerHandler _serverHandler;
        public ServerInfo ServerInfo = new ServerInfo();
        public static NetManager Server;
        public PlayersHolder Holder;
        public static DatabaseProvider DatabaseHandler;
        //public AuthProvider AuthProv;

        public void Start()
        {
            var listener = new EventBasedNetListener(); //Create base listener
            _serverHandler = new ServerHandler(this); //Create handler for all data transferred between server and clients
            DatabaseHandler = new DatabaseProvider(new MySqlConnection()); //Handler for database connections
            DatabaseHandler.Connect();
            Holder = new PlayersHolder(); //PlayersHolder that contains list with all active players
            Server = new NetManager(listener); //NetManager for server instance;
            Server.Start(Port);

            listener.ConnectionRequestEvent += request => //Event that handle all incoming connections
            {
                if (Server.PeersCount < 1000 /* max connections */)
                {
                    var byteValue = request.Data.GetByte();
                    switch (byteValue)
                    {
                        case 1:
                            var authName = request.Data.GetString();
                            var authPass = request.Data.GetString();

                            if (!DatabaseHandler.AuthenticateUser(authName, authPass)) //Read token and compare with known tokens
                            {
                                request.Reject();
                                return;
                            }
                            request.Accept(); //Accept connection if true
                            Holder.List.Add(new Player(new PlayerAccountInfo(authName, DatabaseHandler.GetTokenByName(authName),
                                DatabaseHandler.GetIdByUsername(authName), request.RemoteEndPoint)));
                            break;
                        case 2:
                            var regName = request.Data.GetString();
                            var regPass = request.Data.GetString();
                            var email = request.Data.GetString();

                            if (!DatabaseHandler.RegisterAccount(regName, regPass, email,
                                Guid.NewGuid().ToString().Substring(0, 32)))
                            {
                                request.Reject();
                                return;
                            }
                            request.Accept(); //Accept connection if true
                            Holder.List.Add(new Player(new PlayerAccountInfo(regName, DatabaseHandler.GetTokenByName(regName),
                                DatabaseHandler.GetIdByUsername(regName), request.RemoteEndPoint)));
                            break;//TODO: Check if user already exists
                    }
                    //Add player to our list. We are trying to find it's ID and Name params by given token
                }
                else //Else reject connection and close socket
                {
                    var writer = new NetDataWriter();// Create writer class
                    writer.Put("Invalid token. Cya!");
                    request.Reject(writer);
                }
            };

            listener.PeerConnectedEvent += peer => //Actions we should do whenever new user connected
            {
                var player = Utils.SetUserByEndPoint(peer, Holder.List);

                var writer = new NetDataWriter();
                writer.Put((byte)MessageType.AuthorizationResponse);
                writer.Put($"Hello {player.AccountInfo.Username}! You need to save your token! {player.AccountInfo.Token}");//Tell client about connection status
                peer.Send(writer, DeliveryMethod.ReliableOrdered);//Send with reliability

                writer.Reset();
                writer.Put(player.AccountInfo.Username);
                writer.Put(player.AccountInfo.Id);
                Broadcast(MessageType.UserConnected, writer);
                ServerInfo.ConnectionsCount = Server.GetPeersCount(ConnectionState.Connected);
            };

            listener.NetworkReceiveEvent += (peer, reader, method) => //Here we need to handle our next action. Depends on action type.
            {
                _serverHandler.ServerIncomingHandler(reader, peer);
                reader.Recycle();
            };

            listener.PeerDisconnectedEvent += (peer, info) =>
            {
                var player = Utils.SetUserByEndPoint(peer, Holder.List);

                var writer = new NetDataWriter();
                writer.Put(player.AccountInfo.Id);
                Broadcast(MessageType.UserDisconnected, writer);
                ServerInfo.ConnectionsCount = Server.GetPeersCount(ConnectionState.Connected);
            };

            while (!Console.KeyAvailable)
            {
                Server.PollEvents();
                Thread.Sleep(15);
            }
            Server.Stop();
        }

        public static void SendMessage(NetPeer peer, NetDataWriter writer)
        {
            peer.Send(writer, DeliveryMethod.ReliableOrdered);
        }

        public static void Broadcast(MessageType messageType, NetDataWriter netDataWriter)
        {
            var data = netDataWriter.CopyData();
            netDataWriter.Reset();
            netDataWriter.Put((byte)messageType);
            netDataWriter.Put(data);
            Server.SendToAll(netDataWriter, DeliveryMethod.ReliableOrdered);
        }
    }
}
