using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloApp.Controllers
{
    [Route("[Controller]")]
    public class RouteController : Controller
    {
        [Route("")]         // сопоставляется с Route
        [Route("Action")]   // сопоставляется с Route/Action
        public IActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}