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
                            typeNotChosen = false;
                            break;
                        case ("XML"):
                            typeNotChosen = false;
                            break;
                        default:
                            Console.WriteLine("File type incorrect or not supported");
                            break;

                    }
                }
                Console.WriteLine("");
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
                                fileContent = ReadFile.Read(path, ".txt");                              
                                pathIncorrect = false;   
                                break;
                                
                            case "XML":
                                fileContent = ReadFile.Read(path, ".xml");
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
                    catch (System.InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
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
