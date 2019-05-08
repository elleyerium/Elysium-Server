using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTest.Database.DataTypes
{
    class SELECT
    {
        //public static string command;
        public static string SelectLoginRequest(string attribute, string TableName, string columns, string data)
        {
            string command = null;
            try
            {
                string[] ColumnsData = new string[columns.Split(' ').Count()];
                string[] dbData = new string[data.Split(' ').Count()];
                dbData = data.Split(' ');
                ColumnsData = columns.Split(',');
                

                command = $"SELECT {attribute} FROM {TableName} WHERE {ColumnsData[0]} = '{dbData[0]}'";
                for (int i = 1; i < ColumnsData.Length; i++)
                {
                    //Server.ServerInterface.FormsManaging.TextGenerator(ColumnsData[i]);
                    command += $" AND {ColumnsData[i]} = '{dbData[i]}'";
                }
            }
            catch (Exception ex)
            {
                Server.ServerInterface.FormsManaging.TextGenerator(ex.ToString());
            }
            return command;
        }

        public static string SelectCount(string TableName)
        {
            string command = null;
            command = $"SELECT COUNT(*) FROM {TableName}";
            return command;
        }

        public static string SelectData(string attributes, string TableName, string sortBy)
        {
            string command = null;
            command = $"SELECT {attributes} FROM {TableName} ORDER BY {sortBy} DESC";
            return command;
        }
    }
}
