using FluentResults;
using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraDeAutomoveis.Infra.ModuloAutomovel;

namespace LocadoraDeAutomovies.Aplicacao.Servicos
{
    public class AluguelService
    {
        private readonly IRepositorioAluguel repositorioAluguel;
        private readonly IRepositorioAutomovel repositorioAutomovel;

        public AluguelService(IRepositorioAluguel repositorioAluguel)
        {
            this.repositorioAluguel = repositorioAluguel;
        }

        public Result<Aluguel> Inserir(Aluguel aluguel)
        {
            var errosValidacao = aluguel.Validar();

            if (errosValidacao.Count > 0)
                return Result.Fail(errosValidacao);

            repositorioAluguel.Inserir(aluguel);

            return Result.Ok(aluguel);
        }

        public Result<Aluguel> Editar(Aluguel aluguelAtualizado)
        {
            var aluguel = repositorioAluguel.SelecionarPorId(aluguelAtualizado.Id);

            if(aluguel is null)
                return Result.Fail("Aluguel não encontrado!");

            var errosValidacao = aluguel.Validar();

            if (errosValidacao.Count > 0)
                return Result.Fail(errosValidacao);

            aluguel.CondutorId = aluguelAtualizado.CondutorId;
            aluguel.AutomovelId = aluguelAtualizado.AutomovelId;
            aluguel.DataSaida = aluguelAtualizado.DataSaida;
            aluguel.DataRetorno = aluguelAtualizado.DataRetorno;
            aluguel.ValorEntrada = aluguelAtualizado.ValorEntrada;
            aluguel.Status = aluguelAtualizado.Status;

            repositorioAluguel.Editar(aluguel);

            return Result.Ok(aluguel);
        }

        public Result<Aluguel> Excluir(int aluguelId)
        {
            var aluguel = repositorioAluguel.SelecionarPorId(aluguelId);

            if (aluguel is null)
                return Result.Fail("Aluguel não encontrado!");

            repositorioAluguel.Excluir(aluguel);

            return Result.Ok(aluguel);
        }

        public Result<Aluguel> SelecionarPorId(int aluguelId)
        {
            var aluguel = repositorioAluguel.SelecionarPorId(aluguelId);

            if (aluguel is null)
                return Result.Fail("Aluguel não encontrado!");

            return Result.Ok(aluguel);
        }

        public Result<List<Aluguel>> SelecionarTodos()
        {
            var alugueis = repositorioAluguel.SelecionarTodos();

            return Result.Ok(alugueis);
        }

        public Result<Aluguel> Concluir(Aluguel aluguelDevolucao)
        {
            if(aluguelDevolucao.DataRetorno is not null)
                return Result.Fail("Aluguel já foi concluído!");

            ConcluirDevolucao(aluguelDevolucao);

            repositorioAluguel.Editar(aluguelDevolucao);

            return Result.Ok(aluguelDevolucao);
        }

        private void ConcluirDevolucao(Aluguel aluguel)
        {
            var automovelSelecionado = repositorioAutomovel.SelecionarPorId(aluguel.Id);

            aluguel.Automovel = automovelSelecionado;

            aluguel.Devolucao();

            repositorioAutomovel.Editar(aluguel.Automovel!);
        }
    }
}
