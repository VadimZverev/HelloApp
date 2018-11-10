using HelloApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HelloApp.Controllers
{
    public class HomeController : Controller
    {
        List<Company> companies;
        List<Phone> phones;

        // Инициализация списков тестовыми данными
        public HomeController()
        {
            Company apple = new Company { Id = 1, Name = "Apple", Country = "США" };
            Company microsoft = new Company { Id = 2, Name = "Microsoft", Country = "США" };
            Company google = new Company { Id = 3, Name = "Google", Country = "США" };
            companies = new List<Company> { apple, microsoft, google };

            phones = new List<Phone>
            {
                new Phone{ Id = 1, Manufacturer = apple, Name = "iPhone 6S", Price = 56000 },
                new Phone{ Id = 2, Manufacturer = apple, Name = "iPhone 5S", Price = 41000 },
                new Phone{ Id = 3, Manufacturer = microsoft, Name = "Lumia 550", Price = 9000 },
                new Phone{ Id = 4, Manufacturer = microsoft, Name = "Lumia 950", Price = 40000 },
                new Phone{ Id = 5, Manufacturer = google, Name = "Nexus 5X", Price = 30000 },
                new Phone{ Id = 6, Manufacturer = google, Name = "Nexus 6P", Price = 50000 }
            };
        }

        // передача списка в представление
        public IActionResult Index()
        {
            return View(phones);
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
    }
}