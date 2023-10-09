using System.Net;
using System.Security.Claims;
using lunchBlazor.Server.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RepositoryPattern.Services.AuthService;
using RepositoryPattern.Services.DepartemenService;
using RepositoryPattern.Services.DivisiService;
using RepositoryPattern.Services.GolonganService;
using RepositoryPattern.Services.JenisMppService;
using RepositoryPattern.Services.JenisPermintaanService;
using RepositoryPattern.Services.JurusanPendidikanService;
using RepositoryPattern.Services.LokasiService;
using RepositoryPattern.Services.MppChildFormService;
using RepositoryPattern.Services.MppFormService;
using RepositoryPattern.Services.PendidikanService;
using RepositoryPattern.Services.PosisiService;
using RepositoryPattern.Services.StatusService;
using RepositoryPattern.Services.SumberPemenuhanService;
using RepositoryPattern.Services.UserService;
using Sieve.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConn")));
builder.Services.AddSwaggerGen();
// builder.Services.AddSingleton<AppDbContext>();
builder.Services.AddScoped<ConvertJWT>();
builder.Services.AddSingleton<SieveProcessor>();
builder.Services.AddScoped<IDepartemenService, DepartemenService>();
builder.Services.AddScoped<IDivisiService, DivisiService>();
builder.Services.AddScoped<IGolonganService, GolonganService>();
builder.Services.AddScoped<IJenisMppService, JenisMppService>();
builder.Services.AddScoped<IJenisPermintaanService, JenisPermintaanService>();
builder.Services.AddScoped<ILokasiService, LokasiService>();
builder.Services.AddScoped<IPosisiService, PosisiService>();
builder.Services.AddScoped<ISumberPemenuhanService, SumberPemenuhanService>();
builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddScoped<IPendidikanService, PendidikanService>();
builder.Services.AddScoped<IJurusanPendidikanService, JurusanPendidikanService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMppFormService, MppFormService>();
builder.Services.AddScoped<IMppChildFormService, MppChildFormService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ClockSkew = TimeSpan.Zero,
        ValidateAudience = true,
        ValidAudience = "domain.com",
        ValidateIssuer = true,
        ValidIssuer = "domain.com",
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Mx0K7BAwAk+YXsKErRDtbTAeEpZEdHcSeKO15Snw/RaKd+Dnfb3XfX60F4AQHaG1")) // NOTE: THIS SHOULD BE A SECRET KEY NOT TO BE SHARED; A GUID IS RECOMMENDED
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ManPower", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


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
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

