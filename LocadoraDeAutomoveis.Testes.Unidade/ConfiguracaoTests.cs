using LocadoraDeAutomoveis.Dominio.ModuloConfiguracao;

namespace LocadoraDeAutomoveis.Testes.Unidade
{
    [TestClass]
    [TestCategory("Unidade")]
    public class ConfiguracaoTests
    {
        [TestMethod]
        public void Deve_Criar_Configuracao_Valida()
        {
            var configuracao = new Configuracao
            (
                10.0m,
                5.0m,
                6.0m,
                3.0m
            );

            var erros = configuracao.Validar();

            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void Deve_Criar_Configuracao_Com_Erro_PrecoGasolina()
        {
            var configuracao = new Configuracao
            (
                0.0m,
                5.0m,
                6.0m,
                3.0m
            );

            var erros = configuracao.Validar();


            List<string> errosEsperados =
            [
                "Preço da gasolina deve ser maior que zero",
            ];

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }
    }
}
