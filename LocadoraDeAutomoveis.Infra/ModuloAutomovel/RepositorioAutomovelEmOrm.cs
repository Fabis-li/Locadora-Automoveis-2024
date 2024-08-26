using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraDeAutomoveis.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutomoveis.Infra.ModuloAutomovel
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

        public override Automovel? SelecionarPorId(int id)
        {
            return ObterRegistros()
                .Include(a => a.GrupoAutomoveis)
                .FirstOrDefault(a => a.Id == id);
        }

        public override List<Automovel> SelecionarTodos()
        {
            return ObterRegistros()
                .Include(a => a.GrupoAutomoveis)
                .ToList();
        }

        public List<Automovel> Filtrar(Func<Automovel, bool> predicate)
        {
            return ObterRegistros()
                .Where(predicate)
                .ToList();
        }
    }
}
