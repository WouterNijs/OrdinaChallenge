using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadConsole
{
   public static class Utilities
    {
        public static void DrawLine()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-"); 
            }
            Console.WriteLine("");
        }
    }
}
