using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ServerTest.Server.ServerInterface;
using ServerTest.Database.DataTypes;

namespace ServerTest.Database
{
    static class ResponceFromDB
    {
        public static string GetException(MySqlException exception)
        {
            
            int exceptionNumber = exception.Number;
            string Responce = null;
            switch (exceptionNumber)
            {
                case 1062:
                    Responce = "Username or email already used.";
                    break;
                default:
                    Responce = "There aren't any exceptions!";
                    break;
            }
            FormsManaging.TextGenerator(Responce);
            return Responce;
        }

        public static string GetResponce(MySqlDataReader Reader, string Tag)
        {
            string Return = null;
            string data = Tag;
            Reader.Read();
            switch (data)
            {
                case "RegistrationRequest":
                    break;

                case "LoginRequest":
                    if (Reader.HasRows)
                        FormsManaging.TextGenerator("user logged in!");
                    else if (!Reader.HasRows)
                        FormsManaging.TextGenerator("failed to login");
                    break;

                case "GetLeaderboardsRequest":
                    Return = $"{Reader["username"].ToString()},{Reader["score"].ToString()}|";
                    while (Reader.Read())
                    {
                        Return += $"{Reader["username"].ToString()},{Reader["score"].ToString()}|";
                        FormsManaging.TextGenerator(Return);
                    }
                    var clear = Return.Remove(Return.LastIndexOf('|'));
                    FormsManaging.TextGenerator(Return);
                    break;

                case "GetScoreRequest":
                    break;

                case "SetScoreRequest":
                    break;
            }
            return Return;
        }
    }
}
