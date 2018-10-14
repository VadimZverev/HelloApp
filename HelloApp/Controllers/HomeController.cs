using Microsoft.AspNetCore.Mvc;

namespace HelloApp.Controllers
{
    public class HomeController : Controller
    {
        // Передача значения через параметр
        public string Hello(int id)
        {
            return $"id = {id}";
        }
    }
}