using Jims_Cars.Data.Models;
using Jims_Cars.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jims_Cars.Web.Controllers
{
    public class CarsController : Controller
    {
        ICarData db;

        public CarsController(ICarData db)
        {
            this.db = db;
        }
        // GET: Cars
        public ActionResult Index()
        {
            var model = db.GetCars();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cars car)
        {
            if(ModelState.IsValid)
            {
                db.Add(car);
                return RedirectToAction("Details", new { id = car.Id });

            }
            var model = db.GetCars();
            return View(model);
        }
    }
}