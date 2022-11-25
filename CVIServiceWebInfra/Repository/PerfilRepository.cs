using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.App.Response;
using CVIServiceLibShared.Constants;
using CVIServiceWebDomain.Interfaces.IRepository;

namespace CVIServiceWebInfra.Repository
{
    public class PerfilRepository : BaseRepository<PerfilRequest, PerfilResponse>, IPerfilRepository
    {
        public PerfilRepository(HttpClient httpClient) : base(httpClient, Resource.PERFIL)
        {
           
        }

    }
}
