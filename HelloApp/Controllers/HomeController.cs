using HelloApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddUser(User user)
        {
            string userInfo = $"Id:{user.Id} Name: {user.Name} Age: {user.Age} " +
                $"HasRight: {user.HasRight}";
            return Content(userInfo);
        }
    }
}