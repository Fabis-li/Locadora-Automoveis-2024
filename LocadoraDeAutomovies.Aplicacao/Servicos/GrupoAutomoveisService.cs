using FluentResults;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;

namespace LocadoraDeAutomovies.Aplicacao.Servicos
{
    public class GrupoAutomoveisService
    {
        private readonly IRepositorioGrupoAutomovel repositorioGrpAutomoveis;

        public GrupoAutomoveisService(IRepositorioGrupoAutomovel repositorioGrpAutomoveis)
        {
            this.repositorioGrpAutomoveis = repositorioGrpAutomoveis;
        }

        public Result<GrupoAutomovel> Inserir(GrupoAutomovel grpAutomoveis)
        {
            repositorioGrpAutomoveis.Inserir(grpAutomoveis);

            return Result.Ok(grpAutomoveis);
        }

        public Result<GrupoAutomovel> Editar(GrupoAutomovel grpAutomoveisAtualizado)
        {
            var grp = repositorioGrpAutomoveis.SelecionarPorId(grpAutomoveisAtualizado.Id);

            if(grp == null)
                return Result.Fail("Grupo de automóveis não foi encontrado");

            grp.Nome = grpAutomoveisAtualizado.Nome;

            repositorioGrpAutomoveis.Editar(grp);

            return Result.Ok(grp);
        }

        public Result<GrupoAutomovel> Excluir(int grpId)
        {
            var grp = repositorioGrpAutomoveis.SelecionarPorId(grpId);

            if (grp == null)
                return Result.Fail("Grupo de automóveis não foi encontrado");

            repositorioGrpAutomoveis.Excluir(grp);

            return Result.Ok(grp);
        }

        public Result<GrupoAutomovel> SelecionarPorId(int grpId)
        {
            var grp = repositorioGrpAutomoveis.SelecionarPorId(grpId);

            if (grp == null)
                return Result.Fail("Grupo de automóveis não foi encontrado");

            return Result.Ok(grp);
        }

        public Result<List<GrupoAutomovel>> SelecionarTodos()
        {
            var grps = repositorioGrpAutomoveis.SelecionarTodos();

            return Result.Ok(grps);
        }

    }
}
