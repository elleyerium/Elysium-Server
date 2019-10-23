using System;
using System.Collections;
using System.Collections.Generic;
using NetCoreServer.ServerInterface;

namespace NetCoreServer.Server.Connector
{
    public static class ID
    {
        public static int idCount = -1;
        public static List<int> playerID;

        public static int GenerateUniqueId()
        {
            var value = RandomizeId();
            if (!playerID.Contains(value))
            {
                playerID.Add(value);
                //return value;
            }
            else if (!playerID.Contains(value))
            {
                GenerateUniqueId();
            }
            FormsManaging.TextGenerator(value.ToString());
            return value;
        }

        private static int RandomizeId()
        {
            var random = new Random();
            var value = random.Next(0, 100000);
            return value;
        }
    }
}