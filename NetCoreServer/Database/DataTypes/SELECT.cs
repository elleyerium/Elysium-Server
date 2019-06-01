using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreServer.Database.DataTypes
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
                    command += $" AND {ColumnsData[i]} = '{dbData[i]}'";
                }
            }
            catch (Exception ex)
            {
                ServerInterface.FormsManaging.TextGenerator(ex.ToString());
            }
            return command;
        }
        public string SelectData(string attributes, string TableName, string sortBy)
        {
            return $"SELECT {attributes} FROM {TableName} ORDER BY {sortBy} DESC";
        }
    }
}
