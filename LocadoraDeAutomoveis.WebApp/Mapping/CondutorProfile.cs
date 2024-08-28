using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.WebApp.Models;

namespace LocadoraDeAutomoveis.WebApp.Mapping
{
    public class CondutorProfile : Profile
    {
        public CondutorProfile()
        {
            CreateMap<InserirCondutorViewModel, Condutor>();
            CreateMap<EditarCondutorViewModel, Condutor>();

            CreateMap<Condutor, ListarCondutorViewModel>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente.Nome))
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente.NumeroDocumento))
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente.Telefone))
                .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.Cliente.Id));

            CreateMap<Condutor, DetalhesCondutorViewModel>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente.Nome))
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente.NumeroDocumento))
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente.Telefone))
                .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.Cliente.Id));

            CreateMap<Condutor, EditarCondutorViewModel>();
        }


    }
}
