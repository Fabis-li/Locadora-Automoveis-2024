using AutoMapper;
using AutoMapper.Execution;
using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraDeAutomoveis.WebApp.Models;
using LocadoraDeAutomovies.Aplicacao.Servicos;

namespace LocadoraDeAutomoveis.WebApp.Mapping.Resolvers
{
    public class ValorTotalValueResolver : IValueResolver<Aluguel, DevolucaoAluguelViewModel, decimal>
    {
        private readonly AutomovelService serviceAutomovel;
        private readonly PlanoCobrancaService servicePlanoCobranca;

        public ValorTotalValueResolver(AutomovelService serviceAutomovel, PlanoCobrancaService servicePlanoCobranca)
        {
            this.serviceAutomovel = serviceAutomovel;
            this.servicePlanoCobranca = servicePlanoCobranca;
        }

        public decimal Resolve(Aluguel source, DevolucaoAluguelViewModel destination, decimal destMember, ResolutionContext context)
        {
            var automovel = serviceAutomovel.SelecionarPorId(source.AutomovelId).Value;

            var planoSelecionado = servicePlanoCobranca.SelecionarPorIdGrupoAutomovel(automovel.GrupoAutomovelId).Value;

            return source.CalcularValorTotal(planoSelecionado);
        }
    } 
}
