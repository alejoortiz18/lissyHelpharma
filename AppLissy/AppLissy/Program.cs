using AppLissy.Common.Security;
using AppLissy.DependencyContainer;
using Business.Dependences;
using Microsoft.AspNetCore.Authentication.Cookies; // 🔥 IMPORTANTE
using Microsoft.EntityFrameworkCore;
using Models.Entities.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<CurrentUser>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OctopusConnection")));

builder.Services.DependencyInjection();
builder.Services.AddAutoMapper(cfg => { }, typeof(AutoMapperProfile).Assembly);

// 🔐 🔥 CONFIGURACIÓN DE AUTENTICACIÓN (ESTO FALTABA)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/InicioSesion";
        options.AccessDeniedPath = "/Auth/Denegado";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

// 🔐 ORDEN CORRECTO (MUY IMPORTANTE)
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=InicioSesion}/{id?}") // opcional pero recomendado
    .WithStaticAssets();

app.Run();
//dotnet ef dbcontext scaffold "Server=(localdb)\MSSQLLocalDB;Database=GestionPersonalDB;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Entities/Domain --context AppDbContext --force --project "C:\Users\alejandro.ortiz\Documents\helpharma\Desarrollos\lissy\lissyHelpharma\AppLissy\Models\Models\Models.csproj"