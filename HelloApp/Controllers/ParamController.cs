using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloApp.Controllers
{
    public class ParamController : Controller
    {
        // При использовании action и controller исп. "[ ]"
        // Также есть возможно использования их по отдельности:
        // [Route("[controller]")]
        // [Route("[action]")]
        // [Route("[controller]/[action]/{id?}")]
        [Route("[action]/[controller]/{id?}")]
        public IActionResult Index(string id)
        {
            string controller = RouteData.Values["controller"].ToString();
            string action = RouteData.Values["action"].ToString();

            return Content($"controller: {controller} | action: {action}");
        }
    }
}