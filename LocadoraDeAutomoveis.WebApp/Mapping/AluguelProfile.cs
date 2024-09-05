using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.WebApp.Mapping.Resolvers;
using LocadoraDeAutomoveis.WebApp.Models;

namespace LocadoraDeAutomoveis.WebApp.Mapping
{
    public class AluguelProfile: Profile
    {
        public AluguelProfile()
        {
            CreateMap<InserirAluguelViewModel, Aluguel>()
                .ForMember(dest => dest.TaxasEscolhidas, opt => opt.MapFrom(t => t.TaxasEscolhidas));
                

            CreateMap<EditarAluguelViewModel, Aluguel>();

            CreateMap<Aluguel, ListarAluguelViewModel>()
                .ForMember(dest => dest.Automovel, opt => opt.MapFrom(src => src.Automovel!.Modelo))
                .ForMember(dest => dest.Condutor, opt => opt.MapFrom(src => src.Condutor!.Nome))
                .ForMember(dest => dest.TipoPlanoCobranca, opt => opt.MapFrom(src => src.TipoPlanoCobranca.ToString()));

            CreateMap<Aluguel, EditarAluguelViewModel>();

            CreateMap<Aluguel, ConcluirAluguelViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TipoPlanoCobranca, opt => opt.MapFrom(src => src.TipoPlanoCobranca.ToString()))
                .ForMember(dest => dest.ValorTotal, opt => opt.MapFrom(src => src.ValorEntrada))
                .ForMember(dest => dest.DataSaida, opt => opt.MapFrom(src => src.DataSaida))
                .ForMember(dest => dest.DataRetorno, opt => opt.MapFrom(src => src.DataRetorno))
                .ForMember(dest => dest.KmRodado, opt => opt.MapFrom(src => src.KmRodado))
                .ForMember(dest => dest.MarcadorCombustivel, opt => opt.MapFrom(src => src.MarcadorCombustivel.ToString()));
               

            CreateMap<ConcluirAluguelViewModel, Aluguel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TipoPlanoCobranca, opt => opt.MapFrom(src => src.TipoPlanoCobranca))
                .ForMember(dest => dest.ValorEntrada, opt => opt.MapFrom(src => src.ValorTotal))
                .ForMember(dest => dest.DataSaida, opt => opt.MapFrom(src => src.DataSaida))
                .ForMember(dest => dest.DataRetorno, opt => opt.MapFrom(src => src.DataRetorno))
                .ForMember(dest => dest.KmRodado, opt => opt.MapFrom(src => src.KmRodado))
                .ForMember(dest => dest.MarcadorCombustivel, opt => opt.MapFrom(src => src.MarcadorCombustivel));


        }
    }
}
