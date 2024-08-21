using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoreDeAutomoveis.Infra.Compartilhado;

namespace LocadoraDeAutomoveis.Testes.Integracao.Orm
{
    [TestClass]
    public class RespositorioAutomovelOrmTests
    {
        private readonly LocadoraDeAutomoveisDbContext db;

        public RespositorioAutomovelOrmTests()
        {
            db = new LocadoraDeAutomoveisDbContext();

            db.Set<Automovel>().RemoveRange(db.Set<Automovel>());

            db.SaveChanges();
        }

        [TestMethod]
        public void Deve_inserir_automovel()
        {
            var automovel = new Automovel("Fusca", "Volkswagen", "Azul", "ABC-1234", "Gasolina", 1970, 40, "fusca.jpg");

            var repositorio = new RepositorioAutomovelEmOrm(db);

            repositorio.Inserir(automovel);

            db.SaveChanges();

            var automovelInserido = db.Set<Automovel>().Find(automovel.Id);

            Assert.IsNotNull(automovelInserido);
        }

        [TestMethod]
        public void Deve_alterar_automovel()
        {
            var automovel = new Automovel("Fusca", "Volkswagen", "Azul", "ABC-1234", "Gasolina", 1970, 40, "fusca.jpg");

            var repositorio = new RepositorioAutomovelEmOrm(db);

            repositorio.Inserir(automovel);

            db.SaveChanges();

            automovel.Modelo = "Gol";

            repositorio.Alterar(automovel);

            db.SaveChanges();

            var automovelAlterado = db.Set<Automovel>().Find(automovel.Id);

            Assert.AreEqual("Gol", automovelAlterado.Modelo);
        }

        public void Deve_excluir_automovel()
        {
            var automovel = new Automovel("Fusca", "Volkswagen", "Azul", "ABC-1234", "Gasolina", 1970, 40, "fusca.jpg");

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
            var automovel = new Automovel("Fusca", "Volkswagen", "Azul", "ABC-1234", "Gasolina", 1970, 40, "fusca.jpg");

            var repositorio = new RepositorioAutomovelEmOrm(db);

            repositorio.Inserir(automovel);

            db.SaveChanges();

            var automovelConsultado = repositorio.ConsultarPorId(automovel.Id);

            Assert.IsNotNull(automovelConsultado);
        }

        [TestMethod]
        public void Deve_consultar_todos_automoveis()
        {
            var automovel1 = new Automovel("Fusca", "Volkswagen", "Azul", "ABC-1234", "Gasolina", 1970, 40, "fusca.jpg");
            var automovel2 = new Automovel("Gol", "Volkswagen", "Azul", "ABC-1234", "Gasolina", 1970, 40, "gol.jpg");

            var repositorio = new RepositorioAutomovelEmOrm(db);

            repositorio.Inserir(automovel1);
            repositorio.Inserir(automovel2);

            db.SaveChanges();

            var automoveis = repositorio.ConsultarTodos();

            Assert.AreEqual(2, automoveis.Count);
        }

    }
}
