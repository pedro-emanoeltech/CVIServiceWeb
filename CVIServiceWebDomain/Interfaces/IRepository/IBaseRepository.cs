using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.App.Response;

namespace CVIServiceWebDomain.Interfaces.IRepository
{
    public interface IBaseRepository<TRequest, TResponse> where TRequest : BaseRequest where TResponse : BaseResponse
    {
        Task<TResponse?> Get(Guid id);
      
        Task<IList<TResponse>> GetList();
       
        Task<TResponse?> Add(TRequest T);
     
        Task<TResponse?> Edit(TRequest T, Guid id);
    
        Task<bool> Delete(Guid id);
      
    }
}
