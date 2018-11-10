using HelloApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HelloApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Передача сложного объекта в метод контроллера
        // в строке запроса можно передавать двумя вариантами, при этом они будут аналогичными:
        // 1. http://localhost/Home/GetPhone?myPhone.Price=24000&myPhone.Name=Nexus5X&myPhone.Manufacturer.Name=LG
        // 2. http://localhost/Home/GetPhone?Price=24000&Name=Nexus5X&Manufacturer.Name=LG
        public IActionResult GetPhone(Phone myPhone)
        {
            return Content($"Name: {myPhone?.Name} Price:{myPhone.Price} " +
                $"Company: { myPhone?.Manufacturer?.Name}");
        }

        // Передача массивов и списков сложных объектов
        // в строке запроса можно передавать двумя вариантами, при этом они будут аналогичными:
        // 1. http://localhost/Home/GetPhones?phones[0].Name=Lumia950&phones[0].Price=30000&phones[0].Manufacturer.Name=Microsoft&phones[1].Name=iPhone6S&phones[1].Price=50000&phones[1].Manufacturer.Name=Apple
        // 2. http://localhost/Home/GetPhones?[0].Name=Lumia950&[0].Price=30000&[0].Manufacturer.Name=Microsoft&[1].Name=iPhone6S&[1].Price=50000&[1].Manufacturer.Name=Apple
        public IActionResult GetPhones(Phone[] phones)
        {
            string result = "";
            foreach (var p in phones)
            {
                result += $"{p.Name} - {p.Price} - {p.Manufacturer.Name}\n";
            }
            return Content(result);
        }
    }
}