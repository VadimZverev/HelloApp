using Microsoft.Extensions.DependencyInjection;

namespace HelloApp.Services
{
    public static class ServiceProviderExtentions
    {
        public static void AddTimeService(this IServiceCollection services)
        {
            services.AddTransient<TimeService>();
        }
    }
}
