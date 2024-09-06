using FluentResults;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;

namespace LocadoraDeAutomovies.Aplicacao.Servicos
{
    public class PlanoCobrancaService
    {
        private readonly IRepositorioPlanoCobranca repositorioPlanoCobranca;

        public PlanoCobrancaService(IRepositorioPlanoCobranca repositorioPlanoCobranca)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
        }

        public Result<PlanoCobranca> Inserir(PlanoCobranca planoCobranca)
        {
            repositorioPlanoCobranca.Inserir(planoCobranca);

            return Result.Ok(planoCobranca);
        }

        public Result<PlanoCobranca> Editar(PlanoCobranca planoCobrancaAtualizado)
        {
            var planoCobranca = repositorioPlanoCobranca.SelecionarPorId(planoCobrancaAtualizado.Id);

            if (planoCobranca == null)
                return Result.Fail("Plano de cobrança não foi encontrado!");

            planoCobranca.GrupoAutomovelId = planoCobrancaAtualizado.GrupoAutomovelId;
            planoCobranca.PrecoDiarioPlanoDiario = planoCobrancaAtualizado.PrecoDiarioPlanoDiario;
            planoCobranca.PrecoPorKmPlanoDiario = planoCobrancaAtualizado.PrecoPorKmPlanoDiario;
            planoCobranca.PrecoDiarioPlanoControlado = planoCobrancaAtualizado.PrecoDiarioPlanoControlado;
            planoCobranca.KmDisponivelPlanoControlado = planoCobrancaAtualizado.KmDisponivelPlanoControlado;
            planoCobranca.PrecoPorKmExcedido = planoCobrancaAtualizado.PrecoPorKmExcedido;
            planoCobranca.PrecoDiarioPlanoLivre = planoCobrancaAtualizado.PrecoDiarioPlanoLivre;

            repositorioPlanoCobranca.Editar(planoCobranca);

            return Result.Ok(planoCobranca);
        }

        public Result<PlanoCobranca> Excluir(int planoCobrancaId)
        {
            var planoCobranca = repositorioPlanoCobranca.SelecionarPorId(planoCobrancaId);

            if (planoCobranca == null)
                return Result.Fail("Plano de cobrança não foi encontrado!");

            repositorioPlanoCobranca.Excluir(planoCobranca);

            return Result.Ok(planoCobranca);
        }

        public Result<PlanoCobranca> SelecionarPorId(int planoCobrancaId)
        {
            var planoCobranca = repositorioPlanoCobranca.SelecionarPorId(planoCobrancaId);

            if (planoCobranca is null)
                return Result.Fail("O plano de cobrança não foi encontrado!");

            return Result.Ok(planoCobranca);
        }

        public Result<List<PlanoCobranca>> SelecionarTodos()
        {
            var planosCobranca = repositorioPlanoCobranca.SelecionarTodos();

            return Result.Ok(planosCobranca);
        }

        public Result<PlanoCobranca> SelecionarPorIdGrupoAutomovel(int grupoAutomovelId)
        {
            var planoCobranca = repositorioPlanoCobranca.FiltrarPlano(p => p.GrupoAutomovelId == grupoAutomovelId);

            if (planoCobranca is null)
                return Result.Fail("O plano de cobrança não foi encontrado!");

            return Result.Ok(planoCobranca);
        }
    }
}
