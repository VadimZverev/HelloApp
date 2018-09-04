using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HelloApp
{
    public class ConfigMiddleware
    {
        private readonly RequestDelegate _next;
        public IConfiguration AppConfiguration { get; set; }

        public ConfigMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            AppConfiguration = config;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var color = AppConfiguration["color"];
            var text = AppConfiguration["text"];
            await context.Response.WriteAsync($"<p style='color:{color};'>{text}</p>");
        }
    }
}
