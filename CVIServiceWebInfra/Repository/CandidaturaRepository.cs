using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.App.Response;
using CVIServiceLibShared.Constants;
using CVIServiceWebDomain.Interfaces.IRepository;

namespace CVIServiceWebInfra.Repository
{
    public class CandidaturaRepository : BaseRepository<CandidaturaRequest, CandidaturaResponse>, ICandidaturaRepository
    {
        public CandidaturaRepository(HttpClient httpClient) : base(httpClient, Resource.CANDIDATURA)
        {
           
        }

    }
}
