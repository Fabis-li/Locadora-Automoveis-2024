using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeAutomoveis.WebApp.Mapping.Resolvers
{
    public class CondutoresValueResolver : IValueResolver<Aluguel, FormularioViewModel, IEnumerable<SelectListItem>?>
    {
        private readonly IRepositorioCondutor repositorioCondutor;

        public CondutoresValueResolver(IRepositorioCondutor repositorioCondutor)
        {
            this.repositorioCondutor = repositorioCondutor;
        }

        public IEnumerable<SelectListItem>? Resolve(Aluguel source, FormularioViewModel destination, IEnumerable<SelectListItem>? destMember,
            ResolutionContext context)
        {
           if (destination is DevolucaoAluguelViewModel)
           {
                var condutores = repositorioCondutor.SelecionarPorId(source.CondutorId);

                return [new SelectListItem(condutores!.Nome, condutores.Id.ToString())];
           }

           return repositorioCondutor
               .SelecionarTodos()
                .Select(c => new SelectListItem(c.Nome, c.Id.ToString()));
        }
    }
}
