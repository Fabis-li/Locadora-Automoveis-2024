using System.ComponentModel.DataAnnotations;

namespace LocadoraDeAutomoveis.WebApp.Models
{
    public class InserirConfiguracaoViewModel
    {
        [Required(ErrorMessage = "O campo Preço da Gasolina é obrigatório")]
        public decimal PrecoGasolina { get; set; }

        [Required(ErrorMessage = "O campo Preço do Álcool é obrigatório")]
        public decimal PrecoAlcool { get; set; }

        [Required(ErrorMessage = "O campo Preço do Diesel é obrigatório")]
        public decimal PrecoDiesel { get; set; }

        [Required(ErrorMessage = "O campo Preço do Gás é obrigatório")]
        public decimal PrecoGas { get; set; }
    }

    public class EditarConfiguracaoViewModel 
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Preço da Gasolina é obrigatório")]
        public decimal PrecoGasolina { get; set; }

        [Required(ErrorMessage = "O campo Preço do Álcool é obrigatório")]
        public decimal PrecoAlcool { get; set; }

        [Required(ErrorMessage = "O campo Preço do Diesel é obrigatório")]
        public decimal PrecoDiesel { get; set; }

        [Required(ErrorMessage = "O campo Preço do Gás é obrigatório")]
        public decimal PrecoGas { get; set; }
    }
}
