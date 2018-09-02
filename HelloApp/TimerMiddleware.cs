using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (context.Request.Path.Value.ToLower() == "/time")
            {
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync($"Текущее время: {timeService?.Time}");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
