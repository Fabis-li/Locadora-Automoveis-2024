using LocadoraDeAutomoveis.Dominio.Compartilhado;

namespace LocadoraDeAutomoveis.Dominio.ModuloCondutor
{
    public class Condutor : EntidadeBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Cnh { get; set; }
        public DateTime ValidaCnh { get; set; }
        public string Telefone { get; set; }

        protected Condutor() { }

        public Condutor(string nome, string email, string cpf, string cnh, DateTime validaCnh, string telefone)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Cnh = cnh;
            ValidaCnh = validaCnh;
            Telefone = telefone;
        }

        public List<string> Validar()
        {
            var erros = new List<string>();

            if (string.IsNullOrEmpty(Nome))
                erros.Add("Nome é obrigatório!");

            if (string.IsNullOrEmpty(Email))
                erros.Add("Email é obrigatório!");

            if (string.IsNullOrEmpty(Cpf))
                erros.Add("Cpf é obrigatório!");

            if (string.IsNullOrEmpty(Cnh))
                erros.Add("Cnh é obrigatório!");

            if (ValidaCnh == DateTime.MinValue)
                erros.Add("Validade da Cnh é obrigatório!");

            if (string.IsNullOrEmpty(Telefone))
                erros.Add("Telefone é obrigatório!");

            return erros;
        }
    }
}
