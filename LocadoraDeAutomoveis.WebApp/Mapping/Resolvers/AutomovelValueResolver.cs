﻿using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.WebApp.Models;
using LocadoraDeAutomovies.Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeAutomoveis.WebApp.Mapping.Resolvers
{
    public class AutomovelValueResolver : IValueResolver<Aluguel, FormularioViewModel, IEnumerable<SelectListItem>?>
    {
        private readonly AutomovelService serviceAutomovel;

        public AutomovelValueResolver(AutomovelService serviceAutomovel)
        {
            this.serviceAutomovel = serviceAutomovel;
        }

        public IEnumerable<SelectListItem>? Resolve(Aluguel source, FormularioViewModel destination, IEnumerable<SelectListItem>? destMember,
            ResolutionContext context)
        {
            if (destination is ListarAutomoveisViewModel)
            {
                var automoveisSelecionado = serviceAutomovel.SelecionarPorId(source.AutomovelId).Value;


                return [new SelectListItem(automoveisSelecionado!.Modelo, automoveisSelecionado.Id.ToString())];
            }

            return serviceAutomovel
                .SelecionarTodos(source.EmpresaId)
                .Value
                .Select(v => new SelectListItem(v.Modelo, v.Id.ToString()));
        }
    }
}
