using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.WebApp.Mapping.Resolvers;
using LocadoraDeAutomoveis.WebApp.Models;

namespace LocadoraDeAutomoveis.WebApp.Mapping
{
    public class CondutorProfile : Profile
    {
        public CondutorProfile()
        {
            CreateMap<InserirCondutorViewModel, Condutor>()
                .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom<EmpresaIdValueResolver>());

            CreateMap<EditarCondutorViewModel, Condutor>();

            CreateMap<Condutor, ListarCondutorViewModel>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente!.Nome));
              

            CreateMap<Condutor, DetalhesCondutorViewModel>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente!.Nome));
                

            CreateMap<Condutor, EditarCondutorViewModel>();
        }
    }
}
