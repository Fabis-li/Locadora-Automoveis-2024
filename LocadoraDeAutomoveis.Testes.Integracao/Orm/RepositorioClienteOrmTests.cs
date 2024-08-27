using FizzWare.NBuilder;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloTaxa;
using LocadoraDeAutomoveis.Infra.Compartilhado;
using LocadoraDeAutomoveis.Infra.ModuloCliente;

namespace LocadoraDeAutomoveis.Testes.Integracao.Orm
{
    [TestClass]
    [TestCategory("Integração")]
    public class RepositorioClienteOrmTests
    {
        private LocadoraDeAutomoveisDbContext dbContext;
        private RepositorioClienteEmOrm repositorioCliente;

        [TestInitialize]
        public void Inicializar()
        {
            dbContext = new LocadoraDeAutomoveisDbContext();

            dbContext.Clientes.RemoveRange(dbContext.Clientes);

            repositorioCliente = new RepositorioClienteEmOrm(dbContext);

            BuilderSetup.SetCreatePersistenceMethod<Cliente>(repositorioCliente.Inserir);
        }

        [TestMethod]
        public void Deve_Inserir_Cliente()
        {
            var cliente = Builder<Cliente>
                .CreateNew()
                .With(c => c.Id = 0)
                .Build();

            repositorioCliente.Inserir(cliente);

            var clienteInserido = repositorioCliente.SelecionarPorId(cliente.Id);

            Assert.IsNotNull(clienteInserido);
            Assert.AreEqual(cliente, clienteInserido);
        }

        [TestMethod]
        public void Deve_Editar_Cliente()
        {
            var cliente = Builder<Cliente>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            cliente.Nome = "Cliente Atualizado";
            cliente.Rg = "123456";
            cliente.Cnh = "123456";
            cliente.NumeroDocumento = "123456";
            cliente.Telefone = "123456";
            cliente.Cidade = "Cidade";
            cliente.Estado = "Estado";
            cliente.Bairro = "Bairro";
            cliente.Rua = "Rua";
            cliente.Numero = "123";
            cliente.TipoCliente = TipoClienteEnum.CPF;

            repositorioCliente.Editar(cliente);

            var clienteEditado = repositorioCliente.SelecionarPorId(cliente.Id);

            Assert.IsNotNull(clienteEditado);
            Assert.AreEqual(cliente, clienteEditado);
        }

        [TestMethod]
        public void Deve_Excluir_Cliente()
        {
            var cliente = Builder<Cliente>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            repositorioCliente.Excluir(cliente);

            var clienteExcluido = repositorioCliente.SelecionarPorId(cliente.Id);

            var clientes = repositorioCliente.SelecionarTodos();

            Assert.IsNull(clienteExcluido);
            Assert.AreEqual(0, clientes.Count);
        }

    }
}
