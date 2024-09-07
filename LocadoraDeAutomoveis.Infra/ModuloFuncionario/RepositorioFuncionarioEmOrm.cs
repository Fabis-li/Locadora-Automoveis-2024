using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using LocadoraDeAutomoveis.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutomoveis.Infra.ModuloFuncionario
{
    public class RepositorioFuncionarioEmOrm : RepositorioBaseEmOrm<Funcionario>, IRepositorioFuncionario
    {
        public RepositorioFuncionarioEmOrm(LocadoraDeAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Funcionario> ObterRegistros()
        {
            return dbContext.Funcionarios;
        }


        public override Funcionario? SelecionarPorId(int id)
        {
            return dbContext.Funcionarios
                .Include(f => f.Empresa)
                .FirstOrDefault(f => f.Id == id);
        }

        public List<Funcionario> SelecionarTodos(Func<Funcionario, bool> predicate)
        {
            return dbContext.Funcionarios
                .Include(f => f.Empresa)
                .Where(predicate)
                .ToList();
        }
    }
}
