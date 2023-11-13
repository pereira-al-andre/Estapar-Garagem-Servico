using Microsoft.Extensions.DependencyInjection;

namespace ETP.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IGaragemService, GaragemService>();

            return services;
        }
    }
}
