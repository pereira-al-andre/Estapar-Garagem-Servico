using Microsoft.Extensions.DependencyInjection;
using ETP.Infra.Repositories.Common;
using ETP.Domain.Repository;
using ETP.Infra.Repositories;

namespace ETP.Infra
{
    public static class InfraModule
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(Repository<>), typeof(Repository<>));
            services.AddScoped<IGaragemRepository, GaragemRepository>();
            services.AddScoped<IFormaPagamentoRepository, FormaPagamentoRepository>();
            services.AddScoped<IPassagemRepository, PassagemRepository>();

            return services;
        }
    }
}
