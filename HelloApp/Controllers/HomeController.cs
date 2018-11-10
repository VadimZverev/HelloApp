﻿using HelloApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                string userInfo = $"Id:{user.Id} Name: {user.Name} Age: {user.Age} " +
                $"HasRight: {user.HasRight}";
                return Content(userInfo);
            }

            return Content($"Кол-во ошибок: {ModelState.ErrorCount}");
        }

        // Атрибут Bind указывает, какие параметры будут учавствовать в привязке
        public IActionResult AddUserBind([Bind("Name")] User user)
        {
            string userInfo = $"Name: {user.Name} Age: {user.Age} HasRight: {user.HasRight}";
            return Content(userInfo);
        }

        // использование атрибута [FromHeader] для извлечения данных
        // применяется, если есть в методе 1 парметр, иначе вызывается исключение
        public IActionResult GetUserAgent([FromHeader(Name = "User-Agent")] string userAgent)
        {
            return Content(userAgent);
        }

        public IActionResult AddUserQuery()
        {
            return View();
        }

        // Привязчик FromQuery игнорирует форму и сразу читает из строки запроса
        [HttpPost]
        public IActionResult AddUserQuery([FromQuery] User user)
        {
            string userInfo = $"Name: {user.Name} Age: {user.Age}";
            return Content(userInfo);
        }
    }
}