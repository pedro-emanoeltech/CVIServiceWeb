using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.App.Response;
using CVIServiceWebDomain.Interfaces.IRepository;

namespace CVIServiceWebDomain.Services
{
    public class ContaServices : BaseServices<ContaRequest, ContaResponse>
    {
        public ContaServices(IContaRepository repository) : base(repository)
        {
        }
    }
}
