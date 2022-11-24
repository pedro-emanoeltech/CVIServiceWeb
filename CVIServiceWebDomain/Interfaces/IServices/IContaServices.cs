using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.App.Response;

namespace CVIServiceWebDomain.Interfaces.IServices
{
    public interface IContaServices :IBaseServices<ContaRequest,ContaResponse>
    {
        Task<AuthenticateResponse?> Authentcate(AuthenticateRequest T);
    }
}
