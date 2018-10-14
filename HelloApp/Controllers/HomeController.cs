using Microsoft.AspNetCore.Mvc;

namespace HelloApp.Controllers
{
    public class HomeController : Controller
    {
        // Временная переадресация на внешний ресурс
        public IActionResult Index()
        {
            return Redirect("http://microsoft.com");
            // Постоянная переадресация
            // return RedirectPermanent("~/Home/About");
        }
    }
}