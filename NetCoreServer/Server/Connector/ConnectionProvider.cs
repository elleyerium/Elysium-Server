using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using MySql.Data.MySqlClient;
using NetCoreServer.Database;
using NetCoreServer.Server.Auth;
using NetCoreServer.Server.User;
using NetCoreServer.ServerInterface;

namespace NetCoreServer.Server.Connector
{
    internal class ConnectionProvider
    {
        private const int Port = 27015;
        private const string ServerAddress = "127.0.0.1";
        private TcpListener _listener;
        public List<Player> Players;
        public PlayersHolder Holder;
        public DatabaseProvider DbaseProvider;
        public AuthProvider AuthProv;

        public async Task ServerStart()
        {
            Holder = new PlayersHolder();
            Players = new List<Player>();
            DbaseProvider = new DatabaseProvider(new ResponseFromDB(), new MySqlConnection())
            {
                ConnectionProv = this
            };

            DbaseProvider.ConnectToDB();
            AuthProv = new AuthProvider()
            {
                ConnectionProv = this
            };
            var localAdd = IPAddress.Any;
            _listener = new TcpListener(localAdd, Port);
            _listener.Start();

            while (true)
            {
                await SyncTask();
            }
        }

        private async Task SyncTask()
        {
            var cl = await _listener.AcceptTcpClientAsync();
            SynchronizationUser(new Guid(), cl);
            //await SynchronizationUser(new Guid(), client);
        }

        private void SynchronizationUser(Guid giud, TcpClient tcpClient)
        {
            FormsManaging.TextGenerator("New client available!");
            var nwStream = tcpClient.GetStream();
            FormsManaging.TextGenerator("GetStream");
            var buffer = new byte[tcpClient.ReceiveBufferSize];
            FormsManaging.TextGenerator(buffer.Length.ToString());
            FormsManaging.TextGenerator("Receive buffer size");
            nwStream.Read(buffer, 0, buffer.Length);
            FormsManaging.TextGenerator("Read");
            CreateAction(buffer, 0);
            FormsManaging.TextGenerator("Action created");
            /*var nwStream = Players.FirstOrDefault(x => x.)GetStream();
            var bufferReceive = new byte[Players[id].Client.ReceiveBufferSize];
            var bytesRead = nwStream.Read(bufferReceive, 0, Players[id].ReceiveBufferSize);
            var action = CreateAction(bufferReceive, id);*/ //TODO: fix

            /*if (Clients[id].Connected)
            {
                await AlreadyConnected(id);
            }
            else
            {
                Clients.Remove(Clients[id]);
            }*/
        }

        private void CreateAction(byte[] data, int id)
        {
            var action = new ClientAction();
            action.Action(data, this, id);
        }

        public void BroadcastData()
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(memoryStream))
                {

                }
            }

        }
    }
}

/*private async Task AlreadyConnected(int id)
{
    if (Players.Contains(client))
    {
        FormsManaging.TextGenerator("Already exists");
        await SynchronizationUser(id);
    }
}*/
/*private async Task ConnectFirst(int id)
{
    FormsManaging.TextGenerator("Synced as new user with id " + id);
    NetworkStream nwStream = Clients[id].GetStream();
    byte[] bufferReceive = new byte[Clients[id].ReceiveBufferSize];
    int bytesRead = nwStream.Read(bufferReceive, 0, Clients[id].ReceiveBufferSize);
    string dataReceived = Encoding.ASCII.GetString(bufferReceive,0,bytesRead);
    CreateAction(dataReceived, id);
    if (Clients[id].Connected)
        await AlreadyConnected(id);
    else Clients[id].Client.Dispose();
}

} */
