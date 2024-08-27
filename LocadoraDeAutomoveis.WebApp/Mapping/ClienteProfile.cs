using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.WebApp.Models;

namespace LocadoraDeAutomoveis.WebApp.Mapping
{
    public class ClienteProfile :Profile
    {
        public ClienteProfile()
        {
            CreateMap<InserirClienteViewModel, Cliente>();
            CreateMap<EditarClienteViewModel, Cliente>();

            CreateMap<Cliente, ListarClienteViewModel>()
                .ForMember(
                    dest => dest.TipoCliente,
                    opt => opt.MapFrom(c => c.TipoCliente.ToString())
                );

            CreateMap<Cliente, DetalhesClienteViewModel>()
                .ForMember(
                    dest => dest.TipoCliente,
                    opt => opt.MapFrom(c => c.TipoCliente.ToString())
                );

            CreateMap<Cliente, EditarClienteViewModel>();
        }
    }
}
