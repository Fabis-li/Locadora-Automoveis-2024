using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.Dominio.ModuloTaxa;
using LocadoraDeAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeAutomoveis.WebApp.Mapping.Resolvers;

public class TaxasValueResolver : IValueResolver<Aluguel, FormularioViewModel, IEnumerable<SelectListItem>?>
{
    private readonly IRepositorioTaxa repositorioTaxa;

    public TaxasValueResolver(IRepositorioTaxa repositorioTaxa)
    {
        this.repositorioTaxa = repositorioTaxa;
    }

    public IEnumerable<SelectListItem>? Resolve(Aluguel source, FormularioViewModel destination, IEnumerable<SelectListItem>? destMember,
        ResolutionContext context)
    {
        return repositorioTaxa
            .SelecionarTodos()
            .Select(t => new SelectListItem(t.Nome, t.Id.ToString()));
    }
}