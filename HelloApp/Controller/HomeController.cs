using Microsoft.AspNetCore.Mvc;

namespace HelloApp.Controller
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}