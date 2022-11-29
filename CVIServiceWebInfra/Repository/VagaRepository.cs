using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.App.Response;
using CVIServiceLibShared.Constants;
using CVIServiceWebDomain.Interfaces.IRepository;

namespace CVIServiceWebInfra.Repository
{
    public class VagaRepository : BaseRepository<VagaRequest, VagaResponse>, IVagaRepository
    {
        public VagaRepository(HttpClient httpClient) : base(httpClient, Resource.VAGA)
        {
           
        }

    }
}
