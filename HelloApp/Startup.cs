using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloApp.Services;
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
            services.AddSingleton<ICounter, RandomCounter>();
            services.AddSingleton<CounterService>();
        }

        // Transient - объект сервиса создается каждый раз, когда к нему обращается запрос.
        //Подобная модель жизненного цикла наиболее подходит для легковесных сервисов, 
        //которые не хранят данных о состоянии.

        // Scoped - для каждого запроса создается свой объект сервиса.

        // Singleton - объект сервиса создается при первом обращении к нему,
        // все последующие запросы используют один и тот же ранее созданный объект сервиса.


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<CounterMiddleware>();
        }
    }
}
