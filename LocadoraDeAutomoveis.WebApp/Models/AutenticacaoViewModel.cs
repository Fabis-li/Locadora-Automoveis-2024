using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace LocadoraDeAutomoveis.WebApp.Models
{
    public class RegistrarViewModel
    {
        [Required]
        public string? Usuario { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Senha { get; set; }

        [Display(Name = "Confirmar Senha")]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
        public string? ConfirmarSenha { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        public string? Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Senha { get; set; }

        public bool Lembrar { get; set; }
    }
}
