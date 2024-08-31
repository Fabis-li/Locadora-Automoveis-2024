using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;

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
            var condutor = new Condutor
            (
               "João",
               "joao.Silva@gmail.com",
               "12345678910",
                "12345678910",
                DateTime.Now,
                "1197856748",
                1,
                new Cliente
                (
                    "Cliente 1",
                    "123456",
                    "123456",
                    "123456",
                    "123456",
                    "Cidade 1",
                    "Estado 1",
                    "Bairro 1",
                    "Rua 1",
                    "123",
                    TipoClienteEnum.CPF
                ),
                true
            );
            GrupoAutomovel grupoAutomoveis = new GrupoAutomovel("Passeio");
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

            Automovel automovel = new Automovel("Fusca", "Volkswagen", "Azul", "ABC-1234", TipoCombustivel.Alcool, 1970, 40, "fusca.jpg", grupoAutomoveis, 1);

            Aluguel aluguel = new Aluguel(1, condutor, 1, automovel, 1, planoCobranca, DateTime.Now, null, 100, StatusAluguelEnum.Aberto);

            //Act
            List<string> erros = aluguel.Validar();

            //Assert
            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void Deve_validar_aluguel_com_erro()
        {
            //Arrange
            var condutor = new Condutor
            (
               "Joao",
               "joao.Silva@gmail.com",
               "12345678910",
                "12345678910",
                DateTime.Now,
                "1197856748",
                1,
                new Cliente
                (
                    "Cliente 1",
                    "123456",
                    "123456",
                    "123456",
                    "123456",
                    "Cidade 1",
                    "Estado 1",
                    "Bairro 1",
                    "Rua 1",
                    "123",
                    TipoClienteEnum.CPF
                ),
                true
            );
            GrupoAutomovel grupoAutomoveis = new GrupoAutomovel("Passeio");
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

            Automovel automovel = new Automovel("Fusca", "Volkswagen", "Azul", "ABC-1234", TipoCombustivel.Alcool, 1970, 40, "fusca.jpg", grupoAutomoveis, 1);

            Aluguel aluguel = new Aluguel(0, condutor, 1, automovel, 1, planoCobranca, DateTime.Now, null, 100, StatusAluguelEnum.Aberto);

            //Act
            var erros = aluguel.Validar();

            List<string> errosEsperados =
            [
                "O campo \"CondutorId\" é obrigatório",
            ];

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }
    }
}
