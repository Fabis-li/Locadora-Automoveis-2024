using System.ComponentModel.DataAnnotations;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;

namespace LocadoraDeAutomoveis.WebApp.Models
{
    public class InserirClienteViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve conter ao menos 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O RG é obrigatório")]
        [MinLength(7, ErrorMessage = "O RG deve conter ao menos 7 caracteres")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "A CNH é obrigatória")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "A CNH deve conter ao menos 11 caracteres")]
        public string Cnh { get; set; }

        [Required(ErrorMessage = "O número do documento é obrigatório")]
        [MinLength(11, ErrorMessage = "O número do documento deve conter ao menos 11 caracteres")]
        public string NumeroDocumento { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [Phone(ErrorMessage = "O telefone deve ser válido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A rua é obrigatória")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "O número é obrigatório")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O tipo de cliente é obrigatório")]
        public TipoClienteEnum TipoCliente { get; set; }
    }

    public class EditarClienteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve conter ao menos 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O RG é obrigatório")]
        [MinLength(7, ErrorMessage = "O RG deve conter ao menos 7 caracteres")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "A CNH é obrigatória")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "A CNH deve conter ao menos 11 caracteres")]
        public string Cnh { get; set; }

        [Required(ErrorMessage = "O número do documento é obrigatório")]
        [MinLength(11, ErrorMessage = "O número do documento deve conter ao menos 11 caracteres")]
        public string NumeroDocumento { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [Phone(ErrorMessage = "O telefone deve ser válido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A rua é obrigatória")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "O número é obrigatório")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O tipo de cliente é obrigatório")]
        public TipoClienteEnum TipoCliente { get; set; }
    }

    public class ListarClienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cnh { get; set; }
        public string NumeroDocumento { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public TipoClienteEnum TipoCliente { get; set; }
    }

    public class DetalhesClienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cnh { get; set; }
        public string NumeroDocumento { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public TipoClienteEnum TipoCliente { get; set; }
    }
}
