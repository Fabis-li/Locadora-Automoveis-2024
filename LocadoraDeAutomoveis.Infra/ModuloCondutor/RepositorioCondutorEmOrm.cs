using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutomoveis.Infra.ModuloCondutor
{
    public class RepositorioCondutorEmOrm : RepositorioBaseEmOrm<Condutor>, IRepositorioCondutor
    {
        public RepositorioCondutorEmOrm(LocadoraDeAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Condutor> ObterRegistros()
        {
            return dbContext.Condutores;
        }

        public override Condutor? SelecionarPorId(int id)
        {
            return ObterRegistros()
                .Include(c => c.Cliente)
                .FirstOrDefault(c => c.Id == id);
        }

        public override List<Condutor> SelecionarTodos()
        {
            return ObterRegistros()
                .Include(c => c.Cliente)
                .ToList();
        }

        public List<Condutor> Filtrar(Func<Condutor, bool> predicate)
        {
            return ObterRegistros().Where(predicate).ToList();
        }
    }
}
