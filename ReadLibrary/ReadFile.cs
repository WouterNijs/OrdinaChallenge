using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadLibrary
{
    public static class ReadFile
    {
        public static string Read(string filePath, string fileExtension)
        {
            if (Path.GetExtension(filePath) == fileExtension)
            {
                try
                {
                    string text = System.IO.File.ReadAllText(filePath);
                    return text;
                }
                catch
                {
                    throw new System.InvalidOperationException("File not found");
                }

            }
            else
            {
                throw new System.InvalidOperationException("Wrong file type");
            }
        }
    }
}
