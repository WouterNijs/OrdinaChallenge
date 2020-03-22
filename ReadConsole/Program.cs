using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadLibrary;

namespace ReadConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //initialize variables
            string fileType = string.Empty;
            string fileContent = string.Empty;
            bool useProgram = true;
            bool encrypted = false;

            while (useProgram)
            {
                bool typeNotChosen = true;
                while (typeNotChosen)
                {
                    Console.WriteLine("Enter file type (TEXT or XML)");
                    fileType = Console.ReadLine();
                    switch (fileType)
                    {
                        case ("TEXT"):
                        case ("text"):
                            typeNotChosen = false;
                            break;
                        case ("xml"):
                        case ("XML"):
                            typeNotChosen = false;
                            break;
                        default:
                            Console.WriteLine("File type incorrect or not supported");
                            break;

                    }
                }
                Console.WriteLine("");

                if (fileType == "TEXT" || fileType == "text")
                {
                    bool encryptionNotChosen = true;
                    while (encryptionNotChosen)
                    {
                        Console.WriteLine("Is the file encrypted? (y/n)");
                        string encryptionChoice = Console.ReadLine();
                        switch (encryptionChoice)
                        {
                            case "y":
                            case "Y":
                                encryptionNotChosen = false;
                                encrypted = true;
                                break;

                            case "n":
                            case "N":
                                encryptionNotChosen = false;
                                break;

                            default:
                                break;
                        }
                    }
                }
                bool pathIncorrect = true;
                while (pathIncorrect)
                {
                    Console.Write("Enter file path:");
                    string path = Console.ReadLine();
                    
                    try
                    {
                        Console.WriteLine("");
                        switch (fileType)
                        {
                            case "TEXT":
                            case "text":
                                fileContent = ReadFile.Read(path, ".txt", encrypted);                              
                                pathIncorrect = false;   
                                break;
                                
                            case "XML":
                            case "xml":
                                fileContent = ReadFile.Read(path, ".xml", encrypted);
                                pathIncorrect = false;
                                break;
                        }
                        if (fileContent != string.Empty)
                        {
                            Utilities.DrawLine();
                            Console.WriteLine(fileContent);
                            Console.WriteLine("");
                            Utilities.DrawLine();
                        }
                        
                    }
                    catch (System.Exception ex)
                    {
                       if (ex is InvalidOperationException)
                        {
                            Console.WriteLine(((InvalidOperationException)ex).Message);
                        }
                       else
                        {
                            Console.WriteLine("Something went wrong");
                        }
                    }
                }
                Console.WriteLine("Press enter to read another file or type 'stop' to stop");
                if (Console.ReadLine() == "stop")
                {
                    useProgram = false;
                    Environment.Exit(0);
                }
            }
            
        }
    }
}
