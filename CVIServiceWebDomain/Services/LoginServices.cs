using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.App.Response;
using CVIServiceWebDomain.Interfaces.IRepository;
using CVIServiceWebDomain.Interfaces.IServices;

namespace CVIServiceWebDomain.Services
{
    public class LoginServices : BaseServices<AuthenticateRequest, AuthenticateResponse>,ILoginServices
    {
        private readonly ILoginRepository _repository;
        public LoginServices(ILoginRepository repository, HttpClient httpClient) : base(repository, httpClient)
        {
            _repository = repository;
        }
       public async Task<AuthenticateResponse?> Authentcate(AuthenticateRequest authenticateRequest)
        {
            return await _repository.Authentcate(authenticateRequest);
        }
    }
}
