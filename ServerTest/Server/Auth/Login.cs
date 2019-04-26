using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerTest.Server.ClientData;
using ServerTest.Database;

namespace ServerTest.Server.Auth
{
    class Login
    {
        public static void Auth(string data)
        {
            string[] Alldata = data.Split(',');
            var receivedName = Alldata[0];
            var receivedPass = Alldata[1];
            RequestToDB.CreateRequest("SELECT ");
        }
    }
}
