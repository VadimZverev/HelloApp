using HelloApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITimeService _timeService;

        // передача зависимости через конструктор.
        public HomeController(ITimeService timeServ)
        {
            _timeService = timeServ;
        }

        public string Index()
        {
            return _timeService.Time;
        }
    }
}