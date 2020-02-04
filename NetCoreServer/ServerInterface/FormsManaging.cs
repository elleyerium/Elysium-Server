using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreServer.ServerInterface
{
    public static class FormsManaging
    {
        public static void TextGenerator(string message)
        {
            Console.WriteLine( $"{DateTime.Now.ToString(CultureInfo.InvariantCulture)} ---> {message}");
        }
    }
}
