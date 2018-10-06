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
            // Установка сопоставления "position" с PositionConstraint
            services.Configure<RouteOptions>(options =>
                    options.ConstraintMap.Add("position", typeof(PositionConstraint)));

            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            var myRouteHandler = new RouteHandler(Handle);
            var routeBuilder = new RouteBuilder(app, myRouteHandler);

            // использование inline-ограничений
            routeBuilder.MapRoute(
                "default",
                "{controller}/{action}/{id:position?}");

            app.UseRouter(routeBuilder.Build());

            // Установка пользовательского ограничения
            routeBuilder.MapRoute("default",
                "{controller}/{action}/{id?}",
                null,
                new { myConstraint = new CustomConstraint("/Home/Index/12") });

            // Установка пользовательского ограничения для id
            routeBuilder.MapRoute("default",
                "{controller}/{action}/{id?}",
                new { controller = "Home", action = "Index" },
                new { id = new PositionConstraint() });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        private async Task Handle(HttpContext context)
        {
            var routeValues = context.GetRouteData().Values;
            var action = routeValues["action"].ToString();
            var controller = routeValues["controller"].ToString();
            string id = routeValues["id"]?.ToString();

            await context.Response.WriteAsync($"controller: {controller} | " +
                                                $"action: {action} | id: {id}");
        }
    }
}
