using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraDeAutomoveis.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutomoveis.Infra.ModuloPlanoCobranca
{
    public class RepositorioPlanoCobrancaEmOrm : RepositorioBaseEmOrm<PlanoCobranca>, IRepositorioPlanoCobranca
    {
        public RepositorioPlanoCobrancaEmOrm(LocadoraDeAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<PlanoCobranca> ObterRegistros()
        {
            return dbContext.PlanosCobranca;
        }

        public List<PlanoCobranca> Filtrar(Func<PlanoCobranca, bool> predicate)
        {
            return ObterRegistros()
                .Where(predicate)
                .ToList();
        }

        public PlanoCobranca? FiltrarPlano(Func<PlanoCobranca, bool> predicate)
        {
            return ObterRegistros()
                .Include(p => p.GrupoAutomovel)
                .Where(predicate)
                .FirstOrDefault();
        }

        public override PlanoCobranca? SelecionarPorId(int id)
        {
            return ObterRegistros()
                .Include(p => p.GrupoAutomovel)
                .FirstOrDefault(p => p.Id == id);
        }

        public override List<PlanoCobranca> SelecionarTodos()
        {
            return ObterRegistros()
                .Include(p => p.GrupoAutomovel)
                .AsNoTracking()
                .ToList();
        }
    }
}
