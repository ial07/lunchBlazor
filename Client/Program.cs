using Blazored.Modal;
using CurrieTechnologies.Razor.SweetAlert2;
using lunchBlazor.Client;
using lunchBlazor.Client.Services.DepartemenService;
using lunchBlazor.Client.Services.DivisiService;
using lunchBlazor.Client.Services.GolonganService;
using lunchBlazor.Client.Services.LokasiService;
using lunchBlazor.Client.Services.PosisiService;
using lunchBlazor.Client.Services.StatusService;
using lunchBlazor.Client.Services.JenisMppService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using lunchBlazor.Client.Services.JenisPermintaanService;
using lunchBlazor.Client.Services.PendidikanService;
using lunchBlazor.Client.Services.JurusanPendidikanService;
using lunchBlazor.Client.Services.SumberPemenuhanService;
using Syncfusion.Blazor;
using lunchBlazor.Client.Services.MppChildFormService;
using lunchBlazor.Client.Services.MppFormService;
using Blazored.LocalStorage;
using lunchBlazor.Client.Services.AuthService;
using lunchBlazor.Client.helper;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<DepartemenService>();
builder.Services.AddScoped<DivisiService>();
builder.Services.AddScoped<PosisiService>();
builder.Services.AddScoped<GolonganService>();
builder.Services.AddScoped<LokasiService>();
builder.Services.AddScoped<StatusService>();
builder.Services.AddScoped<JenisMppService>();
builder.Services.AddScoped<JenisPermintaanService>();
builder.Services.AddScoped<PendidikanService>();
builder.Services.AddScoped<JurusanPendidikanService>();
builder.Services.AddScoped<SumberPemenuhanService>();
builder.Services.AddScoped<MppChildFormService>();
builder.Services.AddScoped<MppFormService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<AppState>();


builder.Services.AddSweetAlert2();
builder.Services.AddBlazoredModal();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
