using CVIServiceLibShared.App.Request;
using CVIServiceLibShared.App.Response;
using CVIServiceLibShared.Constants.Enums;
using CVIServiceWebApp.Components;
using CVIServiceWebApp.Pages.Vagas.Components;
using CVIServiceWebDomain.Interfaces.IServices;
using CVIServiceWebDomain.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using System;
using System.Security.Claims;
using static System.Collections.Specialized.BitVector32;

namespace CVIServiceWebApp.Pages.Vagas
{
    public partial class Vagas : Container 
    {
 
        private static HttpClient _httpClient = new HttpClient();
        [Inject] private IDialogService Dialog { get; set; }
        [Inject] private IVagaServices _vagaServices { get; set; } = default!;
        public List<VagaResponse> Enitties { get; set; } = new List<VagaResponse>();
        public string filtro { get; set; }
        public ModalidadeTrabalho _modalidadeTrabalho { get; set; } = ModalidadeTrabalho.Presencial;
        public DateTime? date { get; set; }
       



        public bool Loading { get; set; } = false;

        protected override void OnInitialized()
        {
            CorpoContainer = RenderCorpoContainer();
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {

            await BuscarVaga();
            await base.OnInitializedAsync();

        }

        public async Task OpenDialogVagaCad()
        {

          
            DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Small };
       
            Dialog.Show<VagaCadForm>("Cadastro Vaga", maxWidth);
           await BuscarVaga();

        }
        public async Task BuscarVaga()
        {
            try
            {
                Loading = true;
                var result = await _vagaServices.GetList();
                if ((result is not null) && (result.Count() > 0))
                {
                    Enitties = result.ToList();
                }
                Loading = false;
            }
            catch (System.Exception e)
            {
                Loading = false;
                Console.WriteLine(e.Message);
                Snackbar.Add(e.Message);
                throw;
            }
        }

    }
}
