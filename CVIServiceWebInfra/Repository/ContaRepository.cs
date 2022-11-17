using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.App.Response;
using CVIServiceLibShared.Constants;

namespace CVIServiceWebInfra.Repository
{
    public class ContaRepository : BaseRepository<ContaRequest, ContaResponse>
    {
        public ContaRepository(HttpClient httpClient) : base(httpClient, Resource.CONTA)
        {
           
        }
    }
}
