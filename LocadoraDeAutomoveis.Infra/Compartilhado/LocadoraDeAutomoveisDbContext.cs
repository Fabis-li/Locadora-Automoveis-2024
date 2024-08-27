using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraDeAutomoveis.Dominio.ModuloTaxa;
using LocadoraDeAutomoveis.Infra.ModuloAutomovel;
using LocadoraDeAutomoveis.Infra.ModuloGrupoAutomoveis;
using LocadoraDeAutomoveis.Infra.ModuloPlanoCobranca;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeAutomoveis.Infra.Compartilhado
{
    public class LocadoraDeAutomoveisDbContext : IdentityDbContext
    {
        public DbSet<GrupoAutomovel> GrupoAutomoveis { get; set; }
        public DbSet<Automovel> Automoveis { get; set; }
        public DbSet<PlanoCobranca> PlanosCobranca { get; set; }
        public DbSet<Taxa> Taxas { get; set; }


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
            modelBuilder.ApplyConfiguration(new MapeadorGrupoAutomovelEmOrm());
            modelBuilder.ApplyConfiguration(new MapeadorAutomovelEmOrm());
            modelBuilder.ApplyConfiguration(new MapeadorPlanoCobrancaEmOrm());
            modelBuilder.ApplyConfiguration(new MapeadorTaxaEmOrm());

            base.OnModelCreating(modelBuilder);
        }

    }
}
