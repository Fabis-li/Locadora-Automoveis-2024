using FluentResults;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;

namespace LocadoraDeAutomovies.Aplicacao.Servicos
{
    public class ClienteService
    {
        private readonly IRepositorioCliente repositorioCliente;

        public ClienteService(IRepositorioCliente repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public Result<Cliente> Inserir(Cliente cliente)
        {
            var errosValidacao = cliente.Validar();

            if (errosValidacao.Count > 0)            
                return Result.Fail(errosValidacao);            

            repositorioCliente.Inserir(cliente);

            return Result.Ok(cliente);
        }

        public Result<Cliente> Editar(Cliente clienteAtualizado)
        {
            var cliente = repositorioCliente.SelecionarPorId(clienteAtualizado.Id);

            if (cliente is null)
                return Result.Fail("Cliente não encontrado!");

            var errosValidacao = clienteAtualizado.Validar();

            cliente.Nome = clienteAtualizado.Nome;
            cliente.Rg = clienteAtualizado.Rg;
            cliente.Cnh = clienteAtualizado.Cnh;
            cliente.NumeroDocumento = clienteAtualizado.NumeroDocumento;
            cliente.Telefone = clienteAtualizado.Telefone;
            cliente.Cidade = clienteAtualizado.Cidade;
            cliente.Estado = clienteAtualizado.Estado;
            cliente.Bairro = clienteAtualizado.Bairro;
            cliente.Rua = clienteAtualizado.Rua;
            cliente.Numero = clienteAtualizado.Numero;
            cliente.TipoCliente = clienteAtualizado.TipoCliente;

            repositorioCliente.Editar(cliente);

            return Result.Ok(cliente);
        }

        public Result<Cliente> Excluir(int clienteid)
        {
            var cliente = repositorioCliente.SelecionarPorId(clienteid);

            if (cliente is null)
                return Result.Fail("Cliente não encontrado!");

            repositorioCliente.Excluir(cliente);

            return Result.Ok(cliente);
        }

        public Result<Cliente> SelecionarPorId(int clienteId)
        {
            var cliente = repositorioCliente.SelecionarPorId(clienteId);

            if (cliente is null)
                return Result.Fail("Cliente não encontrado!");

            return Result.Ok(cliente);
        }

        public Result<List<Cliente>> SelecionarTodos(int empresaId)
        {
            var clientes = repositorioCliente.Filtrar(c => c.EmpresaId == empresaId);

            return Result.Ok(clientes);
        }
    }
}
