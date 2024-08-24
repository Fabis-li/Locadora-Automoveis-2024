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

        public override PlanoCobranca SelecionarPorId(int id)
        {
            return ObterRegistros()
                .FirstOrDefault(p => p.Id == id)!;
        }

        public PlanoControlado ObterPlanoControladoPorId(int id)
        {
            return ObterRegistros()
                .OfType<PlanoControlado>()
                .FirstOrDefault(p => p.Id == id)!;
        }

        public PlanoDiario ObterPlanoDiarioPorId(int id)
        {
            return ObterRegistros()
                .OfType<PlanoDiario>()
                .FirstOrDefault(p => p.Id == id)!;
        }

        public PlanoLivre ObterPlanoLivrePorId(int id)
        {
            return ObterRegistros()
                .OfType<PlanoLivre>()
                .FirstOrDefault(p => p.Id == id)!;
        }
    }
}
