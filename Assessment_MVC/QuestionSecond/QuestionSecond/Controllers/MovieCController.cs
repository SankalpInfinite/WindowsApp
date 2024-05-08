using System.Web.Mvc;
using QuestionSecond.Models;



namespace QuestionSecond.Controllers
{
    public class MovieCController : Controller
    {
        // GET: MovieC
        IMovieRepo<Movie> mv = new IMovieRepo<Movie>();

      

        // GET: Products
        public ActionResult Index()
        {
            var product = _prdrepo.GetAll();
            return View(product);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Products p)
        {
            if (ModelState.IsValid)
            {
                _prdrepo.Insert(p);
                _prdrepo.Save();
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public ActionResult Edit(int Id)
        {
            var product = _prdrepo.GetById(Id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Products p)
        {
            if (ModelState.IsValid)
            {
                _prdrepo.Update(p);
                _prdrepo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(p);
            }
        }

        public ActionResult Details(int id)
        {
            var product = _prdrepo.GetById(id);
            return View(product);
        }

        public ActionResult Delete(int Id)
        {
            var product = _prdrepo.GetById(Id);
            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int Id)
        {
            var product = _prdrepo.GetById(Id);
            _prdrepo.Delete(Id);
            _prdrepo.Save();
            return RedirectToAction("Index");
        }
    }
}