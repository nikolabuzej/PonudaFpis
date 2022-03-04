using InfrastructureFE;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PonudaBlazor;
using ViewModels;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.Scan(s => s.FromAssemblyOf<ProizvodService>()
.AddClasses()
.AsImplementedInterfaces()
.WithScopedLifetime());

builder.Services.Scan(s => s.FromAssemblyOf<BaseViewModel>()
.AddClasses()
.AsSelf()
.WithScopedLifetime());


await builder.Build().RunAsync();
