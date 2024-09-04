using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.Dominio.ModuloTaxa;
using LocadoraDeAutomoveis.WebApp.Models;

namespace LocadoraDeAutomoveis.WebApp.Mapping.Resolvers
{
    //public class TaxaEscolhidaValueResolver : IValueResolver<InserirAluguelViewModel, Aluguel, List<Taxa>>
    //{
    //    private readonly IRepositorioTaxa repositorioTaxa;
    //    public List<Taxa> Resolve(InserirAluguelViewModel source, Aluguel destination, List<Taxa> destMember, ResolutionContext context)
    //    {
    //        var idsTaxasEscolhidas = source.TaxasEscolhidas.ToList();

    //        return repositorioTaxa.SelecionarMuito(idsTaxasEscolhidas);
    //    }
    //}
}
