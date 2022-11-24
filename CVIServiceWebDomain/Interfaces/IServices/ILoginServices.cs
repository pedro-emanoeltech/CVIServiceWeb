using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.App.Response;

namespace CVIServiceWebDomain.Interfaces.IServices
{
    public interface ILoginServices : IBaseServices<AuthenticateRequest, AuthenticateResponse>
    {
        Task<AuthenticateResponse?> Authentcate(AuthenticateRequest T);
    }
}
