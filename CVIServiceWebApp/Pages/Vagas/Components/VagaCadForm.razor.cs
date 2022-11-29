using CVIServiceLibShared.App.Request;
using CVIServiceWebDomain.Interfaces.IServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using System.Security.Claims;
using System.Threading.Channels;

namespace CVIServiceWebApp.Pages.Vagas.Components
{
    public partial class VagaCadForm
    {

        [Inject] private ISnackbar Snackbar { get; set; }   
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = default!;
        [Inject] private IVagaServices _vagaServices { get; set; } = default!;
        private VagaRequest VagaRequest { get; set; } = new VagaRequest();

        private async Task Registrar()
        {
            try
            {
                var result = _vagaServices.Add(VagaRequest);
                if (result is not null)
                {
                    MudDialog.Close(result);
                }
            }
            catch (Exception e )
            {
                Snackbar.Add("Falha ao gravar vaga" + e.Message, Severity.Error);
                throw;
            }
        }
    }
}
