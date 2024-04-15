using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway
{
    public class BookTicket
    {
        static RailwayEntities ral = new RailwayEntities();
        static Book bk;
        public static void Main()
        {
            AddTicket();
            Display();
        }
        public static void DisplayYourTicket(string btk)
        {
            var Details = ral.Books.ToList();
            foreach (var d in Details)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                if (d.Bid==btk)
                Console.WriteLine($"Book Id: {d.Bid}\r\nTrain no: {d.Tno}\r\nTrain Class: {d.@class}\r\nBooking Date: {d.Bdate}\r\nTravelling Date: {d.Travdate}\r\nNo of Tickets: {d.NoofTic}\r\nTotal Amount: {d.TotalAmt}");
                Console.WriteLine("----------------------------");
            }
        }
        public static void Display()
        {
            var Details = ral.Books.ToList();
            foreach (var d in Details)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"Book Id: {d.Bid}\r\nTrain no: {d.Tno}\r\nTrain Class: {d.@class}\r\nBooking Date: {d.Bdate}\r\nTravelling Date: {d.Travdate}\r\nNo of Tickets: {d.NoofTic}\r\nTotal Amount: {d.TotalAmt}");
                Console.WriteLine("----------------------------");
            }
        }
        public static void AddTicket()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            bk = new Book();
            bk.Bid = Bookid();
            Console.WriteLine("Enter Train No");
            bk.Tno= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Train class S for sleeper, 1 for 1st AC 2 for 2nd AC, 3 for 3rd AC");
            bk.@class = Console.ReadLine();
            Console.WriteLine("Enter the Booking Date");
            bk.Bdate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter the Travelling Date");
            bk.Travdate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter Total No of Tickets");
            int NoTic = Convert.ToInt32(Console.ReadLine());
            Boolean check= Admin.UpdateBerth(NoTic);
            if (check == true)
                bk.NoofTic = NoTic;
            bk.TotalAmt = TotalAmount(NoTic,bk.@class);
            ral.Books.Add(bk);
            ral.SaveChanges();
        }
        public static string Bookid()
        {
            var d = ral.Books.ToList();

            string lastBookingId = d.Last().Bid;
            string str = lastBookingId.Substring(1);
            int i =Convert.ToInt32(str)+1;
            string id = "B" + i;
            return id;
        }
        public static int TotalAmount(int NoTic,string clas)
        {
            if (clas == "S" || clas == "s")
                return NoTic * 1000;
            else if (clas == "1")
                return NoTic * 3000;
            else if (clas == "2")
                return NoTic * 2500;
            else if (clas == "3")
                return NoTic * 2000;
            else
                return 0;
        }
    }
}
