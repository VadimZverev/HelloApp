using Microsoft.AspNetCore.Mvc;

namespace HelloApp.Controllers
{
    public class HomeController : Controller
    {
        // Передача значения через параметр
        public string Hello(int id)
        {
            return $"id = {id}";
        }

        // Передача значений через параметры
        public string Square(int a, int h)
        {
            double s = a * h / 2;
            return $"Площадь треугольника с основанием {a} и высотой {h} равна {s}";
        }

        // Установка значений по умолчанию
        public string SquareDefault(int a, int h)
        {
            double s = a * h / 2;
            return $"Площадь треугольника с основанием {a} и высотой {h} равна {s}";
        }
    }
}