using System;
using NetCoreServer.Database;

namespace NetCoreServer.Server.Auth
{
    public class Token
    {
        public uint Id;
        public Guid Guid;
        public DateTime ExpireDate;

        public Token(uint id, Guid guid, DateTime expireDate)
        {
            Id = id;
            Guid = guid;
            ExpireDate = expireDate;
        }

        public void SetToken()
        {

        }

        public void GenerateToken()
        {

        }
    }
}