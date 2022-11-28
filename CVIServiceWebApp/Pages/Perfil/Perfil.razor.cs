using CVIServiceLibShared.App.Response;
using CVIServiceWebApp.Components;
using CVIServiceWebDomain.Interfaces.IServices;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace CVIServiceWebApp.Pages.Perfil
{
    public partial class Perfil : Container
    {
        private static HttpClient _httpClient = new HttpClient();
        public IList<PerfilResponse>? Perfis { get; set; } = new List<PerfilResponse>();
        public PerfilResponse Enitty { get; set; } = new PerfilResponse();
        [Inject] private IPerfilServices _perfilServices { get; set; } = default!;
        public string ImagePerfil { get; set; } = "https://www.canalpedroemanuel.com/wp-content/uploads/2022/11/pedro-foto.jpg";
        public bool Loading { get; set; } = false;
        


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
                Loading = true;
                var result = await _perfilServices.GetList();
                if ((result is not null) && (result.Count() > 0))
                {

                    Enitty = await _perfilServices.Get(result[0]!.Id.ToString()!)!;
                    //Perfis = result.Select(x=> x.ContaId == );
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
