using Microsoft.AspNetCore.Mvc;

namespace HelloApp.Areas.Store.Controllers
{
    [Area("Store")] //Необходимо для того, чтобы контроллер принадлежал к нужной области
    public class HomeController : Controller
    {   
        public IActionResult Index()
        {
            return View();
        }
    }
}