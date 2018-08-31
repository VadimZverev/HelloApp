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
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Use(async (context, next) =>
            //{
            //    context.Items["text"] = "Text from HttpContext.Items";
            //    await next.Invoke();
            //});

            //app.Run(async (context) =>
            //{
            //    if (context.Request.Cookies.ContainsKey("name"))
            //    {
            //        string name = context.Request.Cookies["name"];
            //        await context.Response.WriteAsync($"Привет {name}");
            //    }
            //    else
            //    {
            //        context.Response.ContentType = "text/html;charset=utf-8";
            //        context.Response.Cookies.Append("name", "Tom");
            //        await context.Response.WriteAsync($"Привет Мир!");
            //    }
            //});

            app.UseSession();
            //app.Run(async (context) =>
            //{
            //    if (context.Session.Keys.Contains("name"))
            //    {
            //        await context.Response.WriteAsync($"Привет {context.Session.GetString("name")}!");
            //    }
            //    else
            //    {
            //        context.Response.ContentType = "text/html;charset=utf-8";
            //        context.Session.SetString("name", "Tom");
            //        await context.Response.WriteAsync($"Привет Мир!");
            //    }
            //});

            app.Run(async (context) =>
            {
                if (context.Session.Keys.Contains("person"))
                {
                    Person person = context.Session.Get<Person>("person");
                    await context.Response.WriteAsync($"Привет {person.Name}!");
                }
                else
                {
                    context.Response.ContentType = "text/html;charset=utf-8";

                    Person person = new Person { Name = "Tom", Age = 22 };
                    context.Session.Set("person", person);

                    await context.Response.WriteAsync($"Привет Мир!");
                }
            });

            //app.Run(async (context) =>
            //{
            //context.Response.ContentType = "text/html;charset=utf-8";
            //    await context.Response.WriteAsync($"Текст: {context.Items["text"]}");
            //});
        }
    }
}
