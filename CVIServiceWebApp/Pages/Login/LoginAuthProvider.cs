using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;

namespace CVIServiceWebApp.Pages.Login
{
    public class LoginAuthProvider
    {
        [Inject] private AuthenticationStateProvider authenticationProvider { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; } = default!;

        public async Task Logout()
        {
            var authservices = (CustomAuthenticationState)authenticationProvider;
            await authservices.UpdateAuthState(null);
            navigationManager.NavigateTo("/", true);

        }
    }
}
