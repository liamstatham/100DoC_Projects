using Jims_Cars.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Jims_Cars.Web.Controllers
{
    public class HomeController : Controller
    {
        ICarData db;
        public HomeController(ICarData db)
        {
            this.db = db;
        }
        public ActionResult Index()
        {
            var model = db.GetCars();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}