using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.App.Response;
using CVIServiceWebDomain.Interfaces.IRepository;
using CVIServiceWebDomain.Interfaces.IServices;

namespace CVIServiceWebDomain.Services
{
    public class ContaServices : BaseServices<ContaRequest, ContaResponse>,IContaServices
    {
        public ContaServices(IContaRepository repository, HttpClient httpClient) : base(repository, httpClient)
        {
           
        }
     
    }
}
