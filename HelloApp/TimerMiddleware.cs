using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace HelloApp
{
    public class TimerMiddleware
    {
        private readonly RequestDelegate _next;

        public TimerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";

            if (context.Request.Path.Value.ToLower() == "/time")
            {
                TimeService timeService = context.RequestServices.GetService<TimeService>();
                await context.Response.WriteAsync($"Текущее время: {timeService?.Time}");
            }
            else
            {
                await context.Response.WriteAsync("парамметр не определён");
            }
        }
    }
}
