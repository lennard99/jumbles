using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myApp1.Models;

namespace myApp1.Controllers
{
    public class WelcomeController : Controller
    {
        // GET: /Welcome/
        public IActionResult Index()
        {
            ViewData["Title"] = "List of SMS Jumbles.";
            ViewData["Message"] = "Historical records as processed by Twilio app.";

            ViewData["nRecords"] = 6;
            ViewData["TempRecord"] = "Temporary record";

            return View();
        }

        // GET: /Welcome/Welcome
        public IActionResult Welcome(string name = null)
        {
            ViewData["Title"] = "Welcome.";
            ViewData["Message"] = "Hello.";
            
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
