using LocadoraDeAutomoveis.Dominio.Compartilhado;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;

namespace LocadoraDeAutomoveis.Dominio.ModuloCondutor
{
    public class Condutor : EntidadeBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Cnh { get; set; }
        public DateTime ValidadeCnh { get; set; }
        public string Telefone { get; set; }
        public bool ClienteCondutor { get; set; } = false;
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        protected Condutor()
        {
            
        }

        public Condutor(string nome, string email, string cpf, string cnh, DateTime validadeCnh, string telefone, int clienteId, bool clienteCondutor) :this()
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Cnh = cnh;
            ValidadeCnh = validadeCnh;
            Telefone = telefone;
            ClienteId = clienteId;
            ClienteCondutor = clienteCondutor;
        }

        public bool ClienteEhCondutor()
        {
            bool clienteEhCondutor = true;

            return clienteEhCondutor;
        }

        public List<string> Validar()
        {
            var erros = new List<string>();

            if (string.IsNullOrEmpty(Nome))
                erros.Add("O nome é obrigatório!");

            if (string.IsNullOrEmpty(Email))
                erros.Add("Email é obrigatório!");

            if (string.IsNullOrEmpty(Cpf))
                erros.Add("Cpf é obrigatório!");

            if (string.IsNullOrEmpty(Cnh))
                erros.Add("Cnh é obrigatório!");

            if (ValidadeCnh == DateTime.MinValue)
                erros.Add("Validade da Cnh é obrigatório!");

            if (string.IsNullOrEmpty(Telefone))
                erros.Add("Telefone é obrigatório!");

            return erros;
        }
    }
}
