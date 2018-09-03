using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HelloApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // строитель конфигурации
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddIniFile("conf.ini");

            // создаём конфигурацию
            AppConfiguration = builder.Build();
        }

        // свойство, которое будет хранить конфигурацию
        public IConfiguration AppConfiguration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            string java_dir = AppConfiguration["JAVA_HOME"] ?? "not set";
            var text = AppConfiguration["text"];
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(java_dir);
            });
        }
    }
}
