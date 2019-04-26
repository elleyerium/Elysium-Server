using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Text;
using ServerTest.Database;
using ServerTest.Server.ServerInterface;

namespace ServerTest.Server.Connector
{
    class Connector
    {
        public const int PORT_NO = 5000;
        public const string SERVER_IP = "127.0.0.1";
        public static TcpListener listener;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UI());
            
        }

        public static async void ServerStart()
        {
            FormsManaging.TextGenerator("Server started.");
            IPAddress localAdd = IPAddress.Parse(SERVER_IP);
            listener = new TcpListener(localAdd, PORT_NO);
            FormsManaging.TextGenerator("Listening...");
            //RequestToDB.CreateRequest("ALTER TABLE users ADD regTime TIMESTAMP DEFAULT NOW()");

            while (true)
            {

                 await SyncTask();
                
            }
        }

        public static async Task SyncTask()
        {
            Task sync = new Task(action:listener.Start);
            listener.Start();
            TcpClient client = await listener.AcceptTcpClientAsync();
            NetworkStream nwStream = client.GetStream();
            byte[] bufferreceive = new byte[client.ReceiveBufferSize];
            int bytesRead = nwStream.Read(bufferreceive, 0, client.ReceiveBufferSize);      
            String dataReceived = Encoding.ASCII.GetString(bufferreceive);
            ClientAction.Action(dataReceived);
            client.Close();
            listener.Stop();
            return;
        }
    }
}