using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.App.Response;
using CVIServiceWebDomain.Interfaces.IRepository;
using CVIServiceWebDomain.Interfaces.IServices;

namespace CVIServiceWebDomain.Services
{
    public class VagaServices : BaseServices<VagaRequest, VagaResponse>, IVagaServices
    {
        public VagaServices(IVagaRepository repository, HttpClient httpClient) : base(repository, httpClient)
        {
           
        }

     
    }
}
