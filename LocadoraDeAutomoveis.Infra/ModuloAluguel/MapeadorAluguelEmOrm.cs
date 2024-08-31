using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeAutomoveis.Infra.ModuloAluguel
{
    public class MapeadorAluguelEmOrm : IEntityTypeConfiguration<Aluguel>
    {
        public void Configure(EntityTypeBuilder<Aluguel> aBuilder)
        {
            aBuilder.ToTable("TBAluguel");

            aBuilder.Property(a => a.Id)
                .IsRequired()
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            aBuilder.Property(a => a.CondutorId)
                .IsRequired()
                .HasColumnType("int");

            aBuilder.Property(a => a.AutomovelId)
                .IsRequired()
                .HasColumnType("int");

            aBuilder.Property(a => a.PlanoCobrancaId)
                .IsRequired()
                .HasColumnType("int");

            aBuilder.Property(a => a.DataSaida)
                .IsRequired()
                .HasColumnType("datetime2");

            aBuilder.Property(a => a.DataRetorno)
                .IsRequired()
                .HasColumnType("datetime2");

            aBuilder.Property(a => a.ValorEntrada)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            aBuilder.Property(a => a.Status)
                .IsRequired()
                .HasColumnType("int");

            aBuilder.HasOne(a => a.Condutor)
                .WithMany()
                .HasForeignKey(a => a.CondutorId)
                .OnDelete(DeleteBehavior.Restrict);

            aBuilder.HasOne(a => a.Automovel)
                .WithMany()
                .HasForeignKey(a => a.AutomovelId)
                .OnDelete(DeleteBehavior.Restrict);

            aBuilder.HasOne(a => a.PlanoCobranca)
                .WithMany()
                .HasForeignKey(a => a.PlanoCobrancaId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
