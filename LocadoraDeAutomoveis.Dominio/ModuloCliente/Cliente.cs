using LocadoraDeAutomoveis.Dominio.Compartilhado;

namespace LocadoraDeAutomoveis.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase
    {
        public string Nome { get; set; }
        public string Rg { get; set; }
        public int Cnh { get; set; }
        public string NumeroDocumento { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public TipoClienteEnum TipoCliente { get; set; }

        protected Cliente() { }
        
        public Cliente(string nome, string rg, int cnh, string numeroDocumento,string telefone, string cidade, string estado, string bairro, string rua, string numero, TipoClienteEnum tipoCliente) :this()
        {
            Nome = nome;
            Rg = rg;
            Cnh = cnh;
            NumeroDocumento = numeroDocumento;
            Telefone = telefone;
            Cidade = cidade;
            Estado = estado;
            Bairro = bairro;
            Rua = rua;
            Numero = numero;
            TipoCliente = tipoCliente;
        }

        public List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrWhiteSpace(Nome))
                erros.Add("O nome é obrigatório");

            if (string.IsNullOrWhiteSpace(Rg))
                erros.Add("O RG é obrigatório");

            if (Cnh == 0)
                erros.Add("A CNH é obrigatória");

            if (string.IsNullOrWhiteSpace(NumeroDocumento))
                erros.Add("O número do documento é obrigatório");

            if (string.IsNullOrWhiteSpace(Telefone))
                erros.Add("O telefone é obrigatório");

            if (string.IsNullOrWhiteSpace(Cidade))
                erros.Add("A cidade é obrigatória");

            if (string.IsNullOrWhiteSpace(Estado))
                erros.Add("O estado é obrigatório");

            if (string.IsNullOrWhiteSpace(Bairro))
                erros.Add("O bairro é obrigatório");

            if (string.IsNullOrWhiteSpace(Rua))
                erros.Add("A rua é obrigatória");

            if (string.IsNullOrWhiteSpace(Numero))
                erros.Add("O número é obrigatório");

            return erros;
        }


    }
    

}
