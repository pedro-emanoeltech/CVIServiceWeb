using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.App.Response;

namespace CVIServiceWebDomain.Interfaces.IRepository
{
    public interface ILoginRepository : IBaseRepository<AuthenticateRequest, AuthenticateResponse> 
    {
        Task<AuthenticateResponse?> Authentcate(AuthenticateRequest T);
    }
}
