using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloApp.Controllers
{
    [Route("Store")]
    [Route("[controller]")]
    public class RoutesController : Controller
    {
        [Route("Main")]     // сопоставляется с Routes/Main, либо с Store/Main
        [Route("Index")]    // сопоставляется с Routes/Index, либо с Store/Index
        public IActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}