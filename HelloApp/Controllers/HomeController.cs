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

        public HtmlResult GetHtml()
        {
            return new HtmlResult("<h2>Привет ASP.NET Core</h2>");
        }
    }
}