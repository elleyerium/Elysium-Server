using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerTest.Server;
using ServerTest.Server.ServerInterface;

namespace ServerTest.Database.DataTypes
{
    class INSERT
    {
        public static string InsertRequest(string TableName, string columns, string data)
        {
            string[] ColumnsData = new string[columns.Split(' ').Count() -1];
            string[] dbData = new string[data.Split(' ').Count() - 1];
            dbData = data.Split(' ');
            ColumnsData =  columns.Split(',');
            string temp = null;
            string tempData = null;

            foreach(string name in ColumnsData)
            {
                
                temp += $"{name},";
            }
            foreach (string name in dbData)
            {

                tempData += $"'{name}',";
            }

            var clearColumns = temp.Remove(temp.LastIndexOf(','), 1);
            var clearData = tempData.Remove(tempData.LastIndexOf(','), 1);
            var command = $"INSERT INTO  {TableName} ({clearColumns}) VALUES ({clearData})";
            return command;
        }
    }
}
