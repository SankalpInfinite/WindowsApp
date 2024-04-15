using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway
{
    class Program
    {

        static void Main(string[] args)
        {
            var prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                                                     Welcome To Railways");
            Console.ForegroundColor = prevColor;

            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            char ch =' ';
            while (ch != 'E')
            {
                Console.WriteLine("Enter U for User or A for Admin E for Exit");
                ch = Convert.ToChar(Console.ReadLine());
                if (ch == 'a' || ch == 'A')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("                                                     Welcome Admin");
                    Console.ForegroundColor = prevColor;

                    char a = ' ';
                    while (ch != 'E')
                    {
                        Console.WriteLine("Enter : A for Add Train\r\n        D for Display Train\r\n        U for Update Active Status\r\n        E for Exit\r\n       C for Cancelled  Train");
                        a = Convert.ToChar(Console.ReadLine());

                        if (a == 'A' || a == 'a')
                            Admin.AddTrain();
                        else if (a == 'D' || a == 'd')
                            Admin.Display();
                        else if (a == 'U' || a == 'u')
                            Admin.Active_Status();
                        else if (a == 'C' || a == 'C')
                            CancelTicket.Display();
                        else
                        {
                            Console.WriteLine("Exit Thanks You Visit Again");
                            break;
                        }
                    }
                }
                else if (ch == 'U' || ch == 'u')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("                                                     Welcome User");
                    Console.ForegroundColor = prevColor;
                    char a = ' ';
                    while (ch != 'E')
                    {
                        Console.WriteLine("Enter : A for Add Ticket\r\n        D for Display Your Ticket\r\n          T for Display Train\r\n        C for Cancel Ticket\r\n        E for Exit");
                        a = Convert.ToChar(Console.ReadLine());

                        if (a == 'T' || a == 't')
                            Admin.ActiveDisplay();
                        else if (a == 'A' || a == 'a')
                            BookTicket.AddTicket();
                        else if (a == 'D' || a == 'd')
                        {
                            Console.WriteLine("Enter the Booking id");
                            String btk = Console.ReadLine();
                            BookTicket.DisplayYourTicket(btk);
                        }
                        else if (a == 'C' || a == 'c')
                            CancelTicket.Cancel_Ticket();
                        else
                        {
                            Console.WriteLine("Exit Thanks You Visit Again");
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Exit Thanks You Visit Again");
                    break;
                }
                Console.ReadKey();
            }
        }
    }
}
