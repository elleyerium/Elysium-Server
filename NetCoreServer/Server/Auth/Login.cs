using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreServer.Server.ClientData;
using NetCoreServer.Database;
using NetCoreServer.Database.DataTypes;
using NetCoreServer.ServerInterface;
using MySql.Data.MySqlClient;

namespace NetCoreServer.Server.Auth
{
    class Login
    {
        public static void Auth(DatabaseProvider provider, string data, int Id)
        {
            try
            {
                var req = SELECT.SelectLoginRequest("*","users", Items.GetLoginList(), Items.SetLoginList(data));
                //RequestToDB.CreateRequest(provider, "LoginRequest", Id);
            }
            catch (Exception ex)
            {
                FormsManaging.TextGenerator(ex.ToString());
            }
        }
    }
}
