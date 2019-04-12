using Microsoft.AspNetCore.Mvc;
using Droid.Scheduler.WebUI.Context;
using Droid.Scheduler.WebUI.Authentication;

namespace Droid.Scheduler.WebUI.Controllers
{
    public class ControllerBase : Controller
    {
        protected SchedulerContext db = new SchedulerContext();
    }
}
