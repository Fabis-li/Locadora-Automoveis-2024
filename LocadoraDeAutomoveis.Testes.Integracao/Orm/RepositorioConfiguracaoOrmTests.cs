using FizzWare.NBuilder;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloConfiguracao;
using LocadoraDeAutomoveis.Infra.Compartilhado;
using LocadoraDeAutomoveis.Infra.ModuloConfiguracao;

namespace LocadoraDeAutomoveis.Testes.Integracao.Orm
{
    [TestClass]
    [TestCategory("Integração")]
    public class RepositorioConfiguracaoOrmTests
    {
        private LocadoraDeAutomoveisDbContext dbContext;
        private RepositorioConfiguracaoEmOrm repositorioConfiguracao;

        [TestInitialize]
        public void Inicializar()
        {
            dbContext = new LocadoraDeAutomoveisDbContext();

            dbContext.Configuracoes.RemoveRange(dbContext.Configuracoes);

            repositorioConfiguracao = new RepositorioConfiguracaoEmOrm(dbContext);

            BuilderSetup.SetCreatePersistenceMethod<Configuracao>(repositorioConfiguracao.Inserir);
        }

        [TestMethod]
        public void Deve_Inserir_Configuracao()
        {
            var configuracao = Builder<Configuracao>
                .CreateNew()
                .With(c => c.Id = 0)
                .Build();

            repositorioConfiguracao.Inserir(configuracao);

            var configuracaoInserida = repositorioConfiguracao.SelecionarPorId(configuracao.Id);

            Assert.IsNotNull(configuracaoInserida);
            Assert.AreEqual(configuracao, configuracaoInserida);
        }

        [TestMethod]
        public void Deve_Editar_Configuracao()
        {
            var configuracao = Builder<Configuracao>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            configuracao.PrecoGasolina = 5;
            configuracao.PrecoAlcool = 4;
            configuracao.PrecoDiesel = 3;
            configuracao.PrecoGas = 2;

            repositorioConfiguracao.Editar(configuracao);

            var configuracaoEditada = repositorioConfiguracao.SelecionarPorId(configuracao.Id);

            Assert.IsNotNull(configuracaoEditada);
            Assert.AreEqual(configuracao, configuracaoEditada);
        }

        [TestMethod]
        public void Deve_Excluir_Configuracao()
        {
            var configuracao = Builder<Configuracao>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            repositorioConfiguracao.Excluir(configuracao);

            var configuracaoExcluida = repositorioConfiguracao.SelecionarPorId(configuracao.Id);

            var listaConfiguracoes = repositorioConfiguracao.SelecionarTodos();

            Assert.IsNull(configuracaoExcluida);            
            Assert.AreEqual(0, listaConfiguracoes.Count);
        }

    }
}
