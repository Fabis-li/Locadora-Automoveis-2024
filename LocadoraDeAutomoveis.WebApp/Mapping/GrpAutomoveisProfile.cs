using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using LocadoraDeAutomoveis.WebApp.Models;

namespace LocadoraDeAutomoveis.WebApp.Mapping
{
    public class GrpAutomoveisProfile : Profile
    {
        public GrpAutomoveisProfile()
        {
            CreateMap<InserirGrpAutomoveisViewModel, GrpAutomoveis>();
            CreateMap<EditarGrpAutomoveisViewModel, GrpAutomoveis>();
            CreateMap<GrpAutomoveis, ListarGrpAutomoveisViewModel>();
            CreateMap<GrpAutomoveis, DetalhesGrpAutomoveisViewModel>();
            CreateMap<GrpAutomoveis, EditarGrpAutomoveisViewModel>();
        }
    }
}
