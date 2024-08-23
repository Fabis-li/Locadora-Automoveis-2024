using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraDeAutomoveis.WebApp.Models;

namespace LocadoraDeAutomoveis.WebApp.Mapping
{
    public class AutomovelProfile : Profile
    {
        public AutomovelProfile()
        {
            CreateMap<InserirAutomovelViewModel, Automovel>();
            CreateMap<EditarAutomovelViewModel, Automovel>();

            CreateMap<Automovel, EditarAutomovelViewModel>();

            CreateMap<Automovel, ListarAutomoveisViewModel>()
                .ForMember(dest => dest.GrupoAutomovel, 
                    opt => opt.MapFrom(src => src.GrupoAutomoveis!.Nome)
                );

            CreateMap<Automovel, DetalhesAutomovelViewModel>()
                .ForMember(dest => dest.GrupoAutomovel, opt => opt.MapFrom(src => src.GrupoAutomoveis!.Nome));
        }
    }
}
