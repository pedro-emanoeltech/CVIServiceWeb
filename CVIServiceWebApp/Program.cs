using Blazored.SessionStorage;
using CVIServiceWeb.Settings;
using CVIServiceWebApp;
using CVIServiceWebApp.Pages.Login;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddMudServices();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredSessionStorage();




await builder.Build().RunAsync();
