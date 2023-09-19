using Blazored.Modal;
using CurrieTechnologies.Razor.SweetAlert2;
using lunchBlazor.Client;
using lunchBlazor.Client.Services.DepartemenService;
using lunchBlazor.Client.Services.DivisiService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<DepartemenService>();
builder.Services.AddScoped<DivisiService>();

builder.Services.AddSweetAlert2();
builder.Services.AddBlazoredModal();

await builder.Build().RunAsync();
