using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Diagnostics.CodeAnalysis;

namespace CVIServiceWebApp.Components
{
    public abstract partial class CVICard : MudCard
    {
        [Parameter] public string CVICardTitulo { get; set; } = "";
        [Parameter] public bool CVICardctionDelete { get; set; } = false;
        [Parameter] public bool AtivoBotaoPadrao { get; set; } = true;
        [Parameter, AllowNull] public RenderFragment CVICardContent { get; set; }
        [Parameter, AllowNull] public RenderFragment CVICardHeaderActions { get; set; }
        [Parameter, AllowNull] public RenderFragment CVICardContentActions { get; set; }
        [Parameter, AllowNull] public RenderFragment CVICardHeaderContents { get; set; }
        [Parameter, AllowNull] public RenderFragment CVICardHeaderAvatar { get; set; }
        

        protected override void OnInitialized()
        {
            CVICardHeaderAvatar     = RenderCardHeaderAvatar();
            CVICardContent          = RenderCardContent();
            CVICardHeaderActions    = RenderCardHeaderActions();
            CVICardHeaderContents   = RenderHeaderContent();
            CVICardContentActions   = RenderCardContentActions();
            base.OnInitialized();
        }
        public abstract RenderFragment RenderCardHeaderAvatar();

        public abstract RenderFragment RenderCardHeaderActions();
        public abstract RenderFragment RenderHeaderContent();
        public abstract RenderFragment RenderCardContentActions();
        public abstract RenderFragment RenderCardContent();
    }
}
