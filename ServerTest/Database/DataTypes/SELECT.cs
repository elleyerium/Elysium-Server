using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTest.Database.DataTypes
{
    class SELECT
    {
        public static string command;
        public static string SelectLoginRequest(string TableName, string columns, string data)
        {
            command = null;
            try
            {
                string[] ColumnsData = new string[columns.Split(' ').Count()];
                string[] dbData = new string[data.Split(' ').Count()];
                dbData = data.Split(' ');
                ColumnsData = columns.Split(',');
                

                command = $"SELECT * FROM {TableName} WHERE {ColumnsData[0]} = '{dbData[0]}'";
                for (int i = 1; i < ColumnsData.Length; i++)
                {
                    Server.ServerInterface.FormsManaging.TextGenerator(ColumnsData[i]);
                    command += $" AND {ColumnsData[i]} = '{dbData[i]}'";
                }
            }
            catch (Exception ex)
            {
                Server.ServerInterface.FormsManaging.TextGenerator(ex.ToString());
            }
            return command;
        }
    }
}
