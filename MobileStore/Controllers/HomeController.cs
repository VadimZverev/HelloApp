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

        [HttpGet]
        public IActionResult Buy(int id)
        {
            ViewBag.PhoneId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Order order)
        {
            context.Add(order);
            // сохраняем в бд все изменени
            context.SaveChanges();

            return "Спасибо, " + order.User + ", за покупку!";
        }
    }
}
