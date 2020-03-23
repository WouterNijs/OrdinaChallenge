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
        public static string Read(string filePath, string fileExtension, bool encrypted, Roles role)
        {
            if (Path.GetExtension(filePath) == fileExtension)
            {
                try
                {
                    if (role == Roles.Admin)
                    {
                        if (encrypted)
                        {
                            string text = Encryption.Translate(System.IO.File.ReadAllText(filePath));
                            return text;
                        }
                        else
                        {
                            string text = System.IO.File.ReadAllText(filePath);
                            return text;
                        }
                    }
                    else
                    {
                        if(!filePath.Contains("ADMIN")) //Example of files that cannot be read
                        {
                            if (encrypted)
                            {
                                string text = Encryption.Translate(System.IO.File.ReadAllText(filePath));
                                return text;
                            }
                        else
                        {
                                string text = System.IO.File.ReadAllText(filePath);
                                return text;
                            }
                        }   
                        else
                        {
                            string text = "Access level not valid";
                            return text;
                        }
                    }
                    
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
