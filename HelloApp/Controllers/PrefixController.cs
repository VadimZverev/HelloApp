using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloApp.Controllers
{
    // Добавляет глобальный префикс для всего контроллера,
    // вместо того, чтобы писать в каждом методе действия.
    [Route("main")]
    public class PrefixController : Controller
    {
        //[Route("main/store/{name}")]
        [Route("store/{name}")]
        public IActionResult Index(string name)
        {
            return Content(name);
        }

        //[Route("main/{id:int}/{name:maxlength(10)}")]
        [Route("{id:int}/{name:maxlength(10)}")]
        public IActionResult Test(int id, string name)
        {
            return Content($" id = {id} | name = {name}");
        }
    }
}