using FluentResults;
using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;

namespace LocadoraDeAutomovies.Aplicacao.Servicos
{
    public class AutomovelService
    {
        private readonly IRepositorioAutomovel repositorioAutomovel;

        public AutomovelService(IRepositorioAutomovel repositorioAutomovel)
        {
            this.repositorioAutomovel = repositorioAutomovel;
        }

        public Result<Automovel> Inserir(Automovel automovel)
        {
            repositorioAutomovel.Inserir(automovel);

            return Result.Ok(automovel);
        }

        public Result<Automovel> Editar(Automovel automovelAtualizado)
        {
            var automovel = repositorioAutomovel.SelecionarPorId(automovelAtualizado.Id);

            if (automovel == null)
                return Result.Fail("Automóvel não foi encontrado!");

            automovel.Modelo = automovelAtualizado.Modelo;
            automovel.Marca = automovelAtualizado.Marca;
            automovel.Cor = automovelAtualizado.Cor;
            automovel.Placa = automovelAtualizado.Placa;
            automovel.Combustivel = automovelAtualizado.Combustivel;
            automovel.Ano = automovelAtualizado.Ano;
            automovel.CapacidadeCombustivel = automovelAtualizado.CapacidadeCombustivel;
            automovel.FotoVeiculo = automovelAtualizado.FotoVeiculo;
            automovel.GrupoAutomoveis = automovelAtualizado.GrupoAutomoveis;

            repositorioAutomovel.Editar(automovel);

            return Result.Ok(automovel);
        }

        public Result<Automovel> Excluir(int automovelId)
        {
            var automovel = repositorioAutomovel.SelecionarPorId(automovelId);

            if (automovel == null)
                return Result.Fail("Automóvel não foi encontrado!");

            repositorioAutomovel.Excluir(automovel);

            return Result.Ok(automovel);
        }

        public Result<Automovel> SelecionarPorId(int automovelId)
        {
            var automovel = repositorioAutomovel.SelecionarPorId(automovelId);

            if (automovel == null)
                return Result.Fail("Automóvel não foi encontrado!");

            return Result.Ok(automovel);
        }

        public Result<List<Automovel>> SelecionarTodos()
        {
            var automoveis = repositorioAutomovel.SelecionarTodos();

            return Result.Ok(automoveis);
        }
    }
}
