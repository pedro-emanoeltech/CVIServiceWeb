using CVIServiceLibShared.App.Request;
using CVIServiceWebDomain.Interfaces.IServices;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MudBlazor;


namespace CVIServiceWebApp.Pages.Login
{
    public partial class Login
    {
        private AuthenticateRequest Entity = new AuthenticateRequest();
        public bool logou = false;
        [Inject] protected ISnackbar Snackbar { get; set; } = default!;
        [Inject] protected IContaServices _contaServices { get; set; } = default!;
 
        private string id { get; set; } = "a8594b55-8890-40ba-b500-3abc8f3a8348";
        public async Task LoginAsync()
        {
            try
            {
                var token = await _contaServices.Get(Guid.Parse(id));
                if (token is not null)
                {
                    await authStateProvider.Login(token?.!);
                    navigation.NavigateTo("/");
                }
                logou = true;
            }
            catch (Exception e)
            {
                Snackbar.Add($"Não foi possível realizar o login do usuário. (Erro: {e.Message})");
                logou = true;
            }
        }

        public void Cadastrar()
        {
            Navigation.NavigateTo("/novaconta");
        }
    }
}
