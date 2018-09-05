using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace HelloApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // определяем обработчик маршрута
            var myRouteHandler = new RouteHandler(Handle);

            // создаём маршрут, используя обработчик
            var routeBuilder = new RouteBuilder(app, myRouteHandler);

            // само определение маршрута - он должен соответствовать запросу {controller}/{action}
            routeBuilder.MapRoute("default", "{controller}/{action}");

            // строим маршрут
            app.UseRouter(routeBuilder.Build());

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        // обработчик маршрута
        private async Task Handle(HttpContext context)
        {
            await context.Response.WriteAsync("Hello ASP.NET Core!");
        }
    }
}
