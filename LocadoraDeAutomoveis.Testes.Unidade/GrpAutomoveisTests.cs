using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;

namespace LocadoraDeAutomoveis.Testes.Unidade
{
    [TestClass]
    [TestCategory("Testes de unidade GrpAutomovies")]
    public class GrpAutomoveisTests
    {
        [TestMethod]
        public void Deve_validar_nome_Grp_Corretamente()
        {
            //Arrange
            GrpAutomoveis grupoInvalido = new GrpAutomoveis("");

            List<string> erroEsperado =
            [
                "O campo \"Nome\" é obrigatório"
            ];

            //Act
            List<string> erros = grupoInvalido.Validar();

            //Assert
            CollectionAssert.AreEqual(erroEsperado, erros);
        }
    }
}