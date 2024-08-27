using LocadoraDeAutomoveis.Dominio.ModuloTaxa;

namespace LocadoraDeAutomoveis.Testes.Unidade
{
    [TestClass]
    [TestCategory("Unidade")]
    public class TaxaTests
    {
        [TestMethod]
        public void Deve_Criar_Taxa_Valida()
        {
            var taxa = new Taxa
                (
                    "Taxa 1",
                    10m,
                    TipoCobrancaEnum.Diaria
                );

            var erros = taxa.Validar();

            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void Deve_Criar_Taxa_Com_Erro_Nome()
        {
            var taxa = new Taxa
                (
                    "",
                    10m,
                    TipoCobrancaEnum.Diaria
                );

            var erros = taxa.Validar();

            List<string> errosEsperados =
            [
                "O Nome é obrigatório",
            ];

            Assert.AreEqual(errosEsperados.Count, erros.Count);
        }

        [TestMethod]
        public void Deve_Criar_Taxa_Com_Erro_Valor()
        {
            var taxa = new Taxa
                (
                    "Taxa 1",
                    0m,
                    TipoCobrancaEnum.Diaria
                );

            var erros = taxa.Validar();

            List<string> errosEsperados =
            [
                "O valor precisa ser ao menos 1",
            ];

            Assert.AreEqual(errosEsperados.Count, erros.Count);
        }

        [TestMethod]
        public void Deve_Criar_Taxa_Com_Erro_Nome_Valor()
        {
            var taxa = new Taxa
                (
                    "",
                    0m,
                    TipoCobrancaEnum.Diaria
                );

            var erros = taxa.Validar();

            List<string> errosEsperados =
            [
                "O Nome é obrigatório",
                "O valor precisa ser ao menos 1",
            ];

            Assert.AreEqual(errosEsperados.Count, erros.Count);
        }
    }
}
