﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerTest.Server.ClientData;
using ServerTest.Database;
using ServerTest.Database.DataTypes;
using ServerTest.Server.ServerInterface;

namespace ServerTest.Server.Auth
{
    class Login
    {
        public static void Auth(string data)
        {
            try
            {
                var req = SELECT.SelectLoginRequest("users", Items.GetLoginList(), Items.SetLoginList(data));
                RequestToDB.CreateRequest(req);
            }
            catch (Exception ex)
            {
                FormsManaging.TextGenerator(ex.ToString());
            }
        }
    }
}
