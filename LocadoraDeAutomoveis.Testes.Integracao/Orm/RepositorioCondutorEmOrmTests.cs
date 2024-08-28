using FizzWare.NBuilder;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Dominio.ModuloTaxa;
using LocadoraDeAutomoveis.Infra.Compartilhado;
using LocadoraDeAutomoveis.Infra.ModuloCliente;
using LocadoraDeAutomoveis.Infra.ModuloCondutor;

namespace LocadoraDeAutomoveis.Testes.Integracao.Orm
{
    [TestClass]
    [TestCategory("Integração")]
    public class RepositorioCondutorEmOrmTests
    {
        private LocadoraDeAutomoveisDbContext dbContext;

        private RepositorioCondutorEmOrm repositorioCondutor;
        private RepositorioClienteEmOrm repositorioCliente;

        [TestInitialize]
        public void Inicializar()
        {
            dbContext = new LocadoraDeAutomoveisDbContext();

            dbContext.Condutores.RemoveRange(dbContext.Condutores);
            dbContext.Clientes.RemoveRange(dbContext.Clientes);

            repositorioCondutor = new RepositorioCondutorEmOrm(dbContext);
            repositorioCliente = new RepositorioClienteEmOrm(dbContext);

            BuilderSetup.SetCreatePersistenceMethod<Condutor>(repositorioCondutor.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Cliente>(repositorioCliente.Inserir);
        }

        [TestMethod]
        public void Deve_Inserir_Condutor()
        {
            var cliente = Builder<Cliente>
                .CreateNew()
                .With(c => c.Id = 0)
                .Build();

            repositorioCliente.Inserir(cliente);

            var condutor = Builder<Condutor>
                .CreateNew()
                .With(c => c.Id = 0)
                .With(c => c.Cliente = cliente)
                .With(c => c.ClienteId = cliente.Id)
                .Build();

            repositorioCondutor.Inserir(condutor);

            var condutorInserido = repositorioCondutor.SelecionarPorId(condutor.Id);

            Assert.IsNotNull(condutorInserido);
            Assert.AreEqual(condutor, condutorInserido);
        }

        [TestMethod]
        public void Deve_Editar_Condutor()
        {
            var cliente = Builder<Cliente>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            var condutor = Builder<Condutor>
                .CreateNew()
                .With(c => c.Id = 0)
                .With(c => c.Cliente = cliente)
                .With(c => c.ClienteId = cliente.Id)
                .Persist();

            condutor.Nome = "Condutor Atualizado";
            condutor.Email = "novoemail@dominio.com";

            repositorioCondutor.Editar(condutor);

            var condutorEditado = repositorioCondutor.SelecionarPorId(condutor.Id);

            Assert.IsNotNull(condutorEditado);
            Assert.AreEqual(condutor, condutorEditado);
        }

        [TestMethod]
        public void Deve_Excluir_Condutor()
        {
            var cliente = Builder<Cliente>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            var condutor = Builder<Condutor>
                .CreateNew()
                .With(c => c.Id = 0)
                .With(c => c.Cliente = cliente)
                .With(c => c.ClienteId = cliente.Id)
                .Persist();

            repositorioCondutor.Excluir(condutor);

            var condutorExcluido = repositorioCondutor.SelecionarPorId(condutor.Id);

            Assert.IsNull(condutorExcluido);
        }

    }
}
