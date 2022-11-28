using CVIServiceLibShared.App.Response;
using CVIServiceWebApp.Components;
using Microsoft.AspNetCore.Components;

namespace CVIServiceWebApp.Pages.Perfil.Components
{
    public partial class CVICardPerfil : CVICardResumo
    {
        public CVICardPerfil()
        {
            CVICardHeaderContent = "Resumo";
            CVICardctionDelete = true;

        }
        [Parameter] public PerfilResponse PerfilResponse { get; set; }

        private string EnderecoCompleto { get; set; } = string.Empty;


        protected override void OnInitialized()
        {
            GetEnderecoCompleto();
            CVICardContent = RenderCardContent();
            CVICardHeaderActions = RenderCardHeaderActions();
            CVICardContentActions = RenderCardContentActions();
            base.OnInitialized();
        }

        private void GetEnderecoCompleto()
        {
            try
            {
                if (PerfilResponse.Endereco is not null)
                {
                    EnderecoCompleto = $"{PerfilResponse.Endereco!.Logradouro},{PerfilResponse.Endereco!.Numero}," +
                   $"Bairro {PerfilResponse.Endereco!.Bairro}-{PerfilResponse.Endereco!.Cidade!.Nome}-" +
                   $"{PerfilResponse.Endereco!.Estado!.Nome}";
                }
               
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
