using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using LocadoreDeAutomoveis.Infra.Compartilhado;
using LocadoreDeAutomoveis.Infra.ModuloAutomovel;
using LocadoreDeAutomoveis.Infra.ModuloGrpAutomoveis;

namespace LocadoraDeAutomoveis.Testes.Integracao.Orm
{
    [TestClass]
    public class RespositorioAutomovelOrmTests
    {
        private LocadoraDeAutomoveisDbContext db;
        private RepositorioAutomovelEmOrm repositorioAutomovel;

        [TestInitialize]
        public void configurarTestes()
        {
            db = new LocadoraDeAutomoveisDbContext();

            db.Set<Automovel>().RemoveRange(db.Set<Automovel>());
            db.Set<GrpAutomoveis>().RemoveRange(db.Set<GrpAutomoveis>());

            db.SaveChanges();
        }

        [TestMethod]
        public void Deve_inserir_automovel()
        {
            GrpAutomoveis grpoAuto = new GrpAutomoveis("Passeio");
            var repositorioGrpAuto = new RepositorioGrpAutomoveisEmOrm(db);
            repositorioGrpAuto.Inserir(grpoAuto);

            var automovel = new Automovel
            (
                "Fusca", 
                "Volkswagen", 
                "Azul", 
                "ABC-1234", 
                "Gasolina",
                1970, 
                40, 
                "fusca.jpg",
                grpoAuto
            );

            var repositorioAutomovel = new RepositorioAutomovelEmOrm(db);

            repositorioAutomovel.Inserir(automovel);
            db.SaveChanges();

            var automovelInserido  = repositorioAutomovel.SelecionarPorId(automovel.Id);

            Assert.IsNotNull(automovelInserido);
            Assert.AreEqual(automovel, automovelInserido);
        }

        [TestMethod]
        public void Deve_alterar_automovel()
        {
            GrpAutomoveis grpoAuto = new GrpAutomoveis("Passeio");
            var repositorioGrpAuto = new RepositorioGrpAutomoveisEmOrm(db);
            repositorioGrpAuto.Inserir(grpoAuto);

            var automovel = new Automovel("Fusca", "Volkswagen", "Azul", "ABC-1234", "Gasolina", 1970, 40, "fusca.jpg", grpoAuto);

            var repositorio = new RepositorioAutomovelEmOrm(db);

            repositorio.Inserir(automovel);

            db.SaveChanges();

            automovel.Modelo = "Gol";

            repositorio.Editar(automovel);

            db.SaveChanges();

            var automovelAlterado = db.Set<Automovel>().Find(automovel.Id);

            Assert.AreEqual("Gol", automovelAlterado.Modelo);
        }

        [TestMethod]
        public void Deve_excluir_automovel()
        {
            GrpAutomoveis grpoAuto = new GrpAutomoveis("Passeio");
            var repositorioGrpAuto = new RepositorioGrpAutomoveisEmOrm(db);
            repositorioGrpAuto.Inserir(grpoAuto);

            var automovel = new Automovel("Fusca", "Volkswagen", "Azul", "ABC-1234", "Gasolina", 1970, 40, "fusca.jpg", grpoAuto);

            var repositorio = new RepositorioAutomovelEmOrm(db);

            repositorio.Inserir(automovel);

            db.SaveChanges();

            repositorio.Excluir(automovel);

            db.SaveChanges();

            var automovelExcluido = db.Set<Automovel>().Find(automovel.Id);

            Assert.IsNull(automovelExcluido);
        }

        [TestMethod]
        public void Deve_consultar_automovel_por_id()
        {
            GrpAutomoveis grpoAuto = new GrpAutomoveis("Passeio");
            var repositorioGrpAuto = new RepositorioGrpAutomoveisEmOrm(db);
            repositorioGrpAuto.Inserir(grpoAuto);

            var automovel = new Automovel("Fusca", "Volkswagen", "Azul", "ABC-1234", "Gasolina", 1970, 40, "fusca.jpg", grpoAuto);

            var repositorio = new RepositorioAutomovelEmOrm(db);

            repositorio.Inserir(automovel);

            db.SaveChanges();

            var automovelConsultado = repositorio.SelecionarPorId(automovel.Id);

            Assert.IsNotNull(automovelConsultado);
        }

        [TestMethod]
        public void Deve_consultar_todos_automoveis()
        {
            GrpAutomoveis grpoAuto = new GrpAutomoveis("Passeio");
            var repositorioGrpAuto = new RepositorioGrpAutomoveisEmOrm(db);
            repositorioGrpAuto.Inserir(grpoAuto);

            var automovel1 = new Automovel("Fusca", "Volkswagen", "Azul", "ABC-1234", "Gasolina", 1970, 40, "fusca.jpg", grpoAuto);
            var automovel2 = new Automovel("Gol", "Volkswagen", "Azul", "ABC-1234", "Gasolina", 1970, 40, "gol.jpg", grpoAuto);

            var repositorio = new RepositorioAutomovelEmOrm(db);

            repositorio.Inserir(automovel1);
            repositorio.Inserir(automovel2);

            db.SaveChanges();

            var automoveis = repositorio.SelecionarTodos();

            Assert.AreEqual(2, automoveis.Count);
        }

    }
}
