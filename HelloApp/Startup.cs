using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HelloApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Добавление MVC, как сервис в проект
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Установка маршрута для работы с контроллерами и их методами
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "BookStore",
                    defaults: new { controller = "Book", action = "Index" });

                routes.MapRoute(
                    name: "default1",
                    template: "Store/Sub{action}",
                    defaults: new { controller = "Home", action = "Index" });

                routes.MapRoute(
                    name: "default2",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
