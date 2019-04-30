using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace ServerTest.Server.Connector
{
    class ServerResponces
    {
        public static void SendResponse(TcpClient client, string Message)
        {
            NetworkStream stream = client.GetStream();
            byte[] responce = Encoding.ASCII.GetBytes(Message);
            stream.Write(responce, 0, responce.Length);
        }
    }
}