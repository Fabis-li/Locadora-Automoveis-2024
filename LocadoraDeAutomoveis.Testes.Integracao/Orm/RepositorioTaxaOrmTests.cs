using FizzWare.NBuilder;
using LocadoraDeAutomoveis.Dominio.ModuloTaxa;
using LocadoraDeAutomoveis.Infra.Compartilhado;
using LocadoraDeAutomoveis.Infra.ModuloTaxa;

namespace LocadoraDeAutomoveis.Testes.Integracao.Orm
{
    [TestClass]
    [TestCategory("Integração")]
    public class RepositorioTaxaOrmTests
    {
        private LocadoraDeAutomoveisDbContext dbContext;
        private RepositorioTaxaEmOrm repositorioTaxa;

        [TestInitialize]
        public void Inicializar()
        {
            dbContext = new LocadoraDeAutomoveisDbContext();

            dbContext.Taxas.RemoveRange(dbContext.Taxas);

            repositorioTaxa = new RepositorioTaxaEmOrm(dbContext);

            BuilderSetup.SetCreatePersistenceMethod<Taxa>(repositorioTaxa.Inserir);
        }

        [TestMethod]
        public void DeveInserirTaxa()
        {
            var taxa = Builder<Taxa>
                .CreateNew()
                .With(t => t.Id = 0)
                .Build();

            repositorioTaxa.Inserir(taxa);

            var taxaInserida = repositorioTaxa.SelecionarPorId(taxa.Id);

            Assert.IsNotNull(taxaInserida);
            Assert.AreEqual(taxa, taxaInserida);
        }

        [TestMethod]
        public void Deve_Editar_Taxa()
        {
            var taxa = Builder<Taxa>
                .CreateNew()
                .With(t => t.Id = 0)
                .Persist();

            taxa.Nome = "Taxa Atualizada";
            taxa.Valor = 100.0m;

            repositorioTaxa.Editar(taxa);

            var taxaEditada = repositorioTaxa.SelecionarPorId(taxa.Id);

            Assert.IsNotNull(taxaEditada);
            Assert.AreEqual(taxa, taxaEditada);
        }

        [TestMethod]
        public void Deve_Excluir_Taxa()
        {
            var taxa = Builder<Taxa>
                .CreateNew()
                .With(t => t.Id = 0)
                .Persist();

            repositorioTaxa.Excluir(taxa);

            var taxaExcluida = repositorioTaxa.SelecionarPorId(taxa.Id);

            var taxas = repositorioTaxa.SelecionarTodos();

            Assert.IsNull(taxaExcluida);
            Assert.AreEqual(0,taxas.Count);
        }

    }
    
}
