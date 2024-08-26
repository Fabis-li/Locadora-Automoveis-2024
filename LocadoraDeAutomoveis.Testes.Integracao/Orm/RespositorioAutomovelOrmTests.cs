using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using LocadoraDeAutomoveis.Infra.Compartilhado;
using LocadoraDeAutomoveis.Infra.ModuloAutomovel;
using LocadoraDeAutomoveis.Infra.ModuloGrupoAutomoveis;

namespace LocadoraDeAutomoveis.Testes.Integracao.Orm
{
    [TestClass]
    public class RespositorioAutomovelOrmTests
    {
        private LocadoraDeAutomoveisDbContext db;

        private RepositorioAutomovelEmOrm repositorioAutomovel;
        private RepositorioGrupoAutomovelEmOrm repositorioGrupoAutomovel;

        [TestInitialize]
        public void configurarTestes()
        {
            db = new LocadoraDeAutomoveisDbContext();

            db.Set<Automovel>().RemoveRange(db.Set<Automovel>());
            db.Set<GrupoAutomovel>().RemoveRange(db.Set<GrupoAutomovel>());

            db.SaveChanges();
        }

        [TestMethod]
        public void Deve_inserir_automovel()
        {

            var grpoAuto = new GrupoAutomovel("Passeio");

            var repositorioGrupoAutomovel = new RepositorioGrupoAutomovelEmOrm(db);

            repositorioGrupoAutomovel.Inserir(grpoAuto);


            var automovel = new Automovel
            (
                "Fusca", 
                "Volkswagen", 
                "Azul", 
                "ABC-1234", 
                TipoCombustivel.Alcool,
                1970, 
                40, 
                "fusca.jpg",
                grpoAuto,
                1
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
            GrupoAutomovel grpoAuto = new GrupoAutomovel("Passeio");

            var repositorioGrpAuto = new RepositorioGrupoAutomovelEmOrm(db);

            repositorioGrpAuto.Inserir(grpoAuto);

            var automovel = new Automovel("Fusca", "Volkswagen", "Azul", "ABC-1234", TipoCombustivel.Alcool, 1970, 40, "fusca.jpg", grpoAuto,1);

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
            GrupoAutomovel grpoAuto = new GrupoAutomovel("Passeio");
            var repositorioGrpAuto = new RepositorioGrupoAutomovelEmOrm(db);
            repositorioGrpAuto.Inserir(grpoAuto);

            var automovel = new Automovel("Fusca", "Volkswagen", "Azul", "ABC-1234", TipoCombustivel.Alcool, 1970, 40, "fusca.jpg", grpoAuto, 1);

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
            GrupoAutomovel grpoAuto = new GrupoAutomovel("Passeio");
            var repositorioGrpAuto = new RepositorioGrupoAutomovelEmOrm(db);
            repositorioGrpAuto.Inserir(grpoAuto);

            var automovel = new Automovel("Fusca", "Volkswagen", "Azul", "ABC-1234", TipoCombustivel.Alcool, 1970, 40, "fusca.jpg", grpoAuto, 1);

            var repositorio = new RepositorioAutomovelEmOrm(db);

            repositorio.Inserir(automovel);

            db.SaveChanges();

            var automovelConsultado = repositorio.SelecionarPorId(automovel.Id);

            Assert.IsNotNull(automovelConsultado);
        }

        [TestMethod]
        public void Deve_consultar_todos_automoveis()
        {
            GrupoAutomovel grpoAuto = new GrupoAutomovel("Passeio");
            var repositorioGrpAuto = new RepositorioGrupoAutomovelEmOrm(db);
            repositorioGrpAuto.Inserir(grpoAuto);

            var automovel1 = new Automovel("Fusca", "Volkswagen", "Azul", "ABC-1234", TipoCombustivel.Alcool, 1970, 40, "fusca.jpg", grpoAuto, 1);
            var automovel2 = new Automovel("Gol", "Volkswagen", "Azul", "ABC-1234", TipoCombustivel.Alcool, 1970, 40, "gol.jpg", grpoAuto,1);

            var repositorio = new RepositorioAutomovelEmOrm(db);

            repositorio.Inserir(automovel1);
            repositorio.Inserir(automovel2);

            db.SaveChanges();

            var automoveis = repositorio.SelecionarTodos();

            Assert.AreEqual(2, automoveis.Count);
        }

    }
}
