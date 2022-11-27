using CVIServiceLibShared.App.Response;
using CVIServiceWebApp.Components;
using CVIServiceWebDomain.Interfaces.IServices;
using Microsoft.AspNetCore.Components;

namespace CVIServiceWebApp.Pages.Perfil
{
    public partial class Perfil : Container
    {

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
        public async Task GetPerfil()
        {
            try
            {
                Perfis = await _perfilServices.GetList();
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
