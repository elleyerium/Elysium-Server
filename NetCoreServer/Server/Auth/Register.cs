using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreServer.Database;
using NetCoreServer.Database.DataTypes;
using NetCoreServer.Server.Connector;
using NetCoreServer.Server.ServerInterface;

namespace NetCoreServer.Server.Auth
{
    class Register
    {     
        public static void RegisterProfile(string data)
        {        
            try
            {
              var req = INSERT.InsertRequest("users", Items.GetRegisterList(), Items.SetRegisterList(data));
              RequestToDB.CreateRequest(req, "RegistrationRequest");
            }

            catch (Exception ex)
            {
              FormsManaging.TextGenerator(ex.ToString());
            }
        }       
    }
}
