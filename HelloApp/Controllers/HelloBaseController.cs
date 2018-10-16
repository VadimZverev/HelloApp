using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Text.RegularExpressions;

namespace HelloApp.Controllers
{
    public abstract class HelloBaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // проверка содержания в User-Agent в заголовке наличия IE 8.0
            if (context.HttpContext.Request.Headers.ContainsKey("User-Agent") &&
                Regex.IsMatch(context.HttpContext.Request.Headers["User-Agent"].FirstOrDefault(), "MSIE 8.0"))
            {
                context.Result = Content("Internet Explorer 8.0 не поддерживается");
            }
            base.OnActionExecuting(context);
        }
    }
}