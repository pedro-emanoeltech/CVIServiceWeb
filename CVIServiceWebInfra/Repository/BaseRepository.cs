using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.App.Response;
using CVIServiceLibShared.Constants;
using CVIServiceWebDomain.Interfaces.IRepository;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace CVIServiceWebInfra.Repository
{
    public abstract class BaseRepository<TRequest, TResponse> :
        IBaseRepository<TRequest, TResponse> where TRequest : BaseRequest where TResponse : BaseResponse
    {
        protected readonly HttpClient HttpClient;
        protected readonly string _resource;
        public BaseRepository(HttpClient httpClient,string resource)
        {
            HttpClient = httpClient;
            _resource = resource;
        }
        public virtual async Task<TResponse?> Get(Guid id)
        {
            try
            {
                var result = await HttpClient.GetAsync(_resource + "/" + id.ToString());

                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    var entity = JsonSerializer.Deserialize<TResponse>(response);
                    return entity!;
                }
                else
                {
                    throw new Exception(await result.Content.ReadAsStringAsync());
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual async Task<IList<TResponse>> GetList()
        {
            try
            {
                var uri = $"{Endpoint.BASEURI + _resource}";
                var result = await HttpClient.GetAsync(uri);

                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    var entities = JsonSerializer.Deserialize<IList<TResponse>>(response);
                    return entities!;
                }
                else
                {
                    throw new Exception(await result.Content.ReadAsStringAsync());
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual async Task<TResponse?> Add(TRequest T)
        {
            try
            {
                var EntitySerializer = JsonSerializer.Serialize(T);
                var conteudo = new StringContent(EntitySerializer, Encoding.UTF8, MediaTypeNames.Application.Json);
                //httpClient.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", access_token);
                //httpClient.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
                var result = await HttpClient.PostAsync(Endpoint.BASEURI + _resource, conteudo);

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();
                    var EntityResult = JsonSerializer.Deserialize<TResponse>(resp);
                    return EntityResult!;
                }
                else
                {
                    var respFalha = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(respFalha);
                    throw new Exception(respFalha);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual async Task<TResponse?> Edit(TRequest t, Guid id)
        {
            try
            {
                var entitySerializer = JsonSerializer.Serialize(t);
                var result = await HttpClient.PutAsync(Endpoint.BASEURI + _resource + "/" + id.ToString()
                    , new StringContent(entitySerializer));

                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    var SerializerResult = JsonSerializer.Deserialize<TResponse>(response);
                    return SerializerResult!;
                }
                else
                {
                    Console.WriteLine(await result.Content.ReadAsStringAsync());
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception( e.Message);
            }
        }
        public virtual async Task<bool> Delete(Guid id)
        {
            try
            {
                var response = await HttpClient.DeleteAsync(Endpoint.BASEURI + _resource + "/" + id.ToString());
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
