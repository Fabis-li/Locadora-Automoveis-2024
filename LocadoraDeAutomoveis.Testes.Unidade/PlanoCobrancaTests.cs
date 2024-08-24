using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;

namespace LocadoraDeAutomoveis.Testes.Unidade
{
    [TestClass]
    [TestCategory("Testes de unidade PlanoCobranca")]
    public class PlanoCobrancaTests
    {
        [TestMethod]
        public void Deve_validar_plano_cobranca_corretamente()
        {
            var plano = new PlanoDiario(100m, 2m);

            var erros = plano.Validar();

            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void Deve_validar_plano_cobranca_errado()
        {
            var plano = new PlanoDiario(0m, 0m);

            var erros = plano.Validar();

            List<string> erroEsperado = new List<string>
            {
                "Preço da diária deve ser maior que zero",
                "Preço por km deve ser maior que zero"
            };

            CollectionAssert.AreEqual(erroEsperado, erros);
        }
    }
    
}
