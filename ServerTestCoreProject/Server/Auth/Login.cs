using System;
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
                var req = SELECT.SelectLoginRequest("*","users", Items.GetLoginList(), Items.SetLoginList(data));
                RequestToDB.CreateRequest(req, "LoginRequest");
            }
            catch (Exception ex)
            {
                FormsManaging.TextGenerator(ex.ToString());
            }
        }
    }
}
