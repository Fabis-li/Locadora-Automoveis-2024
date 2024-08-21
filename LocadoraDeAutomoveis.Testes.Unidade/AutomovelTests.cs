using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;

namespace LocadoraDeAutomoveis.Testes.Unidade
{
    [TestClass]
    [TestCategory("Testes de unidade Automovel")]
    public class AutomovelTests
    {
        [TestMethod]
        public void Deve_validar_modelo_corretamente()
        {
            //Arrange
            Automovel automovelInvalido = new Automovel("", "Volkswagen", "Azul", "ABC-1234", "Gasolina", 1970, 40, "fusca.jpg");

            //Act
            List<string> erros = automovelInvalido.Validar();

            //Assert
            List<string> erroEsperado =
            [
                "O campo \"Modelo\" é obrigatório"
            ];
            CollectionAssert.AreEqual(erroEsperado, erros);
        }

        [TestMethod]
        public void Deve_validar_marca_corretamente()
        {
            //Arrange
            Automovel automovelInvalido = new Automovel("Fusca", "", "Azul", "ABC-1234", "Gasolina", 1970, 40, "fusca.jpg");

            //Act
            List<string> erros = automovelInvalido.Validar();

            //Assert
            List<string> erroEsperado =
            [
                "O campo \"Marca\" é obrigatório"
            ];
            CollectionAssert.AreEqual(erroEsperado, erros);
        }

        [TestMethod]
        public void Deve_validar_cor_corretamente()
        {
            //Arrange
            Automovel automovelInvalido = new Automovel("Fusca", "Volkswagen", "", "ABC-1234", "Gasolina", 1970, 40, "fusca.jpg");

            //Act
            List<string> erros = automovelInvalido.Validar();

            //Assert
            List<string> erroEsperado =
            [
                "O campo \"Cor\" é obrigatório"
            ];
            CollectionAssert.AreEqual(erroEsperado, erros);
        }

        [TestMethod]
        public void Deve_validar_placa_corretamente()
        {
            //Arrange
            Automovel automovelInvalido = new Automovel("Fusca", "Volkswagen", "Azul", "", "Gasolina", 1970, 40, "fusca.jpg");

            //Act
            List<string> erros = automovelInvalido.Validar();

            //Assert
            List<string> erroEsperado =
            [
                "O campo \"Placa\" é obrigatório"
            ];
            CollectionAssert.AreEqual(erroEsperado, erros);
        }

        [TestMethod]
        public void Deve_validar_combustivel_corretamente()
        {
            //Arrange
            Automovel automovelInvalido = new Automovel("Fusca", "Volkswagen", "Azul", "ABC-1234", "", 1970, 40, "fusca.jpg");

            //Act
            List<string> erros = automovelInvalido.Validar();

            //Assert
            List<string> erroEsperado =
            [
                "O campo \"Combustível\" é obrigatório"
            ];
            CollectionAssert.AreEqual(erroEsperado, erros);
        }

        [TestMethod]
        public void Deve_validar_ano_corretamente()
        {
            //Arrange
            Automovel automovelInvalido = new Automovel("Fusca", "Volkswagen", "Azul", "ABC-1234", "Gasolina", -1, 40, "fusca.jpg");

            //Act
            List<string> erros = automovelInvalido.Validar();

            //Assert
            List<string> erroEsperado =
            [
                "O campo \"Ano\" é obrigatório"
            ];
            CollectionAssert.AreEqual(erroEsperado, erros);
        }

        [TestMethod]
        public void Deve_validar_capacidade_combustivel_corretamente()
        {
            //Arrange
            Automovel automovelInvalido = new Automovel("Fusca", "Volkswagen", "Azul", "ABC-1234", "Gasolina", 1970, 0, "fusca.jpg");

            //Act
            List<string> erros = automovelInvalido.Validar();

            //Assert
            List<string> erroEsperado =
            [
                "O campo \"CapacidadeCombustivel\" é obrigatório"
            ];
            CollectionAssert.AreEqual(erroEsperado, erros);
        }

        [TestMethod]
        public void Deve_validar_foto_veiculo_corretamente()
        {
            //Arrange
            Automovel automovelInvalido = new Automovel("Fusca", "Volkswagen", "Azul", "ABC-1234", "Gasolina", 1970, 40, "");

            //Act
            List<string> erros = automovelInvalido.Validar();

            //Assert
            List<string> erroEsperado =
            [
                "O campo \"FotoVeiculo\" é obrigatório"
            ];
            CollectionAssert.AreEqual(erroEsperado, erros);
        }
    }
}
