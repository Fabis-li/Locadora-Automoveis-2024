using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeAutomoveis.Infra.ModuloPlanoCobranca
{
    public class MapeadorPlanoCobrancaEmOrm : IEntityTypeConfiguration<PlanoCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoCobranca> pBuilder)
        {
            pBuilder.ToTable("TBPlanoCobranca");

            pBuilder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            pBuilder.Property(p => p.PrecoDiarioPlanoDiario)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            pBuilder.Property(p => p.PrecoPorKmPlanoDiario)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            pBuilder.Property(p => p.KmDisponivelPlanoControlado)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            pBuilder.Property(p => p.PrecoDiarioPlanoControlado)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            pBuilder.Property(p => p.PrecoPorKmExcedido)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            pBuilder.Property(p => p.PrecoDiarioPlanoLivre)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            pBuilder.Property(p => p.GrupoAutomovelId)
                .IsRequired()
                .HasColumnType("int");

            pBuilder.HasOne(p => p.GrupoAutomovel)
                .WithMany()
                .HasForeignKey(p => p.GrupoAutomovelId)
                .OnDelete(DeleteBehavior.Restrict);

            pBuilder.Property(c => c.EmpresaId)
                .IsRequired()
                .HasColumnName("Empresa_Id")
                .HasColumnType("int");

            pBuilder.HasOne(g => g.Empresa)
                .WithMany()
                .HasForeignKey(g => g.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
    
}
