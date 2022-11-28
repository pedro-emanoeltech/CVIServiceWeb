using CVIServiceLibShared.App.Response;
using CVIServiceWebApp.Components;
using Microsoft.AspNetCore.Components;

namespace CVIServiceWebApp.Pages.Vagas.Components
{
    public partial class CVICardVagas  : CVICard
    {
        [Parameter] public VagaResponse VagaResponse { get; set; }
        public CVICardVagas()
        {
            
        }
       

        protected override void OnInitialized()
        {
            CVICardContent = RenderCardContent();
            CVICardHeaderActions = RenderCardHeaderActions();
            CVICardContentActions = RenderCardContentActions();
            CVICardHeaderContents = RenderHeaderContent();
            base.OnInitialized();
        }


    }
}
 