using Microsoft.AspNetCore.Mvc;

namespace HelloApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // отправка необходимого кода статуса
        public IActionResult StatCode()
        {
            return StatusCode(401);
        }

        // отправка NotFoundResult(NotFoundObjectResult)
        public IActionResult NoFound()
        {
            return NotFound("ресурс в приложении не найден");
        }
    }
}