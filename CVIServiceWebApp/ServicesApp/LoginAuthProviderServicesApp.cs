using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using CVIServiceWebApp.IServicesApp;
using System.Net.Http;

namespace CVIServiceWebApp.ServicesApp
{
    public class LoginAuthProviderServicesApp : ILoginAuthProviderServicesApp
    {
        [Inject] private NavigationManager navigationManager { get; set; } = default!;

        public async Task Logout(AuthenticationStateProvider authenticationProvider)
        {
            try
            {   
                var authservices = (CustomAuthenticationState)authenticationProvider!;
                await authservices.UpdateAuthState(null);
                navigationManager.NavigateTo("/login", true);
               
            }
            catch (Exception e )
            {

                throw new Exception($"Erro ao Sair {e.Message}") ;
            }
           

        }
    }
}
