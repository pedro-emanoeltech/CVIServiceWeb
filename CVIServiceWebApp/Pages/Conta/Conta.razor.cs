using CVIServiceWebApp.components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace CVIServiceWebApp.Pages.Conta
{
    public partial class Conta 
    {
        [CascadingParameter]
        private Task<AuthenticationState>? authenticationState { get; set; }
        [Inject] protected IJSRuntime js { get; set; } = default!;
        public bool Carregando { get; set; } = false;

       
        private async Task modelo()
        {
            var authState = await authenticationState!;
            var text = $"teste conta {authState.User.Identity!.Name!}";
            await js.InvokeVoidAsync("alert", text);
        }
    }

    
}
