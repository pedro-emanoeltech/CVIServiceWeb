using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.App.Response;
using CVIServiceWebDomain.Interfaces.IRepository;
using CVIServiceWebDomain.Interfaces.IServices;

namespace CVIServiceWebDomain.Services
{
    public class CandidaturaServices : BaseServices<CandidaturaRequest, CandidaturaResponse>, ICandidaturaServices
    {
        public CandidaturaServices(ICandidaturaRepository repository, HttpClient httpClient) : base(repository, httpClient)
        {
           
        }

     
    }
}
