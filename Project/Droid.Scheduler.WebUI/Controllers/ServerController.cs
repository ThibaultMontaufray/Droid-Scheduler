using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Droid.Scheduler.WebUI.Controllers
{
    public class ServerController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Scheduler()
        {
            return View();
        }
    }
}