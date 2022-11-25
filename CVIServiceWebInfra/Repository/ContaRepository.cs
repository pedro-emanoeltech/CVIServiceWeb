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

    }
}
