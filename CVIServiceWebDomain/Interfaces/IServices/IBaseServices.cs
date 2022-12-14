using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.App.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVIServiceWebDomain.Interfaces.IServices
{
    public interface IBaseServices<TRequest, TResponse> where TRequest : BaseRequest where TResponse : BaseResponse
    {
        Task<TResponse?> Get(string id);

        Task<IList<TResponse>> GetList();

        Task<TResponse?> Add(TRequest T);

        Task<TResponse?> Edit(TRequest T, string id);

        Task<bool> Delete(string id);
    }
}
