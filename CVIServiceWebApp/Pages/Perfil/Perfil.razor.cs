using CVIServiceLibShared.App.Response;
using CVIServiceWebApp.Components;
using CVIServiceWebDomain.Interfaces.IServices;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CVIServiceWebApp.Pages.Perfil
{
    public partial class Perfil : Container
    {
        private static HttpClient _httpClient = new HttpClient();
        public IList<PerfilResponse>? Perfis { get; set; } = new List<PerfilResponse>();
        public PerfilResponse Enitty { get; set; } = new PerfilResponse();
        [Inject] private IPerfilServices _perfilServices { get; set; } = default!;
        public string ImagePerfil { get; set; } = "https://cdn.pixabay.com/photo/2016/11/18/23/38/child-1837375_960_720.png";
        public string NomePerfil { get; set; } = "Pedro Emanoel";
        protected override void OnInitialized()
        {

            CorpoContainer = RenderCorpoContainer();
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            await GetPerfil();
            await base.OnInitializedAsync();

        }


        public async Task GetPerfil()
        {
            try
            {
                var result = await _perfilServices.GetList();
                if ((result is not null) && (result.Count() > 0))
                {

                    Enitty = await _perfilServices.Get(result[0].Id.ToString()!)!;
                    //Perfis = result.Select(x=> x.ContaId == );
                }

            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                Snackbar.Add(e.Message);
                throw;
            }
        }

    }


}
