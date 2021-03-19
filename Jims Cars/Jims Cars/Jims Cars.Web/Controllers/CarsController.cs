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
        private readonly ICarData db;

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
    }
}