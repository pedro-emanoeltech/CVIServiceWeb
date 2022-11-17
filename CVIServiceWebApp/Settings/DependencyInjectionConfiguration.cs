
using CVIServiceWebDomain.Interfaces.IRepository;
using CVIServiceWebInfra.Repository;

namespace CVIServiceWebApp.Settings
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IContaRepository, ContaRepository>();



            return services;
        }
    }

}
