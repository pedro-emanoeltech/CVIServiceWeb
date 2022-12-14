using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.App.Response;
using CVIServiceLibShared.Constants;
using CVIServiceWebDomain.Interfaces.IRepository;

namespace CVIServiceWebInfra.Repository
{
    public class ContaRepository : BaseRepository<ContaRequest, ContaResponse>, IContaRepository
    {
        public ContaRepository(HttpClient httpClient) : base(httpClient, Resource.CONTA)
        {
   
        }

    }
}
