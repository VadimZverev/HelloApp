using Microsoft.AspNetCore.Mvc;

namespace HelloApp.Controllers
{
    public class HomeController : HelloBaseController
    {
        public IActionResult Index()
        {
            return Content("Запрос успешно выполнен");
        }
    }
}