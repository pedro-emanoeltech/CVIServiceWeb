using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CVIServiceWebApp.Components
{
    public partial class ContaDialogTermos
    {
        [CascadingParameter] MudDialogInstance? MudDialog { get; set; }
        [Parameter] public string? Termos { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        private void Ok()
        {
            MudDialog!.Close(DialogResult.Ok(true));
        }
    }
}
