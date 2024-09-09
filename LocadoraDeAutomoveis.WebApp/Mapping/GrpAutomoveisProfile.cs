using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using LocadoraDeAutomoveis.WebApp.Mapping.Resolvers;
using LocadoraDeAutomoveis.WebApp.Models;

namespace LocadoraDeAutomoveis.WebApp.Mapping
{
    public class GrpAutomoveisProfile : Profile
    {
        public GrpAutomoveisProfile()
        {
            CreateMap<InserirGrupoAutomovelViewModel, GrupoAutomovel>()
                .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom<EmpresaIdValueResolver>());

            CreateMap<EditarGrupoAutomovelViewModel, GrupoAutomovel>();
            CreateMap<GrupoAutomovel, ListarGrupoAutomovelViewModel>();
            CreateMap<GrupoAutomovel, DetalhesGrupoAutomovelViewModel>();
            CreateMap<GrupoAutomovel, EditarGrupoAutomovelViewModel>();
        }
    }
}
