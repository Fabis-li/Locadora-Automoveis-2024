using LocadoraDeAutomoveis.Dominio.ModuloTaxa;
using LocadoraDeAutomoveis.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutomoveis.Infra.ModuloTaxa
{
    public class RepositorioTaxaEmOrm : RepositorioBaseEmOrm<Taxa>, IRepositorioTaxa
    {
        public RepositorioTaxaEmOrm(LocadoraDeAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Taxa> ObterRegistros()
        {
            return dbContext.Taxas;    
        }

        public List<Taxa> Filtrar(Func<Taxa, bool> predicate)
        {
            return ObterRegistros().Where(predicate).ToList();
        }
    }
}
