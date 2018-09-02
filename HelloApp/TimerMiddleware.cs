using Microsoft.AspNetCore.Http;
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

        public async Task InvokeAsync(HttpContext context, TimeService timeService)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync($"текущее время: {timeService.GetTime()}");
        }
    }
}
