using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutomoveis.Infra.ModuloCliente
{
    public class RepositorioClienteEmOrm : RepositorioBaseEmOrm<Cliente>, IRepositorioCliente
    {
        public RepositorioClienteEmOrm(LocadoraDeAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Cliente> ObterRegistros()
        {
            return dbContext.Clientes;
        }

        public List<Cliente> Filtrar(Func<Cliente, bool> predicate)
        {
            return ObterRegistros().Where(predicate).ToList();
        }
    }
}
