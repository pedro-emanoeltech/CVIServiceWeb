﻿using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.App.Response;
using CVIServiceLibShared.Constants;
using CVIServiceWebDomain.Interfaces.IRepository;
using System.Net.Mime;
using System.Text.Json;
using System.Text;

namespace CVIServiceWebInfra.Repository
{
    public class ContaRepository : BaseRepository<ContaRequest, ContaResponse>, IContaRepository
    {
        public ContaRepository(HttpClient httpClient) : base(httpClient, Resource.CONTA)
        {
           
        }

        public async Task<AuthenticateResponse?> Authentcate(AuthenticateRequest T)
        {
            try
            {
                var EntitySerializer = JsonSerializer.Serialize(T);
                var conteudo = new StringContent(EntitySerializer, Encoding.UTF8, MediaTypeNames.Application.Json);
                //httpClient.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", access_token);
                //httpClient.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
                var result = await HttpClient.PostAsync(Endpoint.BASEURI + _resource+Resource.LOGIN, conteudo);

                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsStringAsync();
                    var EntityResult = JsonSerializer.Deserialize<AuthenticateResponse>(resp);
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
    }
}
