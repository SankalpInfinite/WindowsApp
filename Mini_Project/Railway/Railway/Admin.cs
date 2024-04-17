using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway
{
    public class Admin
    {
        static RailwayEntities ral = new RailwayEntities();
        static TrainDetail td;
        static RUser us;
        public static void Main()
        {
            AddTrain();
            Display();
            Console.ReadKey();
        }
        public static void AddTrain()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            td = new TrainDetail();
            Console.WriteLine("Enter Train No.");
            td.Tno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Train Name");
            td.Tname = Console.ReadLine();
            Console.WriteLine("Enter Train class S for sleeper, 1 for 1st AC 2 for 2nd AC, 3 for 3rd AC");
            td.@class = Console.ReadLine();
            Console.WriteLine("Enter the Total seats");
            td.TotalBerth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Total Berths");
            td.AvailableBerth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Train Status Y for Yes N for No.");
            td.TStatus = Console.ReadLine();

            ral.TrainDetails.Add(td);
            ral.SaveChanges();
        }
        public static void Display()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            var Details = ral.TrainDetails.ToList();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("| Train Number\t| Train Name\t\t\t| Train Class\t| Total Berth   | Available Berths | Active Status|");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            foreach (var d in Details)
            {
                
                    Console.WriteLine($"|{d.Tno}\t\t| {d.Tname}\t\t| {d.@class}\t\t| {d.TotalBerth}\t\t| {d.AvailableBerth}\t\t |{d.TStatus}\t\t |");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            }
        }
        public static void ActiveDisplay()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            var Details = ral.TrainDetails.ToList();
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("| Train Number\t| Train Name\t\t\t| Train Class\t| Total Berth | Available Berths |");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            foreach (var d in Details)
            {
                if (d.TStatus == "Y" || d.TStatus == "y")
                Console.WriteLine($"|{d.Tno}\t\t| {d.Tname}\t\t| {d.@class}\t\t| {d.TotalBerth}\t\t| {d.AvailableBerth}\t\t|");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
            }
        }
        public static void Active_Status()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("enter Train No :");
            int Trainno = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Class:");
            string _Class = Console.ReadLine();

            TrainDetail d = ral.TrainDetails.Find(Trainno, _Class);
            if (d != null)
            {
                Console.WriteLine("Enter Train Status Y for Yes N for No.");
                d.TStatus = Console.ReadLine();
                ral.SaveChanges();
                Console.WriteLine("Change Successfull done");
            }
            else
                Console.WriteLine("Match not found");
        }
        public static Boolean UpdateBerth(int seats, int Trainno, string _Class)
        {
            //Console.WriteLine("enter Train No :");
            //int Trainno = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter Class:");
            //string _Class = Console.ReadLine();

            TrainDetail d = ral.TrainDetails.Find(Trainno, _Class);
            if (d != null)
            {
                if (d.AvailableBerth > 0)
                {
                    d.AvailableBerth = d.AvailableBerth - seats;
                    ral.SaveChanges();
                    Console.WriteLine("Seats Successfull Reaserve");
                    return true;
                }
                Console.WriteLine("No seats Available");
                return false;
            }
            else
                Console.WriteLine("Match not found");
            return false;
        }
        public static void AddUser()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            us = new RUser();
            Console.WriteLine("Enter The User Name:");
            us.Uname = Console.ReadLine();
            Console.WriteLine("Enter The Password");
            us.UserPassword = Console.ReadLine();
            ral.RUsers.Add(us);
            ral.SaveChanges();
        }
    }
}
