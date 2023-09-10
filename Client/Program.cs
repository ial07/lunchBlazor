using CurrieTechnologies.Razor.SweetAlert2;
using lunchBlazor.Client;
using lunchBlazor.Client.Services.BannerService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<BannerService>();

builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
