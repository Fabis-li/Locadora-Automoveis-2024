using System.Reflection;
using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.Dominio.ModuloAutenticacao;
using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Dominio.ModuloConfiguracao;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
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
using LocadoraDeAutomoveis.Infra.ModuloFuncionario;
using LocadoraDeAutomoveis.Infra.ModuloGrupoAutomoveis;
using LocadoraDeAutomoveis.Infra.ModuloPlanoCobranca;
using LocadoraDeAutomoveis.Infra.ModuloTaxa;
using LocadoraDeAutomoveis.WebApp.Mapping.Resolvers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

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
            builder.Services.AddScoped<IRepositorioFuncionario, RepositorioFuncionarioEmOrm>();

            builder.Services.AddScoped<GrupoAutomoveisService>();
            builder.Services.AddScoped<AutomovelService>();
            builder.Services.AddScoped<PlanoCobrancaService>();
            builder.Services.AddScoped<TaxaService>();
            builder.Services.AddScoped<ClienteService>();
            builder.Services.AddScoped<CondutorService>();
            builder.Services.AddScoped<ConfiguracaoService>();
            builder.Services.AddScoped<AluguelService>();
            builder.Services.AddScoped<FuncionarioService>();

            builder.Services.AddScoped<GrupoAutomoveisResolver>();
            builder.Services.AddScoped<AutomovelValueResolver>();
            builder.Services.AddScoped<FotoValueRevolver>();
            builder.Services.AddScoped<CondutoresValueResolver>();
            builder.Services.AddScoped<TaxaEscolhidaValueResolver>();
            builder.Services.AddScoped<TaxasValueResolver>();
            builder.Services.AddScoped<ValorTotalValueResolver>();
            builder.Services.AddScoped<EmpresaIdValueResolver>();

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(Assembly.GetExecutingAssembly());
            });

            //Add services autenticação
            builder.Services.AddScoped<AutenticacaoService>();

            builder.Services.AddIdentity<Usuario, Perfil>()
                .AddEntityFrameworkStores<LocadoraDeAutomoveisDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 1;
            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "AspNetCore.Cookie";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                    options.SlidingExpiration = true;
                });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Autenticacao/Login";
                options.AccessDeniedPath = "/Autenticacao/AcessoNegado";
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
