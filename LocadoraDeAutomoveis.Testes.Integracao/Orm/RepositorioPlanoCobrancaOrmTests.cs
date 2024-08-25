using FizzWare.NBuilder;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraDeAutomoveis.Infra.Compartilhado;
using LocadoraDeAutomoveis.Infra.ModuloGrupoAutomoveis;
using LocadoraDeAutomoveis.Infra.ModuloPlanoCobranca;

namespace LocadoraDeAutomoveis.Testes.Integracao.Orm
{
    [TestClass]
    [TestCategory("Integração")]
    public class RepositorioPlanoCobrancaOrmTests
    {
        private LocadoraDeAutomoveisDbContext db;
        private RepositorioPlanoCobrancaEmOrm repositorio;
        private RepositorioGrupoAutomovelEmOrm repositorioGrupo;

        [TestInitialize]
        public void Inicializar()
        {
            db = new LocadoraDeAutomoveisDbContext();

            db.PlanosCobranca.RemoveRange(db.PlanosCobranca);
            db.GrupoAutomoveis.RemoveRange(db.GrupoAutomoveis);
            db.Automoveis.RemoveRange(db.Automoveis);

            repositorio = new RepositorioPlanoCobrancaEmOrm(db);
            repositorioGrupo = new RepositorioGrupoAutomovelEmOrm(db);

            BuilderSetup.SetCreatePersistenceMethod<PlanoCobranca>(repositorio.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<GrupoAutomovel>(repositorioGrupo.Inserir);
        }
        
        [TestMethod]
        public void Deve_Inserir_PlanoCobranca()
        {
           var grupo = Builder<GrupoAutomovel>
               .CreateNew()
               .With(g => g.Id = 0)
               .Build();

           repositorioGrupo.Inserir(grupo);

           db.SaveChanges();

           var planoCobranca = Builder<PlanoCobranca>
               .CreateNew()
               .With(p => p.Id = 0)
               .With(p => p.GrupoAutomovelId = grupo.Id)
               .Build();

           repositorio.Inserir(planoCobranca);

           db.SaveChanges();

           var planoCobrancaSelecionado = repositorio.SelecionarPorId(planoCobranca.Id);

           Assert.IsNotNull(planoCobrancaSelecionado);
           Assert.AreEqual(planoCobranca, planoCobrancaSelecionado);
        }

        [TestMethod]
        public void Deve_Editar_PlanoCobranca()
        {
            var grupo = Builder<GrupoAutomovel>
                .CreateNew()
                .With(g => g.Id = 0)
                .Build();

            repositorioGrupo.Inserir(grupo);

            db.SaveChanges();

            var planoCobranca = Builder<PlanoCobranca>
                .CreateNew()
                .With(p => p.Id = 0)
                .With(p => p.GrupoAutomovelId = grupo.Id)
                .Build();

            planoCobranca.PrecoDiarioPlanoDiario = 300.0m;

            repositorio.Editar(planoCobranca);

            db.SaveChanges();

            var planoCobrancaSelecionado = repositorio.SelecionarPorId(planoCobranca.Id);

            Assert.IsNotNull(planoCobrancaSelecionado);
            Assert.AreEqual(planoCobranca, planoCobrancaSelecionado);
        }

        [TestMethod]
        public void Deve_Excluir_PlanoCobranca()
        {
            var grupo = Builder<GrupoAutomovel>
                .CreateNew()
                .With(g => g.Id = 0)
                .Build();

            repositorioGrupo.Inserir(grupo);

            db.SaveChanges();

            var planoCobranca = Builder<PlanoCobranca>
                .CreateNew()
                .With(p => p.Id = 0)
                .With(p => p.GrupoAutomovelId = grupo.Id)
                .Build();

            repositorio.Inserir(planoCobranca);
            db.SaveChanges();

            repositorio.Excluir(planoCobranca);
            db.SaveChanges();

            var planoCobrancaSelecionado = repositorio.SelecionarPorId(planoCobranca.Id);

            var planosCobranca = repositorio.SelecionarTodos();

            Assert.IsNull(planoCobrancaSelecionado);
            Assert.AreEqual(0, planosCobranca.Count);
        }
    }
}
