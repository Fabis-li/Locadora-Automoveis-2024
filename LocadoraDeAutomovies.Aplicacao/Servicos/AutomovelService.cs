using FluentResults;
using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using LocadoraDeAutomoveis.Infra.ModuloGrupoAutomoveis;

namespace LocadoraDeAutomovies.Aplicacao.Servicos
{
    public class AutomovelService
    {
        private readonly IRepositorioAutomovel repositorioAutomovel;
        private readonly IRepositorioGrupoAutomovel repositorioGrupoAutomovel;

        public AutomovelService(IRepositorioAutomovel repositorioAutomovel, IRepositorioGrupoAutomovel repositorioGrupoAutomovel)
        {
            this.repositorioAutomovel = repositorioAutomovel;
            this.repositorioGrupoAutomovel = repositorioGrupoAutomovel;
        }

        public Result<Automovel> Inserir(Automovel automovel)
        {
            repositorioAutomovel.Inserir(automovel);

            return Result.Ok(automovel);
        }

        public Result<Automovel> Editar(Automovel automovelAtualizado, int grupoAutomovelId)
        {
            var automovel = repositorioAutomovel.SelecionarPorId(automovelAtualizado.Id);

            if (automovel == null)
                return Result.Fail("Automóvel não foi encontrado!");

            var grupoAutomovelSelecionado = repositorioGrupoAutomovel.SelecionarPorId(grupoAutomovelId);

            automovel.Modelo = automovelAtualizado.Modelo;
            automovel.Marca = automovelAtualizado.Marca;
            automovel.Cor = automovelAtualizado.Cor;
            automovel.Placa = automovelAtualizado.Placa;
            automovel.TipoCombustivel = automovelAtualizado.TipoCombustivel;
            automovel.Ano = automovelAtualizado.Ano;
            automovel.CapacidadeCombustivel = automovelAtualizado.CapacidadeCombustivel;
            automovel.FotoVeiculo = automovelAtualizado.FotoVeiculo;
            automovel.GrupoAutomoveis = grupoAutomovelSelecionado;

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
