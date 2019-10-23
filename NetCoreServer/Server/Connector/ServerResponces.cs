using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;


namespace NetCoreServer.Server.Connector
{
    class ServerResponces
    {
        public static void SendResponse(TcpClient client, byte[] data)
        {
            var stream = client.GetStream();
            stream.WriteAsync(data, 0, data.Length);
        }
    }
}