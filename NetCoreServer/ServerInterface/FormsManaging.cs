using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreServer.ServerInterface
{

    public class FormsManaging
    {
        public static int size;
        public static void TextGenerator(string Message)
        {
            Console.WriteLine( $"{DateTime.Now.ToString()} ---> {Message}");
        }
    }
}
