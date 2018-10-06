using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;

namespace HelloApp
{
    public class AdminRoute : IRouter
    {
        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            throw new NotImplementedException();
        }

        public Task RouteAsync(RouteContext context)
        {
            string url = context.HttpContext.Request.Path.Value.TrimEnd('/');

            if (url.StartsWith("/Admin", StringComparison.OrdinalIgnoreCase))
            {
                // Обрабатывается только тем делегатом, который установлен для свойства 
                // Handler
                context.Handler = async ctx =>
                {
                    ctx.Response.ContentType = "text/html;charset=utf-8";
                    await ctx.Response.WriteAsync("Привет Admin!");
                };

                // другой вариант, который отличается от выше описанного, тем
                // что будет дальше идти по списку маршрутов.
                // await context.HttpContext.Response.WriteAsync("Привет Admin!");
            }

            return Task.CompletedTask;
        }
    }
}
