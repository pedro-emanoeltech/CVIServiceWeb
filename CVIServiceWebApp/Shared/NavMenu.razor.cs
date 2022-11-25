using CVIServiceWebApp.IServicesApp;
using CVIServiceWebApp.ServicesApp;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace CVIServiceWebApp.Shared
{
    public partial class NavMenu 
    {
        [Inject] private AuthenticationStateProvider? authenticationProvider { get; set; }
        [Inject] private ILoginAuthProviderServicesApp? LoginAuthServices { get; set; } 
        public string ImagePerfil { get; set; } = "https://cdn.pixabay.com/photo/2016/11/18/23/38/child-1837375_960_720.png";
        public string NomePerfil { get; set; } = "Pedro Emanoel";
        public string? Search { get; set; }

        public async Task Sair()
        {
            await LoginAuthServices.Logout(authenticationProvider!);
        }

    }
}
