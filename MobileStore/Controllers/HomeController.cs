using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileStore.Models;

namespace MobileStore.Controllers
{
    public class HomeController : Controller
    {
        MobileContext context;

        public HomeController(MobileContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.Phones.ToList());
        }
    }
}
