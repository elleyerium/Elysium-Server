
using System;
using LiteNetLib.Utils;

namespace NetCoreServer.Server.User
{
    public class PlayerStatistics : INetSerializable
    {
        public uint Id;
        public string Username;
        public uint Rank;
        public ushort Level;
        public ushort Exp;
        public uint Score;
        public ushort SpacePoints;

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(Id);
            writer.Put(Username);
            writer.Put(Rank);
            writer.Put(Level);
            writer.Put(Exp);
            writer.Put(Score);
            writer.Put(SpacePoints);
        }

        public void Deserialize(NetDataReader reader)
        {
            Console.WriteLine("1");
        }
    }
}