using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreServer.Database;
using NetCoreServer.Database.DataTypes;
using NetCoreServer.Server.Connector;
using NetCoreServer.ServerInterface;

namespace NetCoreServer.Server.Auth
{
    public static class Register
    {
        public static void RegisterProfile(string data, int ID)
        {
            try
            {
              var req = INSERT.InsertRequest("users", Items.GetRegisterList(), Items.SetRegisterList(data));
              //RequestToDB.CreateRequest(req, "RegistrationRequest", ID);
            }

            catch (Exception ex)
            {
              FormsManaging.TextGenerator(ex.ToString());
            }
        }
    }
}
