using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.Constants;
using CVIServiceLibShared.Constants.Enums;
using CVIServiceLibShared.Constants.Textos;
using CVIServiceWebApp.Components;
using CVIServiceWebDomain.Interfaces.IServices;
using Microsoft.AspNetCore.Components;

using MudBlazor;
using System.Threading;

namespace CVIServiceWebApp.Pages.Conta
{
    public sealed partial class ContaCad : Base
    {
        [Inject] private IContaServices _contaServices { get; set; } = default!;
        [Inject] private NavigationManager NavigationManager { get; set; } = default!;
        [Inject] IDialogService DialogService { get; set; } = default!;
        [Inject] protected ISnackbar Snackbar { get; set; } = default!;
        public CancellationTokenSource _Source { get; set; } = new CancellationTokenSource();
        private CancellationToken Token { get; set; }
        public bool Carregando { get; set; } = false;
        public ContaRequest _conta { get; set; } = new ContaRequest();
        public string? confirmaSenha { get; set; } = string.Empty;
        public TipoConta TipoContaCadastro { get; set; } = TipoConta.Fisica;

        public bool termosDeUso = false;
        public bool termosTratamentoDeDados = false;

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
        private async Task CadastrarConta()
        {
            try
            {
                try
                {
                    _Source = new CancellationTokenSource();
                    Token = _Source.Token;

                    Carregando = true;
                    await VerificaSenha(Token);
                    await ValidaCamposConta(Token);
                    await ValidaTermosConta(Token);

                    _conta.TipoConta = TipoContaCadastro;
                    _conta.Status = Status.Ativo;
                    if (!Token.IsCancellationRequested)
                    {
                        var result = await _contaServices.Add(_conta);
                        Snackbar.Add("Cadastrado com sucesso !", MudBlazor.Severity.Success);
                        Carregando = false;
                        await Task.Delay(3000);

                        NavigationManager.NavigateTo("/login", true);

                    }
                }
                catch (OperationCanceledException)
                {
                    Carregando = false;

                    return;
                }
                finally { Carregando = false; }
            }
            catch (Exception e)
            {
                Carregando = false;
                Snackbar?.Add(e.Message, Severity.Error);
            }
        }
        private Task GetTipoContaCadastro(TipoConta tipoConta)
        {
            TipoContaCadastro = tipoConta;
            return Task.CompletedTask;
        }
        private Task VerificaSenha(CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(_conta.Senha!) || _conta.Senha!.Count() < 8)
                {
                    Snackbar.Add("Senha nao segue o padrao indicado,verifique ", MudBlazor.Severity.Error);
                    _Source.Cancel();
                }
                if (!string.IsNullOrEmpty(confirmaSenha))
                {
                    if (confirmaSenha.Count() < 8)
                    {
                        Snackbar.Add("Senha de confirmação nao segue o padrao indicado,verifique ", MudBlazor.Severity.Error);
                        _Source.Cancel();
                    }
                    if (string.IsNullOrEmpty(_conta.Senha) ||!_conta.Senha!.Equals(confirmaSenha))
                    {
                        Snackbar.Add("As senhas não são iguais. Tente novamente. ", MudBlazor.Severity.Error);
                        _Source.Cancel();
                    }
                }
                cancellationToken.ThrowIfCancellationRequested();
            }
            catch (OperationCanceledException)
            {
                throw;
            }

            return Task.CompletedTask;
        }
        private Task ValidaCamposConta(CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(_conta.Email))
                {
                    Snackbar.Add("É necessario Preencher Email, para registrar", MudBlazor.Severity.Warning);
                    _Source.Cancel();
                }
                cancellationToken.ThrowIfCancellationRequested();
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            return Task.CompletedTask;

        }
        private Task ValidaTermosConta(CancellationToken cancellationToken)
        {
            try
            {
                if (!termosDeUso)
                {
                    Snackbar.Add("É necessario confirmar Termos de Uso , antes de Registrar", MudBlazor.Severity.Warning);
                    _Source.Cancel();
                }
                if (!termosTratamentoDeDados)
                {
                    Snackbar.Add("É necessario confirmar o Termos de Consentimento LGPD, antes de Registrar", MudBlazor.Severity.Warning);
                    _Source.Cancel();
                }
                cancellationToken.ThrowIfCancellationRequested();
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            return Task.CompletedTask;

        }
        async Task OpenDialogTermosDeUso()
        {
            var parametros = new DialogParameters
                {
                    { "Termos", Termos.TERMOSDEUSO },
                };
            var result = await DialogService.Show<ContaDialogTermos>("Curriculo Inteligente Termos de Uso.", parametros).Result;

            if (!result.Cancelled)
            {
                termosDeUso = (bool)(result.Data ?? false);
            }
        }
        async Task OpenDialogTermosLGPD()
        {
            var parametros = new DialogParameters
                {
                    { "Termos", Termos.TERMOLGPD },
                };
            var result = await DialogService.Show<ContaDialogTermos>("Curriculo Inteligente Termos de Uso.", parametros).Result;

            if (!result.Cancelled)
            {
                termosTratamentoDeDados = (bool)(result.Data ?? false);
            }
        }

    }


}
