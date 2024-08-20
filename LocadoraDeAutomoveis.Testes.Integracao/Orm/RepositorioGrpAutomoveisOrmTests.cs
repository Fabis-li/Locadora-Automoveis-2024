using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using LocadoreDeAutomoveis.Infra.Compartilhado;
using LocadoreDeAutomoveis.Infra.ModuloGrpAutomoveis;

namespace LocadoraDeAutomoveis.Testes.Integracao.Orm
{
    [TestClass]
    public class RepositorioGrpAutomoveisOrmTests
    {
        private readonly LocadoraDeAutomoveisDbContext db;

        public RepositorioGrpAutomoveisOrmTests()
        {
            db = new LocadoraDeAutomoveisDbContext();

            db.Set<GrpAutomoveis>().RemoveRange(db.Set<GrpAutomoveis>());

            db.SaveChanges();
        }

        [TestMethod]
        public void Deve_inserir_nome_grpAutomoveis()
        {
            //Arrange
            var grpAutomoveis = new GrpAutomoveis("Econômico");

            var repositorio = new RepositorioGrpAutomoveisEmOrm(db);

            //Act
            repositorio.Inserir(grpAutomoveis);
            db.SaveChanges();

            //assert
            var grpAutomoveisInserido = repositorio.SelecionarPorId(grpAutomoveis.Id);

            Assert.IsNotNull(grpAutomoveisInserido);
            Assert.AreEqual(grpAutomoveis.Nome, grpAutomoveisInserido.Nome);
        }

        [TestMethod]
        public void Deve_editar_nome_grpAutomoveis()
        {
            var repositorio = new RepositorioGrpAutomoveisEmOrm(db);
            //Arrange
            var grpAutomoveis = new GrpAutomoveis("Econômico");

            repositorio.Inserir(grpAutomoveis);
            
            //Act
            var  grpAtualizado= repositorio.SelecionarPorId(grpAutomoveis.Id);
            grpAtualizado.Nome = "SUV";

            repositorio.Editar(grpAtualizado);

            db.SaveChanges();

            //assert
            var grpEncontrado = repositorio.SelecionarPorId(grpAutomoveis.Id);

            Assert.IsNotNull(grpEncontrado);
            Assert.AreEqual(grpAtualizado.Nome, grpEncontrado.Nome);
        }

        [TestMethod]
        public void Deve_excluir_grpAutomoveis()
        {
            //Arrange
            var repositorio = new RepositorioGrpAutomoveisEmOrm(db);
            var grpAutomoveis = new GrpAutomoveis("Econômico");

            repositorio.Inserir(grpAutomoveis);

            //Act
            repositorio.Excluir(grpAutomoveis);
            db.SaveChanges();

            //assert
            var grpEncontrado = repositorio.SelecionarPorId(grpAutomoveis.Id);

            Assert.IsNull(grpEncontrado);
        }
    }
}