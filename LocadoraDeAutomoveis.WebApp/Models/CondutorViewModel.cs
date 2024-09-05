using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeAutomoveis.WebApp.Models
{
    public class InserirCondutorViewModel
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve conter ao menos 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email deve ser válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [MinLength(11, ErrorMessage = "O CPF deve conter ao menos 11 caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo CNH é obrigatório.")]
        [MinLength(11, ErrorMessage = "A CNH deve conter ao menos 11 caracteres")]
        public string Cnh { get; set; }

        [Required(ErrorMessage = "O campo Validação da CNH é obrigatório.")]
        [DataType(DataType.Date)]
        public DateTime ValidaCnh { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        [Phone(ErrorMessage = "O telefone deve ser válido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo Cliente Condutor é obrigatório.")]
        public bool ClienteCondutor { get; set; }

        [Required(ErrorMessage = "O campo Cliente é obrigatório.")]
        public int ClienteId { get; set; }

        public IEnumerable<SelectListItem>? Clientes { get; set; }
    }

    public class EditarCondutorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve conter ao menos 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email deve ser válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [MinLength(11, ErrorMessage = "O CPF deve conter ao menos 11 caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo CNH é obrigatório.")]
        [MinLength(11, ErrorMessage = "A CNH deve conter ao menos 11 caracteres")]
        public string Cnh { get; set; }

        [Required(ErrorMessage = "O campo Validação da CNH é obrigatório.")]
        [DataType(DataType.Date)]
        public string ValidaCnh { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        [Phone(ErrorMessage = "O telefone deve ser válido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo Cliente Condutor é obrigatório.")]
        public bool ClienteCondutor { get; set; }

        [Required(ErrorMessage = "O campo Cliente é obrigatório.")]
        public int ClienteId { get; set; }

        public IEnumerable<SelectListItem>? Cliente { get; set; }
    }

    public class ListarCondutorViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Cnh { get; set; }
        public DateTime ValidaCnh { get; set; }
        public string Telefone { get; set; }
        public bool ClienteCondutor { get; set; }
        public int ClienteId { get; set; }
        public string Cliente { get; set; }
    }

    public class DetalhesCondutorViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Cnh { get; set; }
        public string ValidaCnh { get; set; }
        public string Telefone { get; set; }
        public bool ClienteCondutor { get; set; }
        public int ClienteId { get; set; }
        public string Cliente { get; set; }
    }


}
