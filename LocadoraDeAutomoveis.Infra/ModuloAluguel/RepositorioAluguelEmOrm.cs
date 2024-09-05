using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutomoveis.Infra.ModuloAluguel
{
    public class RepositorioAluguelEmOrm : RepositorioBaseEmOrm<Aluguel>, IRepositorioAluguel
    {
        public RepositorioAluguelEmOrm(LocadoraDeAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Aluguel> ObterRegistros()
        {
            return dbContext.Alugueis;
        }

        public List<Aluguel> Filtrar(Func<Aluguel, bool> predicate)
        {
            return ObterRegistros().Where(predicate).ToList();
        }

        public override Aluguel? SelecionarPorId(int id)
        {
            return ObterRegistros()
                .Include(a => a.Condutor)
                .Include(a => a.Automovel)
                .FirstOrDefault(a => a.Id == id);
        }

        public override List<Aluguel> SelecionarTodos()
        {
            return ObterRegistros()
                .Include(a => a.Condutor)
                .Include(a => a.Automovel)
                .ToList();
        }
    }
}
