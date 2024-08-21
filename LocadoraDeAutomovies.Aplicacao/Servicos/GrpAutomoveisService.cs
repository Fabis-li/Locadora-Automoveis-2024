using FluentResults;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;

namespace LocadoraDeAutomovies.Aplicacao.Servicos
{
    public class GrpAutomoveisService
    {
        private readonly IRepositorioGrpAutomoveis repositorioGrpAutomoveis;

        public GrpAutomoveisService(IRepositorioGrpAutomoveis repositorioGrpAutomoveis)
        {
            this.repositorioGrpAutomoveis = repositorioGrpAutomoveis;
        }

        public Result<GrpAutomoveis> Inserir(GrpAutomoveis grpAutomoveis)
        {
            repositorioGrpAutomoveis.Inserir(grpAutomoveis);

            return Result.Ok(grpAutomoveis);
        }

        public Result<GrpAutomoveis> Editar(GrpAutomoveis grpAutomoveisAtualizado)
        {
            var grp = repositorioGrpAutomoveis.SelecionarPorId(grpAutomoveisAtualizado.Id);

            if(grp == null)
                return Result.Fail("Grupo de automóveis não foi encontrado");

            grp.Nome = grpAutomoveisAtualizado.Nome;

            repositorioGrpAutomoveis.Editar(grp);

            return Result.Ok(grp);
        }

        public Result<GrpAutomoveis> Excluir(int grpId)
        {
            var grp = repositorioGrpAutomoveis.SelecionarPorId(grpId);

            if (grp == null)
                return Result.Fail("Grupo de automóveis não foi encontrado");

            repositorioGrpAutomoveis.Excluir(grp);

            return Result.Ok(grp);
        }

        public Result<GrpAutomoveis> SelecionarPorId(int grpId)
        {
            var grp = repositorioGrpAutomoveis.SelecionarPorId(grpId);

            if (grp == null)
                return Result.Fail("Grupo de automóveis não foi encontrado");

            return Result.Ok(grp);
        }

        public Result<List<GrpAutomoveis>> SelecionarTodos()
        {
            var grps = repositorioGrpAutomoveis.SelecionarTodos();

            return Result.Ok(grps);
        }

    }
}
