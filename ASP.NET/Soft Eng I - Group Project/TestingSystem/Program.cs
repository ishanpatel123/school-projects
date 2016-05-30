using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditSystem.MessageClasses;
namespace TestingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            AuditSystem.SystemClasses.SystemManager SystemMan = new AuditSystem.SystemClasses.SystemManager();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            int OptionChoice = 0;
            while (OptionChoice != 4)
            {
                String Menu = "----------------------------------------" + "\n" +
                              "|    Welcome To The Testing System     |" + "\n" +
                              "|--------------------------------------|" + "\n" +
                              "|1. Send Message To Report Thread      |" + "\n" +
                              "|2. Send Message To Assessor Thread    |" + "\n" +
                              "|3. Send Message To Email Thread       |" + "\n" +
                              "|4. Send Mass Quit Message             |" + "\n" +
                              "|--------------------------------------|" + "\n" + "\n" +
                              "Select an Option: ";
                Console.Write(Menu);

                if (!int.TryParse(Console.ReadLine(), out OptionChoice))
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect Input");
                    Console.WriteLine();
                    Console.Write("Press any key to continue...");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Clear();
                    continue;
                }

                String ConsoleOutput = "";
                switch (OptionChoice)
                {
                    case 1:
                        Menu = "----------------------------------------" + "\n" +
                              "|            Reporting Menu            |" + "\n" +
                              "|--------------------------------------|" + "\n" +
                              "|1. Get Activity Report                |" + "\n" +
                              "|2. Get Monthly Report                 |" + "\n" +
                              "|3. Get Summary Report                 |" + "\n" +
                              "|--------------------------------------|" + "\n" + "\n" +
                              "Select an Option: ";
                        Console.Clear();
                        Console.Write(Menu);
                        if (!int.TryParse(Console.ReadLine(), out OptionChoice))
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Incorrect Input");
                            Console.WriteLine();
                            Console.Write("Press any key to continue...");
                            Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Clear();
                            continue;
                        }

                        switch (OptionChoice)
                        {
                            case 1:
                                ConsoleOutput = SystemMan.SendWork(MessageEnums.MessageType.REPORT, MessageEnums.MessageType.ACTIVITY_REPORT);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                break;
                            case 2:
                                ConsoleOutput = SystemMan.SendWork(MessageEnums.MessageType.REPORT, MessageEnums.MessageType.MONTHLY_REPORT);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                break;
                            case 3:
                                ConsoleOutput = SystemMan.SendWork(MessageEnums.MessageType.REPORT, MessageEnums.MessageType.SUMMARY_REPORT);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                break;
                            default:
                                ConsoleOutput = SystemMan.SendWork(MessageEnums.MessageType.REPORT);
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                        }
                        break;
                    case 2:
                         Menu = "----------------------------------------" + "\n" +
                              "|           Assessment Menu            |" + "\n" +
                              "|--------------------------------------|" + "\n" +
                              "|1. Run Standard Assessment            |" + "\n" +
                              "|2. Run Specialized Assessment         |" + "\n" +
                              "|--------------------------------------|" + "\n" + "\n" +
                              "Select an Option: ";
                        Console.Clear();
                        Console.Write(Menu);
                        
                        if (!int.TryParse(Console.ReadLine(), out OptionChoice))
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Incorrect Input");
                            Console.WriteLine();
                            Console.Write("Press any key to continue...");
                            Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Clear();
                            continue;
                        }

                        switch (OptionChoice)
                        {
                            case 1:
                                ConsoleOutput = SystemMan.SendWork(MessageEnums.MessageType.ASSESSMENT, MessageEnums.MessageType.STANDARD_ASSESSMENT);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                break;
                            case 2:
                                ConsoleOutput = SystemMan.SendWork(MessageEnums.MessageType.ASSESSMENT, MessageEnums.MessageType.SPECIALIZED_ASSESSMENT);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                break;
                            default:
                                ConsoleOutput = SystemMan.SendWork(MessageEnums.MessageType.ASSESSMENT);
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                        }
                        break;
                    case 3:
                        Menu = "----------------------------------------" + "\n" +
                              "|              Email Menu              |" + "\n" +
                              "|--------------------------------------|" + "\n" +
                              "|1. Send Mass Email                    |" + "\n" +
                              "|2. Send Specific Email                |" + "\n" +
                              "|--------------------------------------|" + "\n" + "\n" +
                              "Select an Option: ";
                        Console.Clear();
                        Console.Write(Menu);
                        
                        if (!int.TryParse(Console.ReadLine(), out OptionChoice))
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Incorrect Input");
                            Console.WriteLine();
                            Console.Write("Press any key to continue...");
                            Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Clear();
                            continue;
                        }

                        switch (OptionChoice)
                        {
                            case 1:
                                ConsoleOutput = SystemMan.SendWork(MessageEnums.MessageType.EMAIL, MessageEnums.MessageType.MASS_EMAIL);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                break;
                            case 2:
                                ConsoleOutput = SystemMan.SendWork(MessageEnums.MessageType.EMAIL, MessageEnums.MessageType.SPECIFIC_EMAIL);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                break;
                            default:
                                ConsoleOutput = SystemMan.SendWork(MessageEnums.MessageType.EMAIL);
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                        }
                        break;
                    case 4:  
                        ConsoleOutput = SystemMan.SendWork(AuditSystem.MessageClasses.MessageEnums.MessageType.END);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    default:
                        ConsoleOutput = "Incorrect Option.";
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                }

                Console.WriteLine();
                Console.WriteLine(ConsoleOutput);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Press any key to continue...");
                Console.ReadLine();
                Console.Clear();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Mass Quit Message Detected, Ending Program... ");
            Console.ReadLine();
        }
    }
}
