using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.App.Response;
using CVIServiceWebDomain.Interfaces.IRepository;
using CVIServiceWebDomain.Interfaces.IServices;

namespace CVIServiceWebDomain.Services
{
    public abstract class BaseServices<TRequest, TResponse> :
        IBaseServices<TRequest, TResponse> where TRequest : BaseRequest where TResponse : BaseResponse
    {
        private readonly IBaseRepository<TRequest, TResponse> _repository;
        protected readonly HttpClient HttpClient;
        public BaseServices(IBaseRepository<TRequest, TResponse> repository, HttpClient httpClient)
        {
            HttpClient = httpClient;
            _repository = repository;
        }
        public virtual async Task<TResponse?> Add(TRequest T)
        {
           return await _repository.Add(T);
        }

        public virtual async Task<bool> Delete(string id)
        {
            return await _repository.Delete(id);
        }

        public virtual async Task<TResponse?> Edit(TRequest T, string id)
        {
            return await _repository.Edit(T,id);
        }

        public virtual async Task<TResponse?> Get(string id)
        {
            return await _repository.Get(id);
        }

        public virtual async Task<IList<TResponse>> GetList()
        {
            return await _repository.GetList();
        }
    }
}
