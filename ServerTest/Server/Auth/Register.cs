using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerTest.Database;
using ServerTest.Database.DataTypes;
using ServerTest.Server.Connector;
using ServerTest.Server.ServerInterface;

namespace ServerTest.Server.Auth
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
