using LocadoraDeAutomoveis.Dominio.ModuloAluguel;

namespace LocadoraDeAutomoveis.Testes.Unidade
{
    [TestClass]
    [TestCategory("Unidade")]
    public class AluguelTests
    {
        [TestMethod]
        public void Deve_validar_aluguel_corretamente()
        {
            //Arrange
            var aluguel = new Aluguel(
                condutorId: 1,
                automovelId: 1,
                planoCobrancaId: 1,
                dataSaida: DateTime.Now,
                dataRetorno: DateTime.Now.AddDays(3),
                valorEntrada: 1000.00m,
                status: StatusAluguelEnum.Aberto,
                planoCobranca: TipoPlanoCobrancaEnum.Diario
            );

            var erros = aluguel.Validar();

            //Assert
            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void Deve_validar_aluguel_com_erro()
        {
            //Arrange
            var aluguel = new Aluguel(
                condutorId: 0,
                automovelId: 0,
                planoCobrancaId: 0,
                dataSaida: DateTime.Now,
                dataRetorno: DateTime.Now.AddDays(3),
                valorEntrada: 1000.00m,
                status: StatusAluguelEnum.Aberto,
                planoCobranca: TipoPlanoCobrancaEnum.Diario
            );

            var erros = aluguel.Validar();

            List<string> errosEsperados =
            [
                "O campo \"CondutorId\" é obrigatório",
                "O campo \"AutomovelId\" é obrigatório",
                "O campo \"PlanoCobrancaId\" é obrigatório"
            ];

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }
    }
}
