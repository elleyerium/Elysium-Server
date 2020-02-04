using System.IO;

namespace NetCoreServer.Server.User.Files
{
    public class Avatar
    {
        private readonly string _source;

        public Avatar(string source)
        {
            _source = source;
        }

        public byte[] GetRawData() //Get raw data to create new texture from this information
        {
            var fs = new FileStream($@"{_source}", FileMode.Open, FileAccess.Read);
            var buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            return buffer;
        }
    }
}