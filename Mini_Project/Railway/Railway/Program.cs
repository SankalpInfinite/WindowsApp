using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway
{
    class Program
    {
        static RailwayEntities ral = new RailwayEntities();
        static RAdmin ad;
        static RUser ur;
        static void Main(string[] args)
        {
            var prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                                                     Welcome To Railways");
            Console.ForegroundColor = prevColor;

            Console.ForegroundColor = ConsoleColor.Magenta;

            char ch =' ';
            while (ch != 'E')
            {
                Console.WriteLine("Enter: U ===> User \r\n       A ===>Admin\r\n       E ===> Exit");
                ch = Convert.ToChar(Console.ReadLine());
                if (ch == 'a' || ch == 'A')
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Enter Admin Id");
                    int i = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Password");
                    string str = Console.ReadLine();
                    var admin = ral.RAdmins.FirstOrDefault(a => a.AdminId== i && a.Password == str);
                    if (admin!=null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("                                                     Welcome Admin");
                        Console.ForegroundColor = prevColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        char a = ' ';
                        while (a != 'E')
                        {
                            Console.WriteLine("Enter : 1 : Add Train\r\n        2 : Display Train\r\n        3 : Update Active Status\r\n        4 : Display  Cancelled Ticket\r\n        E : Exit\r\n");
                            a = Convert.ToChar(Console.ReadLine());

                            if (a == '1')
                                Admin.AddTrain();
                            else if (a == '2' )
                                Admin.Display();
                            else if (a == '3' )
                                Admin.Active_Status();
                            else if (a == '4' )
                                CancelTicket.Display();
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Exit Thanks You Visit Again");
                                break;
                            }
                        }
                    }
                    Console.WriteLine("Enter Correct Admin id and Password");
                }
                else if (ch == 'U' || ch == 'u')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("                                                     Welcome User");
                    Console.ForegroundColor = prevColor;
                    char a = ' ';
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Enter: 1: For Existing User \r\n       2: For New user");
                    int op = Convert.ToInt32(Console.ReadLine());
                    if (op == 1)
                    {
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Enter User Name");
                            string i = Console.ReadLine();
                            Console.WriteLine("Enter Password");
                            string str = Console.ReadLine();
                            var use = ral.RUsers.FirstOrDefault(m => m.Uname == i && m.UserPassword == str);
                            if (use != null)
                            {
                                while (a != 'E')
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Enter : 1 : Add Ticket\r\n        2 : Display Your Ticket\r\n        3 : Display Train\r\n        4 : Cancel Ticket\r\n        E for Exit");
                                    a = Convert.ToChar(Console.ReadLine());

                                    if (a == '3')
                                        Admin.ActiveDisplay();
                                    else if (a == '1')
                                        BookTicket.AddTicket(i);
                                    else if (a == '2')
                                    {
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.WriteLine("Enter the Booking id");
                                        String btk = Console.ReadLine();
                                        BookTicket.DisplayYourTicket(btk);
                                    }
                                    else if (a == '4')
                                        CancelTicket.Cancel_Ticket(i);
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.WriteLine("Exit Thanks You Visit Again");
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wrong User Name or Password");
                            }
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Invalid Useid or Password\r\n        Try Again");
                        }
                    }
                    else 
                    {
                        Console.WriteLine("As we can see you are not existing User So Kindly Add Youself");
                        Admin.AddUser();
                    }
                    
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Exit Thanks You Visit Again");
                    break;
                }
                Console.ReadKey();
            }
        }
    }
}
