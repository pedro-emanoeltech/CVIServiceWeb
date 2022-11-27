using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Diagnostics.CodeAnalysis;

namespace CVIServiceWebApp.Components
{
    public abstract partial class CVICard : MudCard
    {
        [Parameter] public string CVICardHeaderContent { get; set; } = "";
        [Parameter] public bool CVICardctionDelete { get; set; } = false;
        [Parameter, AllowNull] public RenderFragment CVICardContent { get; set; }
        [Parameter, AllowNull] public RenderFragment CVICardHeaderActions { get; set; }
        [Parameter, AllowNull] public RenderFragment CVICardContentActions { get; set; }
        protected override void OnInitialized()
        {

            CVICardContent          = RenderCardContent();
            CVICardHeaderActions    = RenderCardHeaderActions();
            CVICardContentActions   = RenderCardContentActions();
            base.OnInitialized();
        }



        public abstract RenderFragment RenderCardHeaderActions();
        public abstract RenderFragment RenderCardContentActions();
        public abstract RenderFragment RenderCardContent();
    }
}
