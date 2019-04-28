﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerTest.Database;
using ServerTest.Database.DataTypes;
using ServerTest.Server.Auth;
using ServerTest.User.PlayerStatistics;

namespace ServerTest.Server.Connector
{
    class ClientAction
    {
        public static string Action(string ReceivedData)
        {
            string[] DataArray = ReceivedData.Split('|');
            string request = DataArray.Last();
            string Tag = DataArray.First();
            try
            {
                switch (Tag)
                {
                    case "RegistrationRequest":
                        Register.RegisterProfile(DataArray.Last());
                        break;
                    case "LoginRequest":
                        Login.Auth(DataArray.Last());
                        break;
                    case "SetScoreRequest":
                        //Tag = "4";
                        break;
                    case "GetScoreRequest":
                        //Tag = "4";
                        break;
                    case "GetPlayerStatsPosition":
                        //Tag = "5";
                        break;
                    default:
                        ServerInterface.FormsManaging.TextGenerator(Tag);
                        throw new Exception(Tag);
                }
            }
            catch (Exception ex)
            {
                ServerInterface.FormsManaging.TextGenerator(request);
            }
            return Tag;
        }
    }
}
