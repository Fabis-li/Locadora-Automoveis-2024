using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoreDeAutomoveis.Infra.Compartilhado
{
    public class LocadoraDeAutomoveisDbContext : IdentityDbContext
    {
        public DbSet<GrpAutomoveis> GrpAutomoveis { get; set; }

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
            modelBuilder.Entity<GrpAutomoveis>().ToTable("GrpAutomoveis");
            modelBuilder.Entity<GrpAutomoveis>().HasKey(x => x.Id);
            modelBuilder.Entity<GrpAutomoveis>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<GrpAutomoveis>().Property(x => x.Nome).HasMaxLength(100).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
