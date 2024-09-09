using FluentResults;
using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraDeAutomoveis.Infra.ModuloAutomovel;

namespace LocadoraDeAutomovies.Aplicacao.Servicos
{
    public class AluguelService
    {
        private readonly IRepositorioAluguel repositorioAluguel;
        private readonly IRepositorioAutomovel repositorioAutomovel;
        private readonly IRepositorioPlanoCobranca repositorioPlanoCobranca;

        public AluguelService(IRepositorioAluguel repositorioAluguel, IRepositorioAutomovel repositorioAutomovel, IRepositorioPlanoCobranca repositorioPlanoCobranca)
        {
            this.repositorioAluguel = repositorioAluguel;
            this.repositorioAutomovel = repositorioAutomovel;
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
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

        public Result<List<Aluguel>> SelecionarTodos(int empresaId)
        {
            var alugueis = repositorioAluguel.Filtrar(a => a.EmpresaId == empresaId);

            return Result.Ok(alugueis);
        }

        public Result<Aluguel> Concluir(Aluguel aluguelDevolucao)
        {
            if(aluguelDevolucao.Status == StatusAluguelEnum.Concluido)
                return Result.Fail("Aluguel já foi concluído!");

            ConcluirDevolucao(aluguelDevolucao);

            repositorioAluguel.Editar(aluguelDevolucao);

            return Result.Ok(aluguelDevolucao);
        }

        public Result<Aluguel> Devolver(Aluguel aluguelAtualizado)
        {
            var aluguel = repositorioAluguel.SelecionarPorId(aluguelAtualizado.Id);

            if (aluguel is null)
                return Result.Fail("Aluguel não encontrado!");

            if (aluguelAtualizado.Status == StatusAluguelEnum.Concluido)
                return Result.Fail("Aluguel já foi devolvido!");


            aluguel.DataRetorno = aluguelAtualizado.DataRetorno;
            aluguel.KmRodado = aluguelAtualizado.KmRodado;
            aluguel.MarcadorCombustivel = aluguelAtualizado.MarcadorCombustivel;
            aluguel.Status = StatusAluguelEnum.Concluido;

            int planoId = (int)aluguel.TipoPlanoCobranca;

            var planoCobranca = repositorioPlanoCobranca.SelecionarPorId(planoId);

            if(planoCobranca is null)
                return Result.Fail("Plano de cobrança não encontrado!");

            var valorTotal = aluguel.CalcularValorTotal(planoCobranca);

            repositorioAluguel.Editar(aluguel);

            return Result.Ok(aluguel);
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
