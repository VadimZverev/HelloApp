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

        // Также можно строить маршрут из параметров и ограничений для них.
        [Route("{id:int}/{name:maxlength(10)}")]
        public IActionResult Test(int id, string name)
        {
            return Content($" id = {id} | name = {name}");
        }
    }
}