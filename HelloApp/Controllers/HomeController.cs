using HelloApp.Util; // Пространство имен класса HtmlResult
using Microsoft.AspNetCore.Mvc;

namespace HelloApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Пользовательский результат действия
        public HtmlResult GetHtml()
        {
            return new HtmlResult("<h2>Привет ASP.NET Core</h2>");
        }

        // Вывод пустого результата со статусом 200
        public IActionResult GetVoid()
        {
            return new EmptyResult();
        }

        // Вывод пустого результата со статусом 204
        public IActionResult GetNoContent()
        {
            return new NoContentResult();
        }
    }
}