using CVIServiceLibShared.App.Request;
using CVIServiceWebDomain.Interfaces.IServices;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CVIServiceWebApp.Pages.Perfil.Components
{
    public partial class CVICardGeradorCurriculo
    {

        [Inject] private ISnackbar Snackbar { get; set; }   
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = default!;

        public string Modelo1 { get; set; } = "https://www.canalpedroemanuel.com/wp-content/uploads/2022/11/minicurriculo_rlbr_3.jpg";
        public string Modelo2 { get; set; } = "https://www.canalpedroemanuel.com/wp-content/uploads/2022/11/minicurriculo_zety_br_2.jpg";
        public string Modelo3 { get; set; } = "https://www.canalpedroemanuel.com/wp-content/uploads/2022/11/canva-rosa-enevoado-linhas-atendimento-ao-cliente-curriculo-M_R_jIingHw.jpg";


    }
}
