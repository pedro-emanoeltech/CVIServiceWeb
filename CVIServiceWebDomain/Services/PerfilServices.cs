using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.App.Response;
using CVIServiceWebDomain.Interfaces.IRepository;
using CVIServiceWebDomain.Interfaces.IServices;

namespace CVIServiceWebDomain.Services
{
    public class PerfilServices : BaseServices<PerfilRequest, PerfilResponse>, IPerfilServices
    {
        public PerfilServices(IPerfilRepository repository) : base(repository)
        {
           
        }
     
    }
}
