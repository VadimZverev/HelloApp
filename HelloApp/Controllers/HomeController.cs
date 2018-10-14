using HelloApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HelloApp.Controllers
{
    public class HomeController : Controller
    {
        // Передача значения через параметр
        // Строка запроса: https://localhost:44340/Home/Hello?id=9
        public string Hello(int id)
        {
            return $"id = {id}";
        }

        // Передача значений через параметры
        // Строка запроса: https://localhost:44340/Home/Square?a=9&h=10
        public string Square(int a, int h)
        {
            double s = a * h / 2;
            return $"Площадь треугольника с основанием {a} и высотой {h} равна {s}";
        }

        // Установка значений по умолчанию
        // Строка запроса: https://localhost:44340/Home/SquareDefault
        public string SquareDefault(int a = 9, int h = 10)
        {
            double s = a * h / 2;
            return $"Площадь треугольника с основанием {a} и высотой {h} равна {s}";
        }

        // Передача сложных объектов
        // Строка запроса: https://localhost:44340/Home/SquareObject?altitude=9&height=10
        public string SquareObject(Geometry geometry)
        {
            return $"Площадь треугольника с основанием {geometry.Altitude} и высотой {geometry.Height} равна {geometry.GetSquare()}";
        }

        // Передача массивов
        // Строка запроса: https://localhost:44340/Home/Sum?nums=1&nums=2&nums=3
        public string Sum(int[] nums)
        {
            return $"Сумма чисел равна {nums.Sum()}";
        }

        // Передача массивов объектов
        // Строка запроса: https://localhost:44340/Home/Sum?geoms[0].altitude=10&geoms[0].height=3&geoms[1].altitude=16&geoms[1].height=2
        public string SumObject(Geometry[] geoms)
        {
            return $"Сумма чисел равна {geoms.Sum(g => g.GetSquare())}";
        }
    }
}