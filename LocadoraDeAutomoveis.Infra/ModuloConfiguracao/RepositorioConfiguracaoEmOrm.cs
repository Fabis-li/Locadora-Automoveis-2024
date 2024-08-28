using LocadoraDeAutomoveis.Dominio.ModuloConfiguracao;
using LocadoraDeAutomoveis.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutomoveis.Infra.ModuloConfiguracao
{
    public class RepositorioConfiguracaoEmOrm : RepositorioBaseEmOrm<Configuracao>, IRepositorioConfiguracao
    {
        public RepositorioConfiguracaoEmOrm(LocadoraDeAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Configuracao> ObterRegistros()
        {
            return dbContext.Configuracoes;
        }

        public List<Configuracao> Filtrar(Func<Configuracao, bool> predicate)
        {
            return ObterRegistros().Where(predicate).ToList();
        }
    }
}
