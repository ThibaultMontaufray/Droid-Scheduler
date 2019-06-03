using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Droid.Scheduler.WebUI.Controllers
{
    public class SettingsController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}