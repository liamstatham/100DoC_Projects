using OdeToFood.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class GreetingController : Controller
    {
        // GET: Greeting
        public ActionResult Index(string name)
        {
            //controller responds to GET greeting request
            //controller builds model 
            var model = new GreetingViewModel();
            model.Name = name ?? "no name";
            //controller puts data into the model by using the configuration for the application
            //could use a database or other data source for this
            model.Message = ConfigurationManager.AppSettings["message"];
            //controller then renders a view
            return View(model);
        }
    }
}