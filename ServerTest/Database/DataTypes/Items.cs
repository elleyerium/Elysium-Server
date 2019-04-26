using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerTest.Server.Auth;
using ServerTest.Server.ServerInterface;

namespace ServerTest.Database.DataTypes
{
    class Items
    {
        public static string[] allIndex = new string[3];

        public static string GetRegisterList()
        {
            string data = ("username, password, email");
            return data;
        }

        public static string SetRegisterList(string data)
        {
            allIndex = data.Split(' ');
            var username = allIndex[0];
            var EncryptedPass = allIndex[1];
            var email = allIndex[2];
            var ans = $"{username} {EncryptedPass} {email}";
            FormsManaging.TextGenerator(ans);
            return ans;
        }
    }
}
