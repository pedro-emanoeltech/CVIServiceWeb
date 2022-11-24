using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.App.Response;
using CVIServiceLibShared.Constants;
using CVIServiceWebDomain.Interfaces.IRepository;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace CVIServiceWebInfra.Repository
{
    public class LoginRepository : BaseRepository<AuthenticateRequest, AuthenticateResponse>, ILoginRepository
    {
        public LoginRepository(HttpClient httpClient) : base(httpClient, Resource.TOKEN)
        {
           
        }

        public async Task<AuthenticateResponse?> Authentcate(AuthenticateRequest T)
        {
            try
            {
                var Entity = JsonSerializer.Serialize(T);
                var conteudo = new StringContent(Entity, Encoding.UTF8, MediaTypeNames.Application.Json);
                //httpClient.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", access_token);
                //httpClient.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
                var uri = Endpoint.BASEURI + _resource + "/" + Resource.LOGIN;
                var result = await HttpClient.PostAsync(uri, conteudo);

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();
                    var EntityResult = JsonSerializer.Deserialize<AuthenticateResponse>(resp);
                    return EntityResult!;
                }
                else
                {
                    var error = await result.Content.ReadAsStringAsync();
                    throw new Exception(error);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
