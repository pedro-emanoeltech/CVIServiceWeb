using Microsoft.AspNetCore.Components.Authorization;

namespace CVIServiceWebApp.IServicesApp
{
    public interface ILoginAuthProviderServicesApp
    {
        Task Logout(AuthenticationStateProvider authenticationProvider);
    }
}
