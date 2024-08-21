using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using LocadoreDeAutomoveis.Infra.ModuloAutomovel;
using LocadoreDeAutomoveis.Infra.ModuloGrpAutomoveis;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoreDeAutomoveis.Infra.Compartilhado
{
    public class LocadoraDeAutomoveisDbContext : IdentityDbContext
    {
        public DbSet<GrpAutomoveis> GrpAutomoveis { get; set; }
        public DbSet<Automovel> Automoveis { get; set; }

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
            modelBuilder.ApplyConfiguration(new MapeadorGrpAutomoveisEmOrm());
            modelBuilder.ApplyConfiguration(new MapeadorAutomovelEmOrm());

            base.OnModelCreating(modelBuilder);
        }

    }
}
