using System.IO;
using System.Net.Sockets;
using NetCoreServer.Server.User.PlayerStatistics;

namespace NetCoreServer.Server.User
{
    public class Player
    {
        internal PlayerMultiplayerInfo MultiplayerInfo;
        internal PlayerAccountInfo AccountInfo;

        public Player(PlayerAccountInfo accountInfo, PlayerMultiplayerInfo multiplayerInfo)
        {
            AccountInfo = accountInfo;
            MultiplayerInfo = multiplayerInfo;
        }

        private void ReturnImage()
        {
            var fs = new FileStream(@"Resources/saitama.jpg", FileMode.Open, FileAccess.Read );
        }
    }
}