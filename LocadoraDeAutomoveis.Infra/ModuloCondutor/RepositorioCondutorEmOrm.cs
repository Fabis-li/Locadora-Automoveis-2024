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

        public List<Condutor> Filtrar(Func<Condutor, bool> predicate)
        {
            return ObterRegistros().Where(predicate).ToList();
        }
    }
}
