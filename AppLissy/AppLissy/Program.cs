using AppLissy.DependencyContainer;
using Microsoft.EntityFrameworkCore;
using Models.Entities.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OctopusConnection")));

builder.Services.DependencyInjection();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
//dotnet ef dbcontext scaffold "Server=(localdb)\MSSQLLocalDB;Database=GestionPersonalDB;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Entities/Domain --context AppDbContext --force --project "C:\Users\alejandro.ortiz\Documents\helpharma\Desarrollos\lissy\lissyHelpharma\AppLissy\Models\Models\Models.csproj"