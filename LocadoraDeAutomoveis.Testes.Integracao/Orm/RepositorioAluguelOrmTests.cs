using FizzWare.NBuilder;
using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraDeAutomoveis.Infra.Compartilhado;
using LocadoraDeAutomoveis.Infra.ModuloAluguel;
using LocadoraDeAutomoveis.Infra.ModuloAutomovel;
using LocadoraDeAutomoveis.Infra.ModuloCliente;
using LocadoraDeAutomoveis.Infra.ModuloCondutor;
using LocadoraDeAutomoveis.Infra.ModuloGrupoAutomoveis;
using LocadoraDeAutomoveis.Infra.ModuloPlanoCobranca;

namespace LocadoraDeAutomoveis.Testes.Integracao.Orm
{
    [TestClass]
    [TestCategory("Integração")]
    public class RepositorioAluguelOrmTests
    {
        private LocadoraDeAutomoveisDbContext dbContext;
        private RepositorioAluguelEmOrm repositorioAluguel;
        private RepositorioClienteEmOrm repositorioCliente;
        private RepositorioGrupoAutomovelEmOrm repositorioGrupoAutomoveis;
        private RepositorioAutomovelEmOrm repositorioAutomovel;
        private RepositorioPlanoCobrancaEmOrm repositorioPlanoCobranca;
        private RepositorioCondutorEmOrm repositorioCondutor;

        [TestInitialize]
        public void Inicializar()
        {
            dbContext = new LocadoraDeAutomoveisDbContext();

            dbContext.Alugueis.RemoveRange(dbContext.Alugueis);
            dbContext.Clientes.RemoveRange(dbContext.Clientes);
            dbContext.GrupoAutomoveis.RemoveRange(dbContext.GrupoAutomoveis);
            dbContext.Automoveis.RemoveRange(dbContext.Automoveis);
            dbContext.PlanosCobranca.RemoveRange(dbContext.PlanosCobranca);
            dbContext.Condutores.RemoveRange(dbContext.Condutores);

            repositorioAluguel = new RepositorioAluguelEmOrm(dbContext);
            repositorioCliente = new RepositorioClienteEmOrm(dbContext);
            repositorioGrupoAutomoveis = new RepositorioGrupoAutomovelEmOrm(dbContext);
            repositorioAutomovel = new RepositorioAutomovelEmOrm(dbContext);
            repositorioPlanoCobranca = new RepositorioPlanoCobrancaEmOrm(dbContext);
            repositorioCondutor = new RepositorioCondutorEmOrm(dbContext);

            BuilderSetup.SetCreatePersistenceMethod<Aluguel>(repositorioAluguel.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Cliente>(repositorioCliente.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<GrupoAutomovel>(repositorioGrupoAutomoveis.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Automovel>(repositorioAutomovel.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<PlanoCobranca>(repositorioPlanoCobranca.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Condutor>(repositorioCondutor.Inserir);
        }


        [TestMethod]
        public void Deve_Inserir_Aluguel()
        {

            var cliente = Builder<Cliente>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            var grupo = Builder<GrupoAutomovel>
                .CreateNew()
                .With(g => g.Id = 0)
                .Persist();

            var automovel = Builder<Automovel>
                .CreateNew()
                .With(a => a.Id = 0)
                .With(a => a.GrupoAutomoveis = grupo)
                .Persist();

            var planoCobranca = Builder<PlanoCobranca>
                .CreateNew()
                .With(p => p.Id = 0)
                .With(a => a.GrupoAutomovel = grupo)
                .Persist();

            var condutor = Builder<Condutor>
                .CreateNew()
                .With(c => c.Id = 0)
                .With(c => c.Cliente = cliente)
                .With(c => c.ClienteId = cliente.Id)
                .Persist();

            var aluguel = Builder<Aluguel>
                .CreateNew()
                .With(a => a.Id = 0)
                .With(a => a.Condutor = condutor).With(a => a.Automovel = automovel)
                .Build();

            repositorioAluguel.Inserir(aluguel);

            var aluguelInserido = repositorioAluguel.SelecionarPorId(aluguel.Id);

            Assert.IsNotNull(aluguelInserido);
            Assert.AreEqual(aluguel, aluguelInserido);

        }

        [TestMethod]
        public void Deve_Editar_Aluguel()
        {
            var cliente = Builder<Cliente>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            var grupo = Builder<GrupoAutomovel>
                .CreateNew()
                .With(g => g.Id = 0)
                .Persist();

            var automovel = Builder<Automovel>
                .CreateNew()
                .With(a => a.Id = 0)
                .With(a => a.GrupoAutomoveis = grupo)
                .Persist();

            var planoCobranca = Builder<PlanoCobranca>
                .CreateNew()
                .With(p => p.Id = 0)
                .With(a => a.GrupoAutomovel = grupo)
                .Persist();

            var condutor = Builder<Condutor>
                .CreateNew()
                .With(c => c.Id = 0)
                .With(c => c.Cliente = cliente)
                .With(c => c.ClienteId = cliente.Id)
                .Persist();

            var aluguel = Builder<Aluguel>
                .CreateNew()
                .With(a => a.Id = 0)
                .With(a => a.Condutor = condutor)
                .With(a => a.Automovel = automovel)
                
                .Persist();

            aluguel.Condutor = condutor;
            aluguel.Automovel = automovel;

            repositorioAluguel.Editar(aluguel);

            var aluguelSelecionado = repositorioAluguel.SelecionarPorId(aluguel.Id);

            Assert.IsNotNull(aluguelSelecionado);
            Assert.AreEqual(aluguel, aluguelSelecionado);
        }


        [TestMethod]
        public void Deve_Excluir_Aluguel()
        {
            var cliente = Builder<Cliente>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            var grupo = Builder<GrupoAutomovel>
                .CreateNew()
                .With(g => g.Id = 0)
                .Persist();

            var automovel = Builder<Automovel>
                .CreateNew()
                .With(a => a.Id = 0)
                .With(a => a.GrupoAutomoveis = grupo)
                .Persist();

            var planoCobranca = Builder<PlanoCobranca>
                .CreateNew()
                .With(p => p.Id = 0)
                .With(a => a.GrupoAutomovel = grupo)
                .Persist();

            var condutor = Builder<Condutor>
                .CreateNew()
                .With(c => c.Id = 0)
                .With(c => c.Cliente = cliente)
                .With(c => c.ClienteId = cliente.Id)
                .Persist();

            var aluguel = Builder<Aluguel>
                .CreateNew()
                .With(a => a.Id = 0)
                .With(a => a.Condutor = condutor)
                .With(a => a.Automovel = automovel)
                .Persist();

            repositorioAluguel.Excluir(aluguel);

            var aluguelSelecionado = repositorioAluguel.SelecionarPorId(aluguel.Id);

            var alugueis = repositorioAluguel.SelecionarTodos();

            Assert.IsNull(aluguelSelecionado);
            Assert.AreEqual(0, alugueis.Count);
        }
    }
}
