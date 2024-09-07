using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using LocadoraDeAutomoveis.WebApp.Models;
using LocadoraDeAutomovies.Aplicacao.Servicos;

namespace LocadoraDeAutomoveis.WebApp.Mapping
{
    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile()
        {
            CreateMap<InserirFuncionarioViewModel, Funcionario>()
                .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom<EmpresaIdValueResolver>());

            CreateMap<Funcionario, ListarFuncionarioViewModel>();

        }

    }

    public class EmpresaIdValueResolver : IValueResolver<object, object, int>
    {
        private readonly AutenticacaoService autenticacaoService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public EmpresaIdValueResolver(AutenticacaoService autenticacaoService, IHttpContextAccessor httpContextAccessor)
        {
            this.autenticacaoService = autenticacaoService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public int Resolve(object source, object destination, int destMember, ResolutionContext context)
        {
            var usuarioClaim = httpContextAccessor.HttpContext?.User;

            var empresa = autenticacaoService.ObterUsuarioAsync(usuarioClaim).Result;

            return empresa?.Id ?? 0;
        }
    }
}
