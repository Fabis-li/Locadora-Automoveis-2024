using LocadoraDeAutomoveis.Dominio.ModuloConfiguracao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeAutomoveis.Infra.ModuloConfiguracao
{
    public class MapeadorConfiguracaoEmOrm : IEntityTypeConfiguration<Configuracao>
    {
        public void Configure(EntityTypeBuilder<Configuracao> cBuilder)
        {
            cBuilder.ToTable("TBConfiguracao");

            cBuilder.Property(c => c.Id)
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd();

            cBuilder.Property(c => c.PrecoGasolina)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            cBuilder.Property(c => c.PrecoAlcool)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            cBuilder.Property(c => c.PrecoDiesel)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            cBuilder.Property(c => c.PrecoGas)
                .IsRequired()
                .HasColumnType("decimal(18,2)");


        }
    }
}
