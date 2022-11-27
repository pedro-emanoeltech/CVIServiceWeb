
using Blazored.SessionStorage;
using CVIServiceLibShared.App.Response;
using CVIServiceWebApp.Settings;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace CVIServiceWebApp.ServicesApp
{
    public class CustomAuthenticationState : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessaoStorage;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthenticationState(ISessionStorageService sessaoStorage)
        {
            _sessaoStorage = sessaoStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var usuario = await _sessaoStorage.LerItemCriptSessaoAsync<AuthenticateResponse>("AuthenticateResponse");
                if (usuario == null)
                    return await Task.FromResult(new AuthenticationState(_anonymous));

                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Email,usuario.Email!),
                    new Claim(ClaimTypes.NameIdentifier,usuario.ContaId.ToString()!),
                    new Claim(ClaimTypes.Role,usuario.Role.ToString()!)

                }, "JwtAuth")); ;
                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));

            }
        }

        public async Task UpdateAuthState(AuthenticateResponse? authenticateResponse)
        {
            ClaimsPrincipal claimsPrincipal;

            if (authenticateResponse != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Email,authenticateResponse.Email!),
                    new Claim(ClaimTypes.NameIdentifier,authenticateResponse.ContaId.ToString()!),
                    new Claim(ClaimTypes.Role,authenticateResponse.Role.ToString()!)

                }));
                authenticateResponse.DataExpiracao = DateTime.UtcNow.AddSeconds(60);
                await _sessaoStorage.SalvarItemCriptSessaoAsync("AuthenticateResponse", authenticateResponse);
                
            }
            else
            {
                claimsPrincipal = _anonymous;
                await _sessaoStorage.RemoveItemAsync("AuthenticateResponse");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async Task<string> GetToken()
        {
            var result = string.Empty;
            try
            {
                var authenticateResponse = await _sessaoStorage.LerItemCriptSessaoAsync<AuthenticateResponse>("AuthenticateResponse");
                if (authenticateResponse != null && DateTime.UtcNow < authenticateResponse.DataExpiracao)
                    result = authenticateResponse.Token;
            }
            catch { }

            return result!;
        }


    }
}
