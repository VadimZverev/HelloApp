using Microsoft.AspNetCore.Mvc;

namespace HelloApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Пример
        //public string Square(int altitude, int height)
        //{
        //    double square = altitude * height / 2;
        //    return $"Площадь треугольника с основанием {altitude} и высотой {height} равна {square}";
        //}

        // С использованием ContentResult
        public IActionResult Square(int altitude, int height)
        {
            double square = altitude * height / 2;
            return Content($"Площадь треугольника с основанием {altitude} и высотой {height} равна {square}");
        }
    }
}