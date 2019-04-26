using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ServerTest.Database
{
    static class ResponceFromDB
    {
        public static string GetResponce(MySqlException exception)
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
            return Responce;
        }
    }
}
