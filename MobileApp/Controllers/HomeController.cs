using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileApp.Models;

namespace MobileApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            // передача данных в представление через ViewData["ключ"] = "Значение"
            ViewData["Message"] = "Hello ASP.NET Core via ViewData";

            // передача данных в представление через ViewBag.<Имя> = "Значение"
            ViewBag.Message_2 = "Hello ASP.NET Core via ViewBag";

            ViewBag.Countries = new List<string> { "Бразилия", "Аргентина", "Уругвай", "Чили" };

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
