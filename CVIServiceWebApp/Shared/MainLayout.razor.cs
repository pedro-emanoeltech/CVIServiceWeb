using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CVIServiceWebApp.Shared
{
    public partial class MainLayout : LayoutComponentBase
    {
        [Inject] private NavigationManager NavigationManager { get; set; } = default!;
        private MudTheme MyCustomTheme = new MudTheme()
        {
        };

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}
