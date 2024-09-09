using System.Security.Authentication;
using AutoMapper;
using LocadoraDeAutomovies.Aplicacao.Servicos;

namespace LocadoraDeAutomoveis.WebApp.Mapping.Resolvers;

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

        var empresaId = autenticacaoService.ObterIdEmpresaAsync(usuarioClaim).Result;

        if (empresaId is null)
            throw new AuthenticationException("Não foi possível obter o id da empresa!");


        return empresaId.Value;
    }
}