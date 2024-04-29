using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuestionFirst.Models;


namespace QuestionFirst.Controllers
{
    public class CodeController : Controller
    {
        private nwEntities nwe = new nwEntities();
        // GET: Code
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GermanyCust()
        {
            var gcus = nwe.Customers.Where(a => a.Country == "Germany");
            return View(gcus.ToList());
        }
        public ActionResult ByOrderid(int id)
        {
            Order o = new Order();
            o = nwe.Orders.Find(id);
            return View(o);
        }
    }
}