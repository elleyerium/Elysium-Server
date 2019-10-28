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

            var exceptionNumber = exception.Number;
            var response = string.Empty;
            switch (exceptionNumber)
            {
                case 1062:
                    response = "Username or email already used.";
                    break;
                default:
                    response = "Registered!";
                    break;
            }
            FormsManaging.TextGenerator(response);
            return response;
        }
    }
}
