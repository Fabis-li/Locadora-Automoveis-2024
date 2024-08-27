using System.ComponentModel.DataAnnotations;
using FluentResults;
using LocadoraDeAutomoveis.Dominio.ModuloTaxa;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeAutomoveis.WebApp.Models
{
    public class InserirTaxaViewModel
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve conter ao menos 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O campo Tipo de Cobrança é obrigatório.")]
        public TipoCobrancaEnum TipoCobranca { get; set; }

        public IEnumerable<SelectListItem>? TiposCobranca { get; set; }
    }

    public class EditarTaxaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve conter ao menos 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O campo Tipo de Cobrança é obrigatório.")]
        public TipoCobrancaEnum TipoCobranca { get; set; }

        public IEnumerable<SelectListItem>? TiposCobranca { get; set; }
    }

    public class ListarTaxaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public TipoCobrancaEnum TipoCobranca { get; set; }
    }

    public class DetalhesTaxaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public TipoCobrancaEnum TipoCobranca { get; set; }
    }


}
