using CVIServiceLibShared.App.Response;
using CVIServiceWebApp.Components;
using CVIServiceWebDomain.Interfaces.IServices;
using Microsoft.AspNetCore.Components;

namespace CVIServiceWebApp.Pages.Vagas
{
    public partial class Vagas : Container 
    {
        private static HttpClient _httpClient = new HttpClient();
       
        public VagaResponse Enitty { get; set; } = new VagaResponse();
        //[Inject] private I Services _perfilServices { get; set; } = default!;
       
        public bool Loading { get; set; } = false;


    }
}
