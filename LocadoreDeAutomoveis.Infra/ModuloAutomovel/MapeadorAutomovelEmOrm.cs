using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoreDeAutomoveis.Infra.ModuloAutomovel
{
    public class MapeadorAutomovelEmOrm : IEntityTypeConfiguration<Automovel>
    {
        public void Configure(EntityTypeBuilder<Automovel> aBuilder)
        {
            aBuilder.ToTable("TBAutomovel");

            aBuilder.Property(a => a.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
        }
    }
}
