using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
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

            var routeBuilder = new RouteBuilder(app);

            // Ограничение контроллера, который начинается на символ "H"
            routeBuilder.MapRoute("default",
                    "{controller}/{action}/{id?}",
                    new { action = "Index" }, // параметры по умолчанию
                    new { controller = "^H" } // ограничение
                    );

            // Ограничение id не менее 2 цифр
            routeBuilder.MapRoute("default",
                    "{controller}/{action}/{id?}",
                    new { action = "Index" }, // параметры по умолчанию
                    new { controller = "^H", id = @"\d{2}" } // ограничение
                    );

            // Аналогичное применение класса RegexRouteConstraint
            routeBuilder.MapRoute("default",
                    "{controller}/{action}/{id?}",
                    null, // параметры по умолчанию
                    new
                    {
                        controller = new RegexRouteConstraint("^H"),
                        id = new RegexRouteConstraint(@"\d{2}")
                    }); // ограничение


            // ограничение на тип запроса
            routeBuilder.MapRoute("default",
                "{controller}/{action}/{id?}",
                null,
                new { httpMethod = new HttpMethodRouteConstraint("POST") }
                );

            // ограничение на длину строки
            routeBuilder.MapRoute("default",
                "{controller}/{action}/{id?}",
                null,
                new
                {
                    controller = new LengthRouteConstraint(4), // точная длина
                    action = new LengthRouteConstraint(3, 10)  // мин и макс длина
                });

            // Аналогичное ограничение на длину строки
            routeBuilder.MapRoute("default",
                "{controller}/{action}/{id?}",
                null,
                new
                {
                    controller = new MaxLengthRouteConstraint(5), // макс длина
                    action = new MinLengthRouteConstraint(3)     // мин длина
                });

            // Составное ограничение
            routeBuilder.MapRoute(
                name: "default",
                template: "{controller}/{action}/{id?}",
                defaults: new { controller = "Home", action = "index" },
                constraints: new
                {
                    action = new CompositeRouteConstraint(new IRouteConstraint[]
                    {
                        new AlphaRouteConstraint(),     // только из англ. алфавита
                        new MinLengthRouteConstraint(6) // не менее 6 символов
                    })
                });

            // Строчный синтаксис ограничений
            routeBuilder.MapRoute("default", "{controller:regex(^H.*)}/{action}/{id?}");

                // утановка рядо ограничений
            routeBuilder.MapRoute("default", "{controller:length(4)}/{action:alpha}/{id:range(4,100)}");

                // установка составного ограничения
            routeBuilder.MapRoute(
                name: "default",
                template: "{controller}/{action:alpha:minlength(6)}/{id?}",
                defaults: new { controller = "Home", action = "Index" });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
