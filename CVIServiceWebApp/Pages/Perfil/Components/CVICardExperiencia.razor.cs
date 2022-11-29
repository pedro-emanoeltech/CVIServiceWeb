using CVIServiceLibShared.App.Response;
using CVIServiceWebApp.Components;
using Microsoft.AspNetCore.Components;

namespace CVIServiceWebApp.Pages.Perfil.Components
{
    public partial class CVICardExperiencia : CVICard
    {
        [Parameter] public HistoricoProfissionalResponse HistoricoProfissional  { get; set; }
 
       

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
 