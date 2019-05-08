using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Net.Sockets;
using NetCoreServer.Server.ServerInterface;
using NetCoreServer.Server.Connector;
using NetCoreServer.Database.DataTypes;
using Newtonsoft.Json;

namespace NetCoreServer.Database
{
    static class ResponceFromDB
    {
        public static string GetException(MySqlException exception)
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

        public static void GetResponce(MySqlDataReader Reader, string Tag)
        {
            TcpClient client = new TcpClient();
            client = Connector.client;
            string Return = null;
            string data = Tag;
            Reader.Read();
            switch (data)
            {
                case "RegistrationRequest":
                    int dataAffected = Reader.RecordsAffected;
                    if (dataAffected > 0)
                    {
                        ServerResponces.SendResponse(client, "Registered");
                        FormsManaging.TextGenerator("Registered");
                    }
                    else if(dataAffected == 0)
                    {
                        ServerResponces.SendResponse(client, "Failed to register!");
                        FormsManaging.TextGenerator("failed");
                    }
                    break;

                case "LoginRequest":
                    if (Reader.HasRows)
                       ServerResponces.SendResponse(client, "logged in!");
                    else if (!Reader.HasRows)
                       ServerResponces.SendResponse(client, "Failed to login!");
                    break;

                case "GetLeaderboardsRequest":
                    Return = $"{Reader["username"].ToString()},{Reader["score"].ToString()}|";
                    while (Reader.Read())
                    {
                        Return += $"{Reader["username"].ToString()},{Reader["score"].ToString()}|";
                        FormsManaging.TextGenerator(Return);
                    }

                    var clear = Return.Remove(Return.LastIndexOf('|'));
                    ServerResponces.SendResponse(client, Return);
                    break;

                case "GetScoreRequest":
                    break;

                case "SetScoreRequest":
                    break;
                default:
                    Return = "have no request like this";
                    break;
            }
        }
    }
}
