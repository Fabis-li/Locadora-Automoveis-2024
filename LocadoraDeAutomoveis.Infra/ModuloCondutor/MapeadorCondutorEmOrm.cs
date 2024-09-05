using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeAutomoveis.Infra.ModuloCondutor
{
    public class MapeadorCondutorEmOrm : IEntityTypeConfiguration<Condutor>
    {
        public void Configure(EntityTypeBuilder<Condutor> cBuilder)
        {
            cBuilder.ToTable("TBCondutor");

            cBuilder.Property(c => c.Id)
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd();

            cBuilder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            cBuilder.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");

            cBuilder.Property(c => c.Cpf)
                .IsRequired()
                .HasColumnType("varchar(11)");

            cBuilder.Property(c => c.Cnh)
                .IsRequired()
                .HasColumnType("varchar(11)");

            cBuilder.Property(c => c.ValidaCnh)
                .IsRequired()
                .HasColumnType("datetime");

            cBuilder.Property(c => c.Telefone)
                .IsRequired()
                .HasColumnType("varchar(20)");

            cBuilder.Property(c => c.ClienteCondutor)
                .IsRequired()
                .HasColumnType("bit");

            cBuilder.Property(c => c.ClienteId)
                .IsRequired()
                .HasColumnType("int");

            cBuilder.HasOne(c => c.Cliente)
                .WithMany(c => c.Condutores)
                .HasForeignKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
