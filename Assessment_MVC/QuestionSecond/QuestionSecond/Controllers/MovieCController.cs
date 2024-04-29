using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuestionSecond.Models;


namespace QuestionSecond.Controllers
{
    public class MovieCController : Controller
    {
        // GET: MovieC
        List<Movie> m = new List<Movie>();

        public ActionResult Index()
        {
            
            return View(m);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie a)
        {
            if (ModelState.IsValid)
            {
                m.Add(a);
                return RedirectToAction("Index");
            }
            return View(a);
        }

        public ActionResult Delete(int Id)
        {
            m.RemoveAt(Id);
            return View(m);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int Id)
        {
            m.RemoveAt(Id);
            return RedirectToAction("Index");
        }
    }
}