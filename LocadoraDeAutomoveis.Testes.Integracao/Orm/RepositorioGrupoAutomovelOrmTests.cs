using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using LocadoraDeAutomoveis.Infra.Compartilhado;
using LocadoraDeAutomoveis.Infra.ModuloGrupoAutomoveis;

namespace LocadoraDeAutomoveis.Testes.Integracao.Orm
{
    [TestClass]
    public class RepositorioGrupoAutomovelOrmTests
    {
        private readonly LocadoraDeAutomoveisDbContext db;

        public RepositorioGrupoAutomovelOrmTests()
        {
            db = new LocadoraDeAutomoveisDbContext();

            db.Set<GrupoAutomovel>().RemoveRange(db.Set<GrupoAutomovel>());
            db.Set<Automovel>().RemoveRange(db.Set<Automovel>());

            db.SaveChanges();
        }

        [TestMethod]
        public void Deve_inserir_nome_grpAutomoveis()
        {
            //Arrange
            var grpAutomoveis = new GrupoAutomovel("Econômico");

            var repositorio = new RepositorioGrupoAutomovelEmOrm(db);

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
            var repositorio = new RepositorioGrupoAutomovelEmOrm(db);
            //Arrange
            var grpAutomoveis = new GrupoAutomovel("Econômico");

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
            var repositorio = new RepositorioGrupoAutomovelEmOrm(db);
            var grpAutomoveis = new GrupoAutomovel("Econômico");

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