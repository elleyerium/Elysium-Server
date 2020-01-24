using System;
using System.Globalization;
using NetCoreServer.Server.Connector;

namespace NetCoreServer
{
    public class Starter
    {
        private static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            var connectionProvider = new ConnectionProvider();
            connectionProvider.Start();
            while (true)
            {
               Console.Read();
            }
        }
    }
}