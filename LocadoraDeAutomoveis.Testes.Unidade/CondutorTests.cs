using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;

namespace LocadoraDeAutomoveis.Testes.Unidade
{
    [TestClass]
    [TestCategory("Unidade")]
    public class CondutorTests
    {
        [TestMethod]
        public void Deve_Criar_Condutor()
        {
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
            
            var erros = condutor.Validar();

            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void Deve_Criar_Condutor_Com_Erro_Nome()
        {
            var condutor = new Condutor
            (
                "",
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

            var erros = condutor.Validar();

            List<string> errosEsperados =
            [
                "O nome é obrigatório!",
            ];

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }
    }
}
