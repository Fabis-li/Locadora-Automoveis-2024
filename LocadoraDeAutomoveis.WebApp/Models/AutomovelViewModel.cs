using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeAutomoveis.WebApp.Models
{
    public class InserirAutomovelViewModel
    {
        [Required(ErrorMessage = "O campo Marca é obrigatório.")]
        [MinLength(2, ErrorMessage = "A marca deve conter ao menos 3 caracteres")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo Modelo é obrigatório.")]
        [MinLength(3, ErrorMessage = "O modelo deve conter ao menos 3 caracteres")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O campo Cor é obrigatório.")]
        [MinLength(3, ErrorMessage = "A cor deve conter ao menos 3 caracteres")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "O campo Placa é obrigatório.")]
        [MinLength(7, ErrorMessage = "A placa deve conter ao menos 7 caracteres")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O campo Combustível é obrigatório.")]
        public string Combustivel { get; set; }

        [Required(ErrorMessage = "O campo Ano é obrigatório.")]
        [Range(1900, 2100, ErrorMessage = "O ano deve ser entre 1900 e 2100")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "O ano deve conter 4 dígitos")]
        [DataType(DataType.Date)]
        public int Ano { get; set; }

        [Required(ErrorMessage = "O campo Capacidade de Combustível é obrigatório.")]
        [Range(1, 1000, ErrorMessage = "A capacidade de combustível deve ser entre 1 e 1000")]
        public int CapacidadeCombustivel { get; set; }

        [Required(ErrorMessage = "O campo Foto do Veículo é obrigatório.")]
        public string FotoVeiculo { get; set; }

        [Required(ErrorMessage = "O campo Grupo de Automóveis é obrigatório.")]
        public int GrupoAutomoveisId { get; set; }

        public IEnumerable<SelectListItem>? GrpAutomoveis { get; set; }
    }

    public class EditarAutomovelViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Marca é obrigatório.")]
        [MinLength(2, ErrorMessage = "A marca deve conter ao menos 3 caracteres")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo Modelo é obrigatório.")]
        [MinLength(3, ErrorMessage = "O modelo deve conter ao menos 3 caracteres")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O campo Cor é obrigatório.")]
        [MinLength(3, ErrorMessage = "A cor deve conter ao menos 3 caracteres")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "O campo Placa é obrigatório.")]
        [MinLength(7, ErrorMessage = "A placa deve conter ao menos 7 caracteres")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O campo Combustível é obrigatório.")]
        public string Combustivel { get; set; }

        [Required(ErrorMessage = "O campo Ano é obrigatório.")]
        [Range(1900, 2100, ErrorMessage = "O ano deve ser entre 1900 e 2100")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "O ano deve conter 4 dígitos")]
        [DataType(DataType.Date)]
        public int Ano { get; set; }

        [Required(ErrorMessage = "O campo Capacidade de Combustível é obrigatório.")]
        [Range(1, 1000, ErrorMessage = "A capacidade de combustível deve ser entre 1 e 1000")]
        public int CapacidadeCombustivel { get; set; }

        [Required(ErrorMessage = "O campo Foto do Veículo é obrigatório.")]
        public string FotoVeiculo { get; set; }

        [Required(ErrorMessage = "O campo Grupo de Automóveis é obrigatório.")]
        public int GrupoAutomoveisId { get; set; }

        public IEnumerable<SelectListItem>? GrpAutomoveis { get; set; }
    }

    public class ListarAutomovelViewModel
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public string Combustivel { get; set; }
        public string FotoVeiculo { get; set; }
    }

    public class AgrupamentoAutomovelViewModel
    {
        public string GrupoAutomoveis { get; set; }
        public IEnumerable<ListarAutomovelViewModel> Automoveis { get; set; }
    }

    public class DetalhesAutomovelViewModel
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public string Combustivel { get; set; }
        public int Ano { get; set; }
        public int CapacidadeCombustivel { get; set; }
        public string FotoVeiculo { get; set; }
        public string GrupoAutomoveis { get; set; }
    }

}
