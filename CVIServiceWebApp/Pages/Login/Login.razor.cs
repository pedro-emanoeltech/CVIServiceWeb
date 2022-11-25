using CVIServiceLibShared.App.Request;
using CVIServiceWebApp.ServicesApp;
using CVIServiceWebDomain.Interfaces.IServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using MudBlazor;


namespace CVIServiceWebApp.Pages.Login
{
    public partial class Login
    {
        [Inject] private AuthenticationStateProvider? authenticationProvider { get; set; }

        [Inject] protected IJSRuntime js { get; set; } = default!;

        private AuthenticateRequest Entity = new AuthenticateRequest();

        public bool logou = false;
        [Inject] protected ISnackbar Snackbar { get; set; } = default!;
        [Inject] protected ILoginServices _LoginServices { get; set; } = default!;
        [Inject] private NavigationManager NavigationManager { get; set; } = default!;
        public async Task Authentcate()
        {
            try
            {
                var token = await _LoginServices.Authentcate(Entity);
                if (token is not null && !string.IsNullOrEmpty(token.Token))
                {
                    var authservices = (CustomAuthenticationState)authenticationProvider!;
                    await authservices.UpdateAuthState(token);
                    NavigationManager.NavigateTo("/",true);
                }
                else
                {
                    Snackbar.Add("Usuario ou senha Invalido !",Severity.Warning);
                    return;
                }
           
            }
            catch (Exception e)
            {
                Snackbar.Add($"Não foi possível realizar o login do usuário. (Erro: {e.Message})");
               
            }
        }

        public void Cadastrar()
        {
            NavigationManager.NavigateTo("/novaconta");
        }
    }
}
