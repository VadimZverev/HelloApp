using HelloApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloApp.Controllers
{
    public class SimpleController : Controller
    {
        public string Index([FromServices] ITimeService timeService)
        {
            return timeService.Time;
        }
    }
}