using FluentResults;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;

namespace LocadoraDeAutomovies.Aplicacao.Servicos
{
    public class CondutorService
    {
        private readonly IRepositorioCondutor repositorioCondutor;

        public CondutorService(IRepositorioCondutor repositorioCondutor)
        {
            this.repositorioCondutor = repositorioCondutor;
        }

        public Result<Condutor> Inserir(Condutor condutor)
        {
            repositorioCondutor.Inserir(condutor);

            return Result.Ok(condutor);
        }

        public Result<Condutor> Editar(Condutor condutoratualizado)
        {
            var condutor = repositorioCondutor.SelecionarPorId(condutoratualizado.Id);

            if (condutor is null)
                return Result.Fail("O condutor não foi encontrado!");

            condutor.ClienteId = condutoratualizado.ClienteId;
            condutor.Nome = condutoratualizado.Nome;
            condutor.Email = condutoratualizado.Email;
            condutor.Cpf = condutoratualizado.Cpf;
            condutor.Cnh = condutoratualizado.Cnh;
            condutor.ValidadeCnh = condutoratualizado.ValidadeCnh;
            condutor.Telefone = condutoratualizado.Telefone;
            condutor.Cliente = condutoratualizado.Cliente;
            condutor.ClienteCondutor = condutoratualizado.ClienteCondutor;

            repositorioCondutor.Editar(condutor);

            return Result.Ok(condutor);
        }

        public Result<Condutor> Excluir(int condutorid)
        {
            var condutor = repositorioCondutor.SelecionarPorId(condutorid);

            if (condutor is null)
                return Result.Fail("O condutor não foi encontrado!");

            repositorioCondutor.Excluir(condutor);

            return Result.Ok(condutor);
        }

        public Result<Condutor> SelecionarPorId(int condutorId)
        {
            var condutor = repositorioCondutor.SelecionarPorId(condutorId);

            if (condutor is null)
                return Result.Fail("O condutor não foi encontrado!");

            return Result.Ok(condutor);
        }

        public Result<List<Condutor>> SelecionarTodos()
        {
            var condutores = repositorioCondutor.SelecionarTodos();

            return Result.Ok(condutores);
        }
    }
}
