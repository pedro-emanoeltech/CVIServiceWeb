using CVIServiceLibShared.App.Response;
using CVIServiceWebApp.Components;
using Microsoft.AspNetCore.Components;

namespace CVIServiceWebApp.Pages.Perfil.Components
{
    public partial class CVICardPerfil : CVICard
    {
        public CVICardPerfil()
        {
            CVICardHeaderContent = "Informações Basicas";

        }
        [Parameter] public PerfilResponse PerfilResponse { get; set; } = default;

        protected override void OnInitialized()
        {
            
            CVICardContent = RenderCardContent();
            CVICardHeaderActions = RenderCardHeaderActions();
            CVICardContentActions = RenderCardContentActions();
            base.OnInitialized();
        }

    }
}
