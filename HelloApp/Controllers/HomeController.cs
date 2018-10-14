using Microsoft.AspNetCore.Mvc;

namespace HelloApp.Controllers
{
    public class HomeController : Controller
    {
        // Временная переадресация на внешний ресурс
        public IActionResult Index()
        {
            return Redirect("http://microsoft.com");
            // Постоянная переадресация
            // return RedirectPermanent("~/Home/About");
        }

        // Обращение к локальным адресам в системе, на которой развернут проект
        public IActionResult LocalRedirect()
        {
            return LocalRedirect("~/Home/About");
            // Постоянная переадресация
            // return LocalRedirectPermanent("~/Home/About");

            // Будет искл, если будет попытка перейти на внешний ресурс
            // return LocalRedirect("http://microsoft.com");

        }

        // Переадресация на метод действия
        public IActionResult RedirToAction()
        {
            return RedirectToAction("Square", "Home", new { altitude = 10, height = 3 });
        }

        // Переадресация на метод действия по маршруту
        public IActionResult RedirToRoute()
        {
            return RedirectToRoute("default",
                new
                {
                    controller = "Home",
                    action = "Square",
                    height = 2,
                    altitude = 20
                });
        }

        public IActionResult Square(int altitude, int height)
        {
            double square = altitude * height / 2;
            return Content($"Площадь треугольника с основанием {altitude} и высотой {height} равна {square}");
        }
    }
}