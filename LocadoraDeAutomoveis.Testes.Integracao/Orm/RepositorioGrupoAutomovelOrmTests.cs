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
            var grupoAutomoveis = new GrupoAutomovel("Econômico");

            repositorio.Inserir(grupoAutomoveis);
            
            //Act
            var  grupoAtualizado= repositorio.SelecionarPorId(grupoAutomoveis.Id);
            grupoAtualizado.Nome = "SUV";

            repositorio.Editar(grupoAtualizado);

            db.SaveChanges();

            //assert
            var grpEncontrado = repositorio.SelecionarPorId(grupoAutomoveis.Id);

            Assert.IsNotNull(grpEncontrado);
            Assert.AreEqual(grupoAtualizado.Nome, grpEncontrado.Nome);
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