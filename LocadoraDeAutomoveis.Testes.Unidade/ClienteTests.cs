using LocadoraDeAutomoveis.Dominio.ModuloCliente;

namespace LocadoraDeAutomoveis.Testes.Unidade
{
    [TestClass]
    [TestCategory("Unidade")]
    public class ClienteTests
    {
        [TestMethod]
        public void Deve_Criar_Cliente_Valido()
        {
            var cliente = new Cliente
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
                );

            var erros = cliente.Validar();

            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void Deve_Criar_Cliente_Com_Erro_Nome()
        {
            var cliente = new Cliente
                (
                    "",
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
                );

            var erros = cliente.Validar();

            List<string> errosEsperados =
            [
                "O nome é obrigatório",
            ];

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }
    }
    
}
