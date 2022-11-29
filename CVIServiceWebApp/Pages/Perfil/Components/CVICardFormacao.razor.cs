using CVIServiceLibShared.App.Response;
using CVIServiceWebApp.Components;
using Microsoft.AspNetCore.Components;

namespace CVIServiceWebApp.Pages.Perfil.Components
{
    public partial class CVICardFormacao : CVICard
    {
        [Parameter] public CursoFormacaoAcademicaResponse? CursoFormacaoAcademica { get; set; }
  
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
 