using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;

namespace LocadoraDeAutomoveis.Testes.Unidade
{
    [TestClass]
    [TestCategory("Testes de unidade PlanoCobranca")]
    public class PlanoCobrancaTests
    {
        [TestMethod]
        public void Deve_Criar_PlanoCobranca_Valido()
        {
            var planoCobranca = new PlanoCobranca
                (
                    1,
                    10m,
                    10m,
                    10m,
                    10m,
                    10m,
                    10m
                );

            var erros = planoCobranca.Validar();

            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void Deve_Criar_PlanoCobranca_Com_Erro()
        {
            var planoCobranca = new PlanoCobranca
                (
                    0,
                    0m,
                    0m,
                    0m,
                    0m,
                    0m,
                    0m
                );

            var erros = planoCobranca.Validar();

            List<string> errosEsperados =
            [
                "O grupo de automóveis deve ser informado",
            ];

            Assert.AreEqual(errosEsperados.Count, erros.Count);
        }

    }
    
}
