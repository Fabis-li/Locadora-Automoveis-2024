using System.Reflection;
using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Dominio.ModuloConfiguracao;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraDeAutomoveis.Dominio.ModuloTaxa;
using LocadoraDeAutomovies.Aplicacao.Servicos;
using LocadoraDeAutomoveis.Infra.Compartilhado;
using LocadoraDeAutomoveis.Infra.ModuloAluguel;
using LocadoraDeAutomoveis.Infra.ModuloAutomovel;
using LocadoraDeAutomoveis.Infra.ModuloCliente;
using LocadoraDeAutomoveis.Infra.ModuloCondutor;
using LocadoraDeAutomoveis.Infra.ModuloConfiguracao;
using LocadoraDeAutomoveis.Infra.ModuloGrupoAutomoveis;
using LocadoraDeAutomoveis.Infra.ModuloPlanoCobranca;
using LocadoraDeAutomoveis.Infra.ModuloTaxa;
using LocadoraDeAutomoveis.WebApp.Mapping.Resolvers;

namespace LocadoraDeAutomoveis.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<LocadoraDeAutomoveisDbContext>();

            builder.Services.AddScoped<IRepositorioGrupoAutomovel, RepositorioGrupoAutomovelEmOrm>();
            builder.Services.AddScoped<IRepositorioAutomovel, RepositorioAutomovelEmOrm>();
            builder.Services.AddScoped<IRepositorioPlanoCobranca, RepositorioPlanoCobrancaEmOrm>();
            builder.Services.AddScoped<IRepositorioTaxa, RepositorioTaxaEmOrm>();
            builder.Services.AddScoped<IRepositorioCliente, RepositorioClienteEmOrm>();
            builder.Services.AddScoped<IRepositorioCondutor, RepositorioCondutorEmOrm>();
            builder.Services.AddScoped<IRepositorioConfiguracao, RepositorioConfiguracaoEmOrm>();
            builder.Services.AddScoped<IRepositorioAluguel, RepositorioAluguelEmOrm>();

            builder.Services.AddScoped<GrupoAutomoveisService>();
            builder.Services.AddScoped<AutomovelService>();
            builder.Services.AddScoped<PlanoCobrancaService>();
            builder.Services.AddScoped<TaxaService>();
            builder.Services.AddScoped<ClienteService>();
            builder.Services.AddScoped<CondutorService>();
            builder.Services.AddScoped<ConfiguracaoService>();

            builder.Services.AddScoped<GrupoAutomoveisResolver>();

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
