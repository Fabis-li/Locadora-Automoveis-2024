using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using LocadoraDeAutomoveis.WebApp.Models;

namespace LocadoraDeAutomoveis.WebApp.Mapping
{
    public class GrpAutomoveisProfile : Profile
    {
        public GrpAutomoveisProfile()
        {
            CreateMap<InserirGrupoAutomovelViewModel, GrupoAutomovel>();
            CreateMap<EditarGrupoAutomovelViewModel, GrupoAutomovel>();
            CreateMap<GrupoAutomovel, ListarGrupoAutomovelViewModel>();
            CreateMap<GrupoAutomovel, DetalhesGrupoAutomovelViewModel>();
            CreateMap<GrupoAutomovel, EditarGrupoAutomovelViewModel>();
        }
    }
}
