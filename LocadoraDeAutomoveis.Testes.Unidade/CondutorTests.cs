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
                nome: "João",
                email: "joao.Silva@gmail.com",
                cpf: "12345678910",
                cnh: "12345678910",
                validadeCnh: DateTime.Today.AddYears(1),
                telefone: "1197856748",
                clienteId: 1,
                clienteCondutor: true
            );
            
            var erros = condutor.Validar();


            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void Deve_Criar_Condutor_Com_Erro_Nome()
        {
            var condutor = new Condutor
            (
                nome: "",
                email: "joao.Silva@gmail.com",
                cpf: "12345678910",
                cnh: "12345678910",
                validadeCnh: DateTime.Today.AddYears(1),
                telefone: "1197856748",
                clienteId: 1,
                clienteCondutor: true
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
