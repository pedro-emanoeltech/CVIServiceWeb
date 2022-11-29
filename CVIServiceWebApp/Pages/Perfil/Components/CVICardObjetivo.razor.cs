using CVIServiceLibShared.App.Response;
using CVIServiceWebApp.Components;
using Microsoft.AspNetCore.Components;

namespace CVIServiceWebApp.Pages.Perfil.Components
{
    public partial class CVICardObjetivo : CVICard
    {
        public CVICardObjetivo()
        {
            CVICardctionDelete = true;
        }
        [Parameter] public ObjetivoResponse ObjetivoResponse { get; set; }

        protected override void OnInitialized()
        {
            CVICardHeaderAvatar = RenderCardHeaderAvatar();
            CVICardContent = RenderCardContent();
            CVICardHeaderActions = RenderCardHeaderActions();
            CVICardContentActions = RenderCardContentActions();
            CVICardHeaderContents = RenderHeaderContent();
            base.OnInitialized();
        }


    }
}
 