using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    public class AppController : Controller 
    {
        public IActionResult Index()
        {
            //throw new InvalidProgramException("bad things happen to good developers");
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";

            throw new InvalidOperationException("bad things happen to good developers");
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About";
            return View();
        }
    }
}
