using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Text;
using NetCoreServer.Database;
using NetCoreServer.ServerInterface;

namespace NetCoreServer.Server.Connector
{
    class Connector
    {
        public const int PORT_NO = 27015;
        public const string SERVER_IP = "192.168.0.106";
        public static TcpListener listener;
        public static List<TcpClient> Clients;
        public static TcpClient client;


        public async void ServerStart()
        {
            Clients = new List<TcpClient>(100000);
            ID.playerID = new List<int>(100000);
            for (int i = 0; i < Clients.Capacity; i++)
            {
                Clients.Add(null);
            }
            FormsManaging.TextGenerator("Server started.");
            DatabaseConnector.ConnectToDB();
            IPAddress localAdd = IPAddress.Any;
            listener = new TcpListener(localAdd, PORT_NO);
            listener.Start();

            while (true)
            {
                 await SyncTask();
            }
        }

        private async Task SyncTask()
        {
            client = await listener.AcceptTcpClientAsync();

            if (!Clients.Contains(client))
            {
                var id = ID.GenerateUniqueId();
                FormsManaging.TextGenerator("Created list!");
                Clients.Insert(id,client);
                ID.idCount++;
                await ConnectFirst(id);
            }
        }

        private async Task AlreadyConnected(int id)
        {
            if (Clients.Contains(client))
            {
                FormsManaging.TextGenerator("Already exists");
                await SynchronizationUser(id);
            }
        }

        private async Task SynchronizationUser(int id)
        {
            FormsManaging.TextGenerator("Synced as already connected user!");
            NetworkStream nwStream = Clients[id].GetStream();
            byte[] bufferReceive = new byte[Clients[id].ReceiveBufferSize];
            int bytesRead = nwStream.Read(bufferReceive, 0, Clients[id].ReceiveBufferSize);
            string dataReceived = Encoding.ASCII.GetString(bufferReceive,0,bytesRead);
            CreateAction(dataReceived, id);

            if (Clients[id].Connected)
            {
                await AlreadyConnected(id);
            }
            else
            {
                Clients[id].Client.Dispose();
            }
        }

        private async Task ConnectFirst(int id)
        {
            FormsManaging.TextGenerator("Synced as new user with id " + id);
            NetworkStream nwStream = Clients[id].GetStream();
            byte[] bufferReceive = new byte[Clients[id].ReceiveBufferSize];
            int bytesRead = nwStream.Read(bufferReceive, 0, Clients[id].ReceiveBufferSize);
            string dataReceived = Encoding.ASCII.GetString(bufferReceive,0,bytesRead);
            CreateAction(dataReceived, id);
            if (Clients[id].Connected)
            {
                await AlreadyConnected(id);
            }
            else
            {
                Clients[id].Client.Dispose();
            }
        }

        private void CreateAction(string receivedData, int id)
        {
            var action = new ClientAction();
            action.Action(receivedData,id);
        }
    }
}