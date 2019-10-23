using System;
using NetCoreServer.Server.Connector;

namespace NetCoreServer
{
    class Starter
    {
        static void Main(string[] args)
        {
            var connector = new Connector();
            connector.ServerStart();
            while (true)
            {
               Console.Read();
            }
        }
    }
}