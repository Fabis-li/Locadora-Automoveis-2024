using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloTaxa;
using LocadoraDeAutomoveis.WebApp.Models;

namespace LocadoraDeAutomoveis.WebApp.Mapping
{
    public class TaxaProfile : Profile
    {
        public TaxaProfile()
        {
            CreateMap<InserirTaxaViewModel, Taxa>();
            CreateMap<EditarTaxaViewModel, Taxa>();

            CreateMap<Taxa, ListarTaxaViewModel>()
                .ForMember(
                    dest => dest.TipoCobranca,
                    opt => opt.MapFrom(t => t.TipoCobranca.ToString())
                );

            CreateMap<Taxa, DetalhesTaxaViewModel>()
                .ForMember(
                    dest => dest.TipoCobranca,
                    opt => opt.MapFrom(t => t.TipoCobranca.ToString())
                );

            CreateMap<Taxa, EditarTaxaViewModel>();
        }
    }
}
