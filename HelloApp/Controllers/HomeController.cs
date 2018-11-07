using Microsoft.AspNetCore.Mvc;

namespace HelloApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("api/[controller]/[action]")]
        public IActionResult Test()
        {
            return View("Index");
        }
    }
}