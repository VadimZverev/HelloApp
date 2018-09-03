﻿using System;
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
        public Startup()
        {
            // строитель конфигурации
            var builder = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    {"firsname", "Tom" },
                    {"age", "31" }
                });

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
            AppConfiguration["firstname"] = "alice";
            AppConfiguration["lastname"] = "simpson";
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(AppConfiguration["firstname"] + " "
                    + AppConfiguration["lastname"]);
            });
        }
    }
}
