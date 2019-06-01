using System;
using NetCoreServer.Server.Connector;

namespace NetCoreServer
{
    class Starter
    {
        static void Main(string[] args)
        {
            Connector connector = new Connector();
            connector.ServerStart();
            while (true)
            {
            Console.Read();
            }
        }
    }
}