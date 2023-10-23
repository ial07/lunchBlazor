using Blazored.Modal;
using CurrieTechnologies.Razor.SweetAlert2;
using man_power_planning.Client;
using man_power_planning.Client.Services.DepartemenService;
using man_power_planning.Client.Services.DivisiService;
using man_power_planning.Client.Services.GolonganService;
using man_power_planning.Client.Services.LokasiService;
using man_power_planning.Client.Services.PosisiService;
using man_power_planning.Client.Services.StatusService;
using man_power_planning.Client.Services.JenisMppService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using man_power_planning.Client.Services.JenisPermintaanService;
using man_power_planning.Client.Services.PendidikanService;
using man_power_planning.Client.Services.JurusanPendidikanService;
using man_power_planning.Client.Services.SumberPemenuhanService;
using Syncfusion.Blazor;
using man_power_planning.Client.Services.MppChildFormService;
using man_power_planning.Client.Services.MppFormService;
using Blazored.LocalStorage;
using man_power_planning.Client.Services.AuthService;
using man_power_planning.Client.helper;

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
builder.Services.AddScoped<GlobalService>();


builder.Services.AddSweetAlert2();
builder.Services.AddBlazoredModal();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
