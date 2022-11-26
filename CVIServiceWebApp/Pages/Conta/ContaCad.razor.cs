using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.Constants.Enums;
using CVIServiceWebApp.Components;
using CVIServiceWebDomain.Interfaces.IServices;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CVIServiceWebApp.Pages.Conta
{
    public sealed partial class ContaCad : Container
    {
        [Inject] private IJSRuntime js { get; set; } = default!;
        [Inject] private IContaServices _contaServices { get; set; } = default!;
        [Inject] private NavigationManager NavigationManager { get; set; } = default!;

        public ContaRequest _conta { get; set; } = new ContaRequest();
        public string? confirmaSenha { get; set; } = string.Empty;

        public TipoConta? TipoContaCadastro { get; set; } 
        protected override void OnInitialized()
        {
            CorpoContainer = RenderCorpoContainer();
            base.OnInitialized();
        }
        private async Task CadastrarConta()
        {
            try
            {
                //var validaSenha = VerificaSenha();
                //var validaCampos  = ValidaCamposConta();

                _conta.TipoConta = TipoContaCadastro;
                _conta.Status = Status.Ativo;
                var result = await _contaServices.Add(_conta);
                    if (result is not null && result.Id.HasValue)
                    {
                        Snackbar.Add("Cadastrado com sucesso !", MudBlazor.Severity.Error);
                        NavigationManager.NavigateTo("/login", true);
                    }
            }
            catch (Exception e )
            {
               
                throw new Exception("Erro ao Cadastrar Conta "+e.Message);
            } 
        }
        private Task GetTipoContaCadastro(TipoConta? tipoConta)
        {
            TipoContaCadastro = tipoConta;
           return Task.CompletedTask;
        }

            private Task? VerificaSenha()
        {
            try
            {
                if (string.IsNullOrEmpty(_conta.Senha!) || _conta.Senha!.Count() < 8)
                {
                    Snackbar.Add("Senha nao segue o padrao indicado,verifique ", MudBlazor.Severity.Error);
                    return Task.CompletedTask;
                }
                if (!string.IsNullOrEmpty(confirmaSenha))
                {
                    if (confirmaSenha.Count() < 8)
                    {
                        Snackbar.Add("Senha de confirmação nao segue o padrao indicado,verifique ", MudBlazor.Severity.Error);
                        new Exception();
                    }
                    if (_conta.Senha! == confirmaSenha)
                    {
                        Snackbar.Add("As senhas não são iguais. Tente novamente. ", MudBlazor.Severity.Error);
                        new Exception();
                    }
                }
                return Task.CompletedTask;
            }
            catch 
            {
                throw;
            }

        }
        private Task ValidaCamposConta()
        {
            try
            {
                if (string.IsNullOrEmpty(_conta.Email))
                {
                    Snackbar.Add("Preencha corretamente o E-mail", MudBlazor.Severity.Warning);
                    new Exception();
                }
            }
            catch (Exception e)
            {
                Snackbar.Add("Erro ao Cadastrar Conta" + e.Message, MudBlazor.Severity.Error);
                throw;
            }
            return Task.CompletedTask;

        }

    }

    
}
