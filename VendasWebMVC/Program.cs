using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Localization;
using VendasWebMVC.Data;
using VendasWebMVC.Services;
 

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<VendasWebMVCContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VendasWebMVCContext") ?? throw new InvalidOperationException("Connection string 'VendasWebMVCContext' not found."),
    builder => builder.MigrationsAssembly("VendasWebMVC")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<VendedorService>();
builder.Services.AddScoped<DepartamentoService>();
builder.Services.AddScoped<CategoriaProdutoService>();

var app = builder.Build();

var ptBR = new CultureInfo("pt-BR");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(ptBR),
    SupportedCultures = new List<CultureInfo> { ptBR },
    SupportedUICultures = new List<CultureInfo> { ptBR }
};

app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
