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
    }
}
