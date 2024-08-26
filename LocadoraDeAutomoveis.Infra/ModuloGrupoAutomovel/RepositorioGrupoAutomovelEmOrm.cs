using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using LocadoraDeAutomoveis.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutomoveis.Infra.ModuloGrupoAutomoveis
{
    public class RepositorioGrupoAutomovelEmOrm : RepositorioBaseEmOrm<GrupoAutomovel>, IRepositorioGrupoAutomovel
    {
        public RepositorioGrupoAutomovelEmOrm(LocadoraDeAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<GrupoAutomovel> ObterRegistros()
        {
            return dbContext.GrupoAutomoveis;
        }

        public List<GrupoAutomovel> Filtrar(Func<GrupoAutomovel, bool> predicate)
        {
            return ObterRegistros()
                .Where(predicate)
                .ToList();
        }
    }
}
