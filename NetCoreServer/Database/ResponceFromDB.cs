using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Net.Sockets;
using NetCoreServer.ServerInterface;
using NetCoreServer.Server.Connector;
using NetCoreServer.Server.Connector;
using NetCoreServer.Database.DataTypes;
using Newtonsoft.Json;

namespace NetCoreServer.Database
{
    public class ResponseFromDB
    {
        public string GetException(MySqlException exception)
        {
            //JsonSerializer serializer = new JsonSerializer();
            //serializer.Serialize()

            int exceptionNumber = exception.Number;
            string Responce = null;
            switch (exceptionNumber)
            {
                case 1062:
                    Responce = "Username or email already used.";
                    break;
                default:
                    Responce = "Registered!";
                    break;
            }
            FormsManaging.TextGenerator(Responce);
            return Responce;
        }

        /*public string GetResponse(MySqlDataReader reader, byte[] data, int currID)
        {
            byte response;
            reader.Read();
            using(var memoryStream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(memoryStream))
                {
                    var first = new BinaryReader(new MemoryStream()).ReadByte();
                    switch (first)
                    {
                        case 1:
                            if (reader.HasRows)
                            {
                                writer.Write((byte)0);
                                //ServerResponces.SendResponse(client, memoryStream.ToArray());
                            }
                            else if (!reader.HasRows)
                            {
                                writer.Write((byte)1);
                                //ServerResponces.SendResponse(client, memoryStream.ToArray());
                            }
                            break;

                        case 5:
                            writer.Write((byte)6);
                            var dataAffected = reader.RecordsAffected;
                            if (dataAffected > 0)
                            {
                                writer.Write((byte)0);
                                //ServerResponces.SendResponse(client, memoryStream.ToArray());
                                FormsManaging.TextGenerator("Registered");
                            }
                            else if (dataAffected == 0)
                            {
                                writer.Write((byte)1);
                                //ServerResponces.SendResponse(client, memoryStream.ToArray());
                                FormsManaging.TextGenerator("failed");
                            }
                            break;

                        /*case "GetLeaderboardsRequest":
                            Return = $"{reader["username"]},{reader["score"]}|";
                            while (reader.Read())
                            {
                                Return += $"{reader["username"]},{reader["score"]}|";
                                FormsManaging.TextGenerator(Return);
                            }

                            //ServerResponces.SendResponse(client, Return);
                            break;

                        case "GetScoreRequest":
                            break;

                        case "SetScoreRequest":
                            break;
                            #1#
                        default:
                            return "have no request like this";
                            break;
                    }
                }
            }
        }*/
    }
}
