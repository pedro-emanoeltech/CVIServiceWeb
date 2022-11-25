using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using System.Diagnostics.CodeAnalysis;

namespace CVIServiceWebApp.Components
{
    public abstract partial class Container: Base
    {
        [CascadingParameter]
        private Task<AuthenticationState>? authenticationState { get; set; }
        [Inject] protected ISnackbar Snackbar { get; set; } = default!;
        [Parameter, AllowNull] public RenderFragment CorpoContainer { get; set; }
        [Parameter, AllowNull] public string Titulo { get; set; } = string.Empty;

        public abstract RenderFragment RenderCorpoContainer();

        protected override void OnInitialized()
        {
            CorpoContainer = RenderCorpoContainer();
            base.OnInitialized();
        }
    }
}
