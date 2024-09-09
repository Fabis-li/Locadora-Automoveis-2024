using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloConfiguracao;
using LocadoraDeAutomoveis.WebApp.Mapping.Resolvers;
using LocadoraDeAutomoveis.WebApp.Models;

namespace LocadoraDeAutomoveis.WebApp.Mapping
{
    public class ConfiguracaoProfile : Profile
    {
        public ConfiguracaoProfile()
        {
            CreateMap<InserirConfiguracaoViewModel, Configuracao>()
                .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom<EmpresaIdValueResolver>());

            CreateMap<EditarConfiguracaoViewModel, Configuracao>();
            
            CreateMap<Configuracao, DetalhesAutomovelViewModel>();
            CreateMap<Configuracao, EditarConfiguracaoViewModel>();
        }

    }
}
