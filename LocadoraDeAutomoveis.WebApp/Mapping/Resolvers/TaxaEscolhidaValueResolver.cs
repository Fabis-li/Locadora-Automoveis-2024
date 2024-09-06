using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.Dominio.ModuloTaxa;
using LocadoraDeAutomoveis.WebApp.Models;

namespace LocadoraDeAutomoveis.WebApp.Mapping.Resolvers
{
    public class TaxaEscolhidaValueResolver : IValueResolver<FormularioViewModel,Aluguel, List<Taxa>>
    {
        private readonly IRepositorioTaxa repositorioTaxa;

        public TaxaEscolhidaValueResolver(IRepositorioTaxa repositorioTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
        }


        public List<Taxa> Resolve(FormularioViewModel source, Aluguel destination, List<Taxa> destMember, ResolutionContext context)
        {
            var idsTaxasSelecionadas = source.TaxasEscolhidas.ToList();

            return repositorioTaxa.SelecionarMuito(idsTaxasSelecionadas);
        }
    }
}
