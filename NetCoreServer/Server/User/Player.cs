using System;
using System.IO;
using System.Net.Sockets;
using NetCoreServer.Server.Connector;
using NetCoreServer.Server.User.PlayerStatistics;

namespace NetCoreServer.Server.User
{
    public class Player
    {
        internal PlayerMultiplayerInfo MultiplayerInfo;
        internal PlayerAccountInfo AccountInfo;

        public Player(PlayerAccountInfo accountInfo)
        {
            AccountInfo = accountInfo;
            MultiplayerInfo = ConnectionProvider.DatabaseHandler.GetInfoByUsername(accountInfo.Username);

            Console.WriteLine($"Hello, I am {AccountInfo.Username}, my token is {AccountInfo.Token}, my ID is {AccountInfo.Id}");
        }

        /*private void ReturnImage()
        {
            var fs = new FileStream(@"Resources/saitama.jpg", FileMode.Open, FileAccess.Read );
        }*/
    }
}