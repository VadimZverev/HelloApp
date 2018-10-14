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

        // Обращение к локальным адресам в системе, на которой развернут проект
        public IActionResult LocalRedirect()
        {
            return LocalRedirect("~/Home/About");
            // Постоянная переадресация
            // return LocalRedirectPermanent("~/Home/About");

            // Будет искл, если будет попытка перейти на внешний ресурс
            // return LocalRedirect("http://microsoft.com");

        }
    }
}