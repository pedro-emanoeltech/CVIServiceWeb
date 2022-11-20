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
        public BaseServices(IBaseRepository<TRequest, TResponse> repository)
        {
            _repository = repository;
        }
        public virtual async Task<TResponse?> Add(TRequest T)
        {
           return await _repository.Add(T);
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        public virtual async Task<TResponse?> Edit(TRequest T, Guid id)
        {
            return await _repository.Edit(T,id);
        }

        public virtual async Task<TResponse?> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        public virtual async Task<IList<TResponse>> GetList()
        {
            return await _repository.GetList();
        }
    }
}
