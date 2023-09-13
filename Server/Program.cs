using lunchBlazor.Server.Data;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Services.DepartemenService;
using RepositoryPattern.Services.DevisiService;
using RepositoryPattern.Services.GolonganService;
using RepositoryPattern.Services.JenisMppService;
using RepositoryPattern.Services.JenisPermintaanService;
using RepositoryPattern.Services.LokasiService;
using RepositoryPattern.Services.MppChildFormService;
using RepositoryPattern.Services.MppFormService;
using RepositoryPattern.Services.PosisiService;
using RepositoryPattern.Services.SumberPemenuhanService;
using Sieve.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConn")));
builder.Services.AddSwaggerGen();
// builder.Services.AddSingleton<AppDbContext>();
builder.Services.AddSingleton<SieveProcessor>();
builder.Services.AddScoped<IDepartemenService, DepartemenService>();
builder.Services.AddScoped<IDevisiService, DevisiService>();
builder.Services.AddScoped<IGolonganService, GolonganService>();
builder.Services.AddScoped<IJenisMppService, JenisMppService>();
builder.Services.AddScoped<IJenisPermintaanService, JenisPermintaanService>();
builder.Services.AddScoped<ILokasiService, LokasiService>();
builder.Services.AddScoped<IPosisiService, PosisiService>();
builder.Services.AddScoped<ISumberPemenuhanService, SumberPemenuhanService>();

builder.Services.AddScoped<IMppFormService, MppFormService>();
builder.Services.AddScoped<IMppChildFormService, MppChildFormService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blazor API V1");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
