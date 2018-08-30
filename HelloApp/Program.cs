using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HelloApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
            var host = new WebHostBuilder()
                .UseKestrel()               // настраиваем веб-сервер Kestrel
                .UseContentRoot(Directory.GetCurrentDirectory())    // настраиваем корневой каталог приложения
                .UseIISIntegration()        // обеспечиваем интеграцию с IIS
                .UseStartup<Startup>()      // устанавливаем главный файл приложения
                .Build();                   // создаём хост
            host.Run();                     // запускаем приложение
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
