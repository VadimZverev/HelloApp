using HelloApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection; // библиотека для получения сервиса из запроса

namespace HelloApp.Controllers
{
    public class SimpleController : Controller
    {
        // Передача зависимости через параметры метода
        public string Index([FromServices] ITimeService timeService)
        {
            return timeService.Time;
        }

        // Получение доступа к сервису через запроса сервиса
        public string Answer()
        {
            ITimeService timeService = HttpContext.RequestServices.GetService<ITimeService>(); // получение доступа к сервису
            return timeService?.Time;
        }
    }
}