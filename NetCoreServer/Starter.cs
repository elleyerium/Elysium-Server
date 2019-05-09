using System;
using NetCoreServer.Server.Connector;

namespace NetCoreServer
{
    class Starter  
    {
        static void Main(string[] args)
        {
            Connector.ServerStart();
            Console.ReadKey();
        }
    }
}