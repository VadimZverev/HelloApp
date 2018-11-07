using Microsoft.AspNetCore.Mvc;

namespace HelloApp.Areas.Store.Controllers
{
    [Area("Store")] //Необходимо для того, чтобы контроллер принадлежал к нужной области
    public class HomeController : Controller
    {   
        // Альтернативный способ установки маршрута для контроллера
        // для работы с областью.
        [Route("[area]/[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}