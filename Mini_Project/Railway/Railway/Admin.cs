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
        public static void Main()
        {
            AddTrain();
            Display();
            Console.ReadKey();
        }
        public static void AddTrain()
        {
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
            var Details = ral.TrainDetails.ToList();
            foreach (var d in Details)
            {
                Console.WriteLine($"Train no: {d.Tno}\r\nTrain Name: {d.Tname}\r\nTrain Class: {d.@class}\r\nTotal Berth: {d.TotalBerth}\r\nAvailable Berths: {d.AvailableBerth}\r\nStatus of Active: {d.TStatus}");
                Console.WriteLine("----------------------------");
            }
        }
        public static void ActiveDisplay()
        {
            var Details = ral.TrainDetails.ToList();
            foreach (var d in Details)
            {
                if(d.TStatus=="Y"||d.TStatus=="y")
                Console.WriteLine($"Train no: {d.Tno}\r\nTrain Name: {d.Tname}\r\nTrain Class: {d.@class}\r\nTotal Berth: {d.TotalBerth}\r\nAvailable Berths: {d.AvailableBerth}\r\nStatus of Active: {d.TStatus}");
                Console.WriteLine("----------------------------");
            }
        }
        public static void Active_Status()
        {
            Console.WriteLine("enter Train No :");
            int Trainno = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Class:");
            string _Class = Console.ReadLine();

            TrainDetail d = ral.TrainDetails.Find(Trainno,_Class);
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
        public static Boolean UpdateBerth(int seats)
        {
            Console.WriteLine("enter Train No :");
            int Trainno = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Class:");
            string _Class = Console.ReadLine();

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
    }
}

