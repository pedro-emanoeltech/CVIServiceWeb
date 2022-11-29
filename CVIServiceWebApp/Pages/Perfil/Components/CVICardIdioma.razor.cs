using CVIServiceLibShared.App.Response;
using CVIServiceWebApp.Components;
using Microsoft.AspNetCore.Components;

namespace CVIServiceWebApp.Pages.Perfil.Components
{
    public partial class CVICardIdioma : CVICard
    {
        [Parameter] public IdiomaResponse IdiomaResponse { get; set; }
        public CVICardIdioma()
        {
            
        }
       

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
 