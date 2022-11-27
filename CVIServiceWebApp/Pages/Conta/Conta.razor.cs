using CVIServiceWebApp.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;

namespace CVIServiceWebApp.Pages.Conta
{
    public sealed partial class Conta : Container
    {
        [CascadingParameter]
        private Task<AuthenticationState>? authenticationState { get; set; }
        [Inject] private IJSRuntime js { get; set; } = default!;
        public string? texto { get; set; } =  string.Empty;

        protected override void OnInitialized()
        {
            CorpoContainer = RenderCorpoContainer();
            base.OnInitialized();
        }

        private async Task modelo()
        {
            var authState = await authenticationState!;
            var text = $"teste conta {authState.User.Claims.Where(p=> p.Type == ClaimTypes.Role).Select(c=>c.Value).SingleOrDefault()
                }";
            await js.InvokeVoidAsync("alert", text);

            var t2 = $"teste conta {authState.User.Claims.Where(p => p.Type == ClaimTypes.Email).Select(c => c.Value).SingleOrDefault()}";
            await js.InvokeVoidAsync("alert", t2);

            var t1 = $"teste conta {authState.User.Claims.Where(p => p.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault()}";
            await js.InvokeVoidAsync("alert", t1);
            texto = authState.User.Identity!.Name;

        }
    }

    
}
