using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway
{
    public class CancelTicket
    {

        static RailwayEntities ral = new RailwayEntities();
        static Cancel ct;
        public static void Main()
        {

        }
        public static void Cancel_Ticket()
        {
            ct = new Cancel();
            ct.Cid = Cancelid();
            Console.WriteLine("Enter the Booking id");
            string BookingID = Console.ReadLine();
            Book d = ral.Books.Find(BookingID);
            if (IsBookid(BookingID)==true)
                ct.Bid = d.Bid;
            else
                Console.WriteLine("Enter Correct Booking Id");
            Console.WriteLine("Enter the Cancel Date");
            ct.Candate = Convert.ToDateTime(Console.ReadLine());
            
            ct.Tno = d.Tno;
            ct.@class = d.@class;
            ct.NoofCTic = d.NoofTic;
            AddCancelTicket((int)d.NoofTic, (int)d.Tno, d.@class);
            ct.refund = AmounttobeRedunded(BookingID);
            ct.rem = "Processing";
             
            ral.Cancels.Add(ct);
            ral.SaveChanges();
        }
        public static void Display()
        {
            var Details = ral.Cancels.ToList();
            foreach (var d in Details)
            {
                Console.WriteLine($"Cancel Id: {d.Cid}\r\nBook Id: {d.Bid}\r\nTrain no: {d.Tno}\r\nTrain Class: {d.@class}\r\nCancel Date: {d.Candate}\r\nNo of Tickets: {d.NoofCTic}\r\nRefund Amount: {d.refund}\r\nStatus: {d.rem}");
                Console.WriteLine("----------------------------");
            }
        }
        public static string Cancelid()
        {
            var d = ral.Cancels.ToList();
            string lastCancelId = d.Last().Cid;
            string str = lastCancelId.Substring(1);
            int i = Convert.ToInt32(str) + 1;
            string id = "C" + i;
            return id;
        }
        public static Boolean IsBookid(string id)
        {
            Book d = ral.Books.Find(id);
            if (d != null)
            {
                return true;
            }
            else
                return false;
        }
        public static int AmounttobeRedunded(string id)
        {
            Book d = ral.Books.Find(id);
            if (d != null)
            {
                int amt=0,val=0;
                if (d.@class == "s" || d.@class == "S")
                {
                    val = (int)d.TotalAmt;
                    amt = val - (int)(val * .4);
                }
                else if (d.@class == "3")
                {
                    val = (int)d.TotalAmt;
                    amt = val - (int)(val * .3);
                }
                else if (d.@class == "2")
                {
                    val = (int)d.TotalAmt;
                    amt = val - (int)(val * .2);
                }
                else if (d.@class == "1")
                {
                    val = (int)d.TotalAmt;
                    amt = val - (int)(val * .2);
                }
                else
                    amt = 0;
                return amt;
            }
            else
                return 0;
        }
        public static void AddCancelTicket(int seats,int tarino,string cla)
        {
            TrainDetail d = ral.TrainDetails.Find(tarino, cla);
            if (d != null)
            {
                if (d.AvailableBerth <= d.TotalBerth)
                {
                    d.AvailableBerth = d.AvailableBerth + seats;
                    ral.SaveChanges();
                    Console.WriteLine("Seats Successfull Cancelled");
                }
            }
            else
                Console.WriteLine("Match not found");
        }
    }
}
