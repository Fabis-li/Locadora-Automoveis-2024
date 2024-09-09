using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraDeAutomoveis.WebApp.Mapping.Resolvers;
using LocadoraDeAutomoveis.WebApp.Models;

namespace LocadoraDeAutomoveis.WebApp.Mapping
{
    public class PlanoCobrancaProfile : Profile
    {
        public PlanoCobrancaProfile()
        {
            CreateMap<InserirPlanoCobrancaViewModel, PlanoCobranca>()
                .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom<EmpresaIdValueResolver>());

            CreateMap<EditarPlanoCobrancaViewModel, PlanoCobranca>();
            
            CreateMap<PlanoCobranca, ListarPlanoCobrancaViewModel>()
                .ForMember(
                    dest => dest.GrupoAutomovel, 
                    opt => opt.MapFrom(src => src.GrupoAutomovel!.Nome)
                );

            CreateMap<PlanoCobranca, DetalhesPlanoCobrancaViewModel>()
                .ForMember(
                    dest => dest.GrupoAutomovel,
                    opt => opt.MapFrom(src => src.GrupoAutomovel!.Nome)
                );

            CreateMap<PlanoCobranca, EditarPlanoCobrancaViewModel>()
                .ForMember(v => v.GrupoAutomovel, opt => opt.MapFrom<GrupoAutomoveisResolver>());
        }
    }
}
