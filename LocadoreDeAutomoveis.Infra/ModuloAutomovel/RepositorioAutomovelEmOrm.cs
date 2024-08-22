using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoreDeAutomoveis.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoreDeAutomoveis.Infra.ModuloAutomovel
{
    public class RepositorioAutomovelEmOrm : RepositorioBaseEmOrm<Automovel>, IRepositorioAutomovel
    {
        public RepositorioAutomovelEmOrm(LocadoraDeAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Automovel> ObterRegistros()
        {
            return dbContext.Automoveis;
        }

        public List<Automovel> Filtrar(Func<Automovel, bool> predicate)
        {
            return ObterRegistros()
                .Where(predicate)
                .ToList();
        }
    }
}
