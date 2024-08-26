using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace LocadoraDeAutomoveis.WebApp.Models
{
    public class InserirPlanoCobrancaViewModel
    {
        [Required(ErrorMessage = "O grupo de automóveis é obrigatório")]
        public int GrupoAutomovelId { get; set; }

        [Required(ErrorMessage = "O preço diário do plano diário é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço diário do plano diário deve ser maior que zero")]
        public decimal PrecoDiarioPlanoDiario { get; set; }

        [Required(ErrorMessage = "O preço por km do plano diário é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço por km do plano diário deve ser maior que zero")]
        public decimal PrecoPorKmPlanoDiario { get; set; }

        [Required(ErrorMessage = "A quantidade de km disponível no plano controlado é obrigatória")]
        [Range(0.01, double.MaxValue, ErrorMessage = "A quantidade de km disponível no plano controlado deve ser maior que zero")]
        public decimal KmDisponivelPlanoControlado { get; set; }

        [Required(ErrorMessage = "O preço diário do plano controlado é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço diário do plano controlado deve ser maior que zero")]
        public decimal PrecoDiarioPlanoControlado { get; set; }

        [Required(ErrorMessage = "O preço por km excedido do plano controlado é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço por km excedido do plano controlado deve ser maior que zero")]
        public decimal PrecoPorKmExcedido { get; set; }

        [Required(ErrorMessage = "O preço diário do plano livre é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço diário do plano livre deve ser maior que zero")]
        public decimal PrecoDiarioPlanoLivre { get; set; }

        public IEnumerable<SelectListItem>? GrupoAutomovel { get; set; }
    }

    public class EditarPlanoCobrancaViewModel 
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O grupo de automóveis é obrigatório")]
        public int GrupoAutomovelId { get; set; }

        [Required(ErrorMessage = "O preço diário do plano diário é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço diário do plano diário deve ser maior que zero")]
        public decimal PrecoDiarioPlanoDiario { get; set; }

        [Required(ErrorMessage = "O preço por km do plano diário é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço por km do plano diário deve ser maior que zero")]
        public decimal PrecoPorKmPlanoDiario { get; set; }

        [Required(ErrorMessage = "A quantidade de km disponível no plano controlado é obrigatória")]
        [Range(0.01, double.MaxValue, ErrorMessage = "A quantidade de km disponível no plano controlado deve ser maior que zero")]
        public decimal KmDisponivelPlanoControlado { get; set; }

        [Required(ErrorMessage = "O preço diário do plano controlado é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço diário do plano controlado deve ser maior que zero")]
        public decimal PrecoDiarioPlanoControlado { get; set; }

        [Required(ErrorMessage = "O preço por km excedido do plano controlado é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço por km excedido do plano controlado deve ser maior que zero")]
        public decimal PrecoPorKmExcedido { get; set; }

        [Required(ErrorMessage = "O preço diário do plano livre é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço diário do plano livre deve ser maior que zero")]
        public decimal PrecoDiarioPlanoLivre { get; set; }

        public IEnumerable<SelectListItem>? GrupoAutomovel { get; set; }
    }

    public class ListarPlanoCobrancaViewModel
    {
        public int Id { get; set; }
        public string GrupoAutomovel { get; set; }
        public decimal PrecoDiarioPlanoDiario { get; set; }
        public decimal PrecoPorKmPlanoDiario { get; set; }
        public decimal KmDisponivelPlanoControlado { get; set; }
        public decimal PrecoDiarioPlanoControlado { get; set; }
        public decimal PrecoPorKmExcedido { get; set; }
        public decimal PrecoDiarioPlanoLivre { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class DetalhesPlanoCobrancaViewModel
    {
        public int Id { get; set; }
        public string GrupoAutomovel { get; set; }
        public decimal PrecoDiarioPlanoDiario { get; set; }
        public decimal PrecoPorKmPlanoDiario { get; set; }
        public decimal KmDisponivelPlanoControlado { get; set; }
        public decimal PrecoDiarioPlanoControlado { get; set; }
        public decimal PrecoPorKmExcedido { get; set; }
        public decimal PrecoDiarioPlanoLivre { get; set; }
    }

}
