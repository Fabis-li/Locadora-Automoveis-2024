using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraDeAutomoveis.WebApp.Mapping.Resolvers;
using LocadoraDeAutomoveis.WebApp.Models;

namespace LocadoraDeAutomoveis.WebApp.Mapping
{
    public class AutomovelProfile : Profile
    {
        public AutomovelProfile()
        {
            CreateMap<InserirAutomovelViewModel, Automovel>()
                .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom<EmpresaIdValueResolver>())
                .ForMember(dest => dest.FotoVeiculo, opt => opt.MapFrom<FotoValueRevolver>());

            CreateMap<EditarAutomovelViewModel, Automovel>()
                .ForMember(dest => dest.FotoVeiculo, opt => opt.MapFrom<FotoValueRevolver>());

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

public class FotoValueRevolver : IValueResolver<FormularioAutomovelViewModel, Automovel, byte[]>
{
    public FotoValueRevolver() { }
    public byte[] Resolve(FormularioAutomovelViewModel source, Automovel destination, byte[] destMember, ResolutionContext context)
    {
        using (var memoryStream = new MemoryStream())
        {
            source.FotoVeiculo.CopyTo(memoryStream);

            return memoryStream.ToArray();
        }
    }
}
