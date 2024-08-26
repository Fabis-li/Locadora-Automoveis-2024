using System.Reflection;
using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using LocadoraDeAutomovies.Aplicacao.Servicos;
using LocadoreDeAutomoveis.Infra.Compartilhado;
using LocadoreDeAutomoveis.Infra.ModuloAutomovel;
using LocadoreDeAutomoveis.Infra.ModuloGrpAutomoveis;

namespace LocadoraDeAutomoveis.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<LocadoraDeAutomoveisDbContext>();

            builder.Services.AddScoped<IRepositorioGrpAutomoveis, RepositorioGrpAutomoveisEmOrm>();
            builder.Services.AddScoped<IRepositorioAutomovel, RepositorioAutomovelEmOrm>();

            builder.Services.AddScoped<GrpAutomoveisService>();
            builder.Services.AddScoped<AutomovelService>();

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(Assembly.GetExecutingAssembly());
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

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
        }
    }
}
