﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreServer.Server.Auth;
using NetCoreServer.ServerInterface;

namespace NetCoreServer.Database.DataTypes
{
    class Items
    {
        public static string[] allIndex = new string[4];

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
            return ans;
        }

        public static string GetLoginList()
        {
            string data = ("username, password");
            return data;
        }

        public static string SetLoginList(string data)
        {
            FormsManaging.TextGenerator(allIndex[0]);
            allIndex = data.Split(' ');
            var username = allIndex[0];
            var password = allIndex[1];
            var ans = $"{username} {password}";
            return ans;
        }
        public static string GetScoreList(string data)
        {
            string username = data.Split(' ')[0];
            FormsManaging.TextGenerator(username);
            return username;
        }
        public static string SetUserScore(string data)
        {
            allIndex = data.Split(' ');
            var username = allIndex[0];
            var score = allIndex[1];
            var ans = $"{username} {score}";
            return ans;
        }
    }
}
