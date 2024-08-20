using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using LocadoreDeAutomoveis.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoreDeAutomoveis.Infra.ModuloGrpAutomoveis
{
    public class RepositorioGrpAutomoveisEmOrm : RepositorioBaseEmOrm<GrpAutomoveis>, IRepositorioGrpAutomoveis
    {
        public RepositorioGrpAutomoveisEmOrm(LocadoraDeAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<GrpAutomoveis> ObterRegistros()
        {
            return dbContext.GrpAutomoveis;
        }
      
    }
}
