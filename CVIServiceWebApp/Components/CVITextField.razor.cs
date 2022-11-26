using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CVIServiceWebApp.Components
{
    public partial class CVITextField<T> :MudTextField<T> 
    {
        [Parameter] public int LimiteCaracter { get; set; } = 10000;
        [Parameter] public string TextoAjuda { get; set; } = "";
        protected override void OnInitialized()
        {
              Counter = LimiteCaracter;
              HelperText = TextoAjuda;
              Immediate = true;
              Validation = (new Func<string, IEnumerable<string>>(MaxCharacters));
              Variant = Variant.Text;
                base.OnInitialized();
        }
        private IEnumerable<string> MaxCharacters(string ch)
        {
            if (!string.IsNullOrEmpty(ch) && LimiteCaracter < ch?.Length)
                yield return $"limite de caracter atigindo:{LimiteCaracter}";
        }
    }
}
