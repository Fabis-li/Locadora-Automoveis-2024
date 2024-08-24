using FizzWare.NBuilder;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraDeAutomoveis.Infra.Compartilhado;
using LocadoraDeAutomoveis.Infra.ModuloPlanoCobranca;

namespace LocadoraDeAutomoveis.Testes.Integracao.Orm
{
    [TestClass]
    [TestCategory("Integração")]
    public class RepositorioPlanoCobrancaOrmTests
    {
        private LocadoraDeAutomoveisDbContext db;
        private RepositorioPlanoCobrancaEmOrm repositorio;

        [TestInitialize]
        public void Inicializar()
        {
            db = new LocadoraDeAutomoveisDbContext();

            db.Set<PlanoCobranca>().RemoveRange(db.Set<PlanoCobranca>());
            
            repositorio = new RepositorioPlanoCobrancaEmOrm(db);

            BuilderSetup.SetCreatePersistenceMethod<PlanoCobranca>(repositorio.Inserir);
        }
        
        [TestMethod]
        public void Deve_Inserir_PlanoCobranca_Diario()
        {
            var plano = Builder<PlanoCobranca>
                .CreateNew()
                .With(g => g.NomePlano = "Diário")
                .With(g => )
                .Persist();

            var planoSelecionado = repositorio.SelecionarPorId(plano.Id);

            Assert.IsNotNull(planoSelecionado);
            Assert.AreEqual(plano.NomePlano, planoSelecionado.NomePlano);
        }

        [TestMethod]
        public void Deve_Editar_PlanoCobranca_Diario()
        {

        }

        [TestMethod]
        public void Deve_Excluir_PlanoCobranca_Diario()
        {

        }
    }
}
