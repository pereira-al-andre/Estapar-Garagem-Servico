using Microsoft.Extensions.DependencyInjection;

namespace ETP.Domain
{
    public static class DomainModule
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
