using AutoMapper;
using AutoMapper.Execution;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraDeAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeAutomoveis.WebApp.Mapping.Resolvers
{
    public class GrupoAutomoveisResolver :
        IValueResolver<PlanoCobranca, EditarPlanoCobrancaViewModel, IEnumerable<SelectListItem>?>
    {
        private readonly IRepositorioGrupoAutomovel repositorioGrupo;

        public GrupoAutomoveisResolver(IRepositorioGrupoAutomovel repositorioGrupo)
        {
            this.repositorioGrupo = repositorioGrupo;
        }
        public IEnumerable<SelectListItem>? Resolve(PlanoCobranca source, EditarPlanoCobrancaViewModel destination, IEnumerable<SelectListItem>? destMember,
            ResolutionContext context)
        {
            return repositorioGrupo
                .SelecionarTodos()
                .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));
        }
    }
}
