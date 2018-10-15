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

        // отправка кода 401, если возраст не подходит
        public IActionResult Age(int age)
        {
            if (age < 18)
                return Unauthorized();
            return Content("Проверка пройдена");
        }

        // отправка кода 400
        public IActionResult BadReq(string s)
        {
            if (string.IsNullOrEmpty(s))
                return BadRequest("Не указаны параметры запроса");
            return View();
        }

        // отправка кода 200
        public IActionResult OK()
        {
            return Ok("запрос успешно выполнен");
        }
    }
}