using CVIServiceLibShared.App.Response;
using CVIServiceWebApp.Components;
using CVIServiceWebDomain.Interfaces.IServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;

namespace CVIServiceWebApp.Pages.Perfil
{
    public partial class Perfil : Container
    {
        [CascadingParameter]
        private Task<AuthenticationState>? authenticationState { get; set; }
        [Inject] protected IJSRuntime js { get; set; } = default!;
        public IList<PerfilResponse>? Perfis { get; set; } = new List<PerfilResponse>();
        [Inject] private IPerfilServices _perfilServices { get; set; } = default!;

        protected override void OnInitialized()
        {
            CorpoContainer = RenderCorpoContainer();
            base.OnInitialized();
        }
        public async Task GetPerfil()
        {
            try
            {
                Perfis = await _perfilServices.GetList();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                Snackbar.Add(e.Message);    
                throw;
            }
               
            
        }

    }

    
}
