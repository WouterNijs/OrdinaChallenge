using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadLibrary
{
   public static class Encryption
    {
        public static string Translate(string data)
        {
            char[] charArray = data.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
