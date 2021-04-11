using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    public class AppController : Controller 
    {
        private readonly IMailService _mailService;

        public AppController(IMailService mailService)
        {
            _mailService = mailService;
        }
        public IActionResult Index()
        {
            //throw new InvalidProgramException("bad things happen to good developers");
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();

        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if(ModelState.IsValid)
            {
                // send email
                _mailService.SendMessage("liamstatham@gmail.com", model.Subject, $"From: {model.Name} - {model.Email}, Meessage: {model.Message}");
                ViewBag.UserMessage = "Mail sent.";
                ModelState.Clear();
            }
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
