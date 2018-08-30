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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.MapWhen(context =>
            {
                return context.Request.Query.ContainsKey("id") &&
                        context.Request.Query["id"] == "5";
            }, HandleId);

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Good bye, World...");
            });
        }

        private void HandleId(IApplicationBuilder app)
        {
            app.Run(async context => await context.Response.WriteAsync("id is equal to 5"));
        }
    }
}
