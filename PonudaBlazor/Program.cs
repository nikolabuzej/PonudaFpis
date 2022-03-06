using InfrastructureFE;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PonudaBlazor;
using ViewModels;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.Scan(s => s.FromAssemblyOf<ProizvodService>()
.AddClasses()
.AsImplementedInterfaces()
.WithTransientLifetime());

builder.Services.Scan(s => s.FromAssemblyOf<BaseViewModel>()
.AddClasses()
.AsSelf()
.WithTransientLifetime());


await builder.Build().RunAsync();
