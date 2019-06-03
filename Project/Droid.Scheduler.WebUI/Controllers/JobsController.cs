using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using Droid.Scheduler.WebUI.Authentication;
using Droid.Scheduler.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Droid.Scheduler.WebUI.Controllers
{
    public class JobsController : ControllerBase
    {
        public string JobName;

        private SignInManager<ApplicationUser> _account;

        public JobsController(SignInManager<ApplicationUser> ac)
        {
            _account = ac;
        }

        public IActionResult Detail()
        {
            if (_account == null || !_account.IsSignedIn(User)) { return RedirectToAction("Login", "Account"); }
            try
            {
                var qs = Request.QueryString.ToString();
                var parsed = HttpUtility.ParseQueryString(qs);
                JobName = parsed["name"];
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                JobName = "Error : " + exp.Message;
            }

            var jo = db.Job;
            var jo2 = db.Job.Count();

            ViewBag.JobName = JobName;
            return View();
        }
        public IActionResult Create()
        {
            if (_account == null || !_account.IsSignedIn(User)) { return RedirectToAction("Login", "Account"); }
            JobName = string.Empty;
            return View();
        }
    }
}