using System;
using NetCoreServer.Server.Connector;

namespace NetCoreServer
{
    class Starter
    {
        static void Main(string[] args)
        {
            var connectionProvider = new ConnectionProvider();
            _ = connectionProvider.ServerStart();
            while (true)
            {
               Console.Read();
            }
        }
    }
}