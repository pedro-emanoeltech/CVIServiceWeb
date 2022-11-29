using CVIServiceLibShared.App.Response;
using CVIServiceLibShared.Constants.Enums;
using CVIServiceWebApp.Components;
using CVIServiceWebDomain.Interfaces.IServices;
using CVIServiceWebDomain.Services;
using Microsoft.AspNetCore.Components;

namespace CVIServiceWebApp.Pages.Vagas
{
    public partial class Vagas : Container 
    {
        private static HttpClient _httpClient = new HttpClient();

        [Inject] private IVagaServices _vagaServices { get; set; } = default!;
        public List<VagaResponse> Enitties { get; set; } = new List<VagaResponse>();
       
        public string filtro { get; set; }
        public ModalidadeTrabalho _modalidadeTrabalho { get; set; } = ModalidadeTrabalho.Presencial;

        public DateTime? date { get; set; } 
        //[Inject] private I Services _perfilServices { get; set; } = default!;
       
        public bool Loading { get; set; } = false;

        protected override void OnInitialized()
        {
            CorpoContainer = RenderCorpoContainer();
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {

            await BuscarVaga();
            await base.OnInitializedAsync();

        }
        public async Task BuscarVaga()
        {
            try
            {
                Loading = true;
                var result = await _vagaServices.GetList();
                if ((result is not null) && (result.Count() > 0))
                {
  
                }
                Loading = false;
            }
            catch (System.Exception e)
            {
                Loading = false;
                Console.WriteLine(e.Message);
                Snackbar.Add(e.Message);
                throw;
            }
        }

    }
}
