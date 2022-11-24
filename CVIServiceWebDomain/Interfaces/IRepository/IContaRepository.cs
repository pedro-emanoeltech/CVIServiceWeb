﻿using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.App.Response;

namespace CVIServiceWebDomain.Interfaces.IRepository
{
    public interface IContaRepository : IBaseRepository<ContaRequest, ContaResponse> 
    {
        Task<AuthenticateResponse?> Authentcate(AuthenticateRequest T);
    }
}
