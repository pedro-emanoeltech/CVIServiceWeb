﻿using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.App.Response;
using CVIServiceWebDomain.Interfaces.IRepository;
using CVIServiceWebDomain.Interfaces.IServices;

namespace CVIServiceWebDomain.Services
{
    public class ContaServices : BaseServices<ContaRequest, ContaResponse>,IContaServices
    {
        private readonly IContaRepository _repository;
        public ContaServices(IContaRepository repository) : base(repository)
        {
            _repository = repository;
        }
       public async Task<AuthenticateResponse?> Authentcate(AuthenticateRequest authenticateRequest)
        {
            return await _repository.Authentcate(authenticateRequest);
        }
    }
}
