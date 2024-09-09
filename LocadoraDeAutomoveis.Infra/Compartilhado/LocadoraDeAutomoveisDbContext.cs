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
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeAutomoveis.Infra.Compartilhado
{
    public class LocadoraDeAutomoveisDbContext : IdentityDbContext<Usuario, Perfil, int>
    {
        public DbSet<GrupoAutomovel> GrupoAutomoveis { get; set; }
        public DbSet<Automovel> Automoveis { get; set; }
        public DbSet<PlanoCobranca> PlanosCobranca { get; set; }
        public DbSet<Taxa> Taxas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Condutor> Condutores { get; set; }
        public DbSet<Configuracao> Configuracoes { get; set; }
        public DbSet<Aluguel> Alugueis { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config
                .GetConnectionString("SqlServer");

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(LocadoraDeAutomoveisDbContext).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            
            base.OnModelCreating(modelBuilder);
        }

    }
}
