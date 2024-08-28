using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloConfiguracao;
using LocadoraDeAutomoveis.WebApp.Models;

namespace LocadoraDeAutomoveis.WebApp.Mapping
{
    public class ConfiguracaoProfile : Profile
    {
        public ConfiguracaoProfile()
        {
            CreateMap<InserirConfiguracaoViewModel, Configuracao>();
            CreateMap<EditarConfiguracaoViewModel, Configuracao>();
            
            CreateMap<Configuracao, DetalhesAutomovelViewModel>();
            CreateMap<Configuracao, EditarConfiguracaoViewModel>();
        }

    }
}
