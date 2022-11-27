using CVIServiceWebApp.IServicesApp;
using CVIServiceWebApp.ServicesApp;
using CVIServiceWebDomain.Interfaces.IRepository;
using CVIServiceWebDomain.Interfaces.IServices;
using CVIServiceWebDomain.Services;
using CVIServiceWebInfra.Repository;
using Microsoft.AspNetCore.Components.Authorization;

namespace CVIServiceWeb.Settings
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<IContaServices, ContaServices>();

            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IPerfilServices, PerfilServices>();

            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ILoginServices, LoginServices>();

            services.AddScoped<ILoginAuthProviderServicesApp, LoginAuthProviderServicesApp>();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationState>();

            return services;
        }
    }

}
