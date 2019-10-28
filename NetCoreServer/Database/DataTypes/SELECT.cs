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
        public static string SelectLoginRequest(string attribute, string tableName, string columns, string data)
        {
            string command = null;
            try
            {
                var columnsData = new string[columns.Split(' ').Length];
                var dbData = new string[data.Split(' ').Length];
                dbData = data.Split(' ');
                columnsData = columns.Split(',');


                command = $"SELECT {attribute} FROM {tableName} WHERE {columnsData[0]} = '{dbData[0]}'";
                for (var i = 1; i < columnsData.Length; i++)
                {
                    command += $" AND {columnsData[i]} = '{dbData[i]}'";
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
