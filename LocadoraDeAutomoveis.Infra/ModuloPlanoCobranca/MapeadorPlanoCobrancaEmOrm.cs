using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeAutomoveis.Infra.ModuloPlanoCobranca
{
    public class MapeadorPlanoCobrancaEmOrm : IEntityTypeConfiguration<PlanoCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoCobranca> pBuilder)
        {
            pBuilder.ToTable("PlanoCobranca");

            pBuilder.Property(p => p.Id)
                .IsRequired()
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            pBuilder.Property(p => p.PrecoDiarioPlanoDiario)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            pBuilder.Property(p => p.PrecoPorKmPlanoDiario)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            pBuilder.Property(p => p.KmDisponivelPlanoControlado)
                .IsRequired()
                .HasColumnType("decimal(18,2");

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
        }

    }
    
}
