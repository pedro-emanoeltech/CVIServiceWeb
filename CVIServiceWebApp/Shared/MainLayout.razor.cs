using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CVIServiceWebApp.Shared
{
    public partial class MainLayout : LayoutComponentBase
    {
        private MudTheme MyCustomTheme = new MudTheme()
        {
        };
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}
