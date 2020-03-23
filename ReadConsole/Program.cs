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
            //Initialize variables
            string fileType = string.Empty;
            string fileContent = string.Empty;
            bool useProgram = true;

            //Easier to read file
            Console.SetWindowSize(150, 50);
            
            while (useProgram)
            {
                bool encrypted = false;
                bool security = false;
                Roles role = Roles.User;
                bool typeNotChosen = true;
                while (typeNotChosen)
                {
                    Console.WriteLine("Enter file type (TEXT, XML or JSON)");
                    fileType = Console.ReadLine();
                   fileType = fileType.ToUpper();
                    switch (fileType)
                    {
                        case ("TEXT"):
                            typeNotChosen = false;
                            break;

                        case ("XML"):
                            typeNotChosen = false;
                            break;

                        case ("JSON"):
                            typeNotChosen = false;
                            break;
                        default:
                            Console.WriteLine("File type incorrect or not supported");
                            break;
                    }
                }
                Console.WriteLine("");  
                    bool encryptionNotChosen = true;
                    while (encryptionNotChosen)
                    {
                        Console.WriteLine("Is the file encrypted? (y/n)");
                        string encryptionChoice = Console.ReadLine();
                        encryptionChoice = encryptionChoice.ToUpper();
                        switch (encryptionChoice)
                        {
                            case "Y":
                                encryptionNotChosen = false;
                                encrypted = true;
                                break;

                            case "N":
                                encryptionNotChosen = false;
                                break;

                            default:
                                Console.WriteLine("Wrong input. Try again.");
                                break;
                        }
                    }
                    Console.WriteLine("");
                              

                if (fileType == "XML" || fileType == "TEXT")
                {
                    bool securityNotChosen = true;
                    while (securityNotChosen)
                    {
                        Console.WriteLine("Use role based security? (y/n)");
                        string securityChoice = Console.ReadLine();
                        securityChoice = securityChoice.ToUpper();
                        switch (securityChoice)
                        {                           
                            case "Y":
                                securityNotChosen = false;
                                security = true;
                                break;

                            case "N":
                                securityNotChosen = false;
                                break;

                            default:
                                Console.WriteLine("Wrong input. Try again.");
                                break;
                        }
                        Console.WriteLine("");
                    }
                    
                }
                if (security)
                {
                    
                    bool roleChosen = false;
                    while (!roleChosen)
                    {
                        Console.WriteLine("Enter your role: (admin/user)");
                        string roleChoice = Console.ReadLine();
                        roleChoice = roleChoice.ToUpper();
                      switch (roleChoice)
                        {                      
                            case "ADMIN":                           
                                roleChosen = true;
                                role = Roles.Admin;
                                break;
                            case "USER":                            
                                roleChosen = true;
                                // User by default
                                break;
                            default:
                                Console.WriteLine("Role doesn't exist. Try again: (admin/user)");
                                break;
                      }
                        Console.WriteLine("");
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
                                fileContent = ReadFile.Read(path, ".txt", encrypted, role, security);                              
                                pathIncorrect = false;   
                                break;
                                
                            case "XML":
                                fileContent = ReadFile.Read(path, ".xml", encrypted, role, security);
                                pathIncorrect = false;
                                break;
                            case "JSON":
                                fileContent = ReadFile.Read(path, ".json", encrypted, role, security);
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
