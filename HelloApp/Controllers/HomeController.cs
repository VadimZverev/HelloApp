using Microsoft.AspNetCore.Mvc;

namespace HelloApp.Controllers
{
    public class HomeController : Controller
    {
        // С помощью атрибута "Route" указываятся шаблон маршрута,
        // с помощью которого будет обращение к методу действия.
        [Route("homepage")]
        public IActionResult Index()
        {
            return View();
        }
    }
}