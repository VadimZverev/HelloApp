using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HelloApp.Models;

namespace HelloApp.Controllers
{
    public class HomeController : Controller
    {
        static List<Event> events;
        public HomeController()
        {
            if (events == null)
            {
                events = new List<Event>();
            }
        }

        public IActionResult Index()
        {
            return View(events);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event ev)
        {
            ev.Id = Guid.NewGuid().ToString();
            events.Add(ev);
            return RedirectToAction("Index");
        }
    }
}